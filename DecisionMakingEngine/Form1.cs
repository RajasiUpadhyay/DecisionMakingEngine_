using NativeWifi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows;
namespace DecisionMakingEngine
{
    public partial class Form1 : Form
    {
        //private System.Windows.Forms.Timer timer1;
        private long totalUsedmb = 0;
        public long originalCharge = 0;
        public long BeforeCharge = 0;
        public long AfterCharge = 0;
        private double dbWM;
        private double dbWP;
        private double dbWC;
        private double dbWE;
        private double dbDI;
        private double dbDO;
        private double dbPLocal;
        private double dbPCloud;
        private string stWireless;
        private string PercentageRAMMemoryLabel;
        private string TotalRAMMemoryValueLabel;
        private string TotalRAMMemoryUsageValueLabel;
        private bool IsWifiConnected { get; set; } = false;
        private bool IsCarrierChargesAllowed { get; set; } = false;

        private PerformanceCounter perfCounterCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        private bool bMonitorCPUUsage = false;
        private Thread threadCPUUsage = null;

        public Form1()
        {

            var confirmResult = MessageBox.Show("Do you allow addition of carrier charges in case of WiFi disconnectivity and data limit exhaustion?", "", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes'
                IsCarrierChargesAllowed = true;
                //MessageBox.Show("Yes", "Carrier charges will be added.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                // If 'No'
                IsCarrierChargesAllowed = false;
                //MessageBox.Show("No", "Carrier charges will not be added.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            InitializeComponent();
            if (IsCarrierChargesAllowed) {
                lblCarrierCharge.Text = "Carrier charges are going to be applied.";
               
            }
            else
            { btnCalculateCost.Enabled = false;
                lblCarrierCharge.Text = "Carrier charges are not going to be applied.";
            }
            GetAndShowParameters();
            InitTimer();
        }

        public double GetCPUUsage()
        {
            return (double)perfCounterCPU.NextValue();
        }

        public string GetResource(string name)
        {
            return Constants.ResourceManager.GetString(name);
        }

        public string GetWirelessInfo()
        {
            WlanClient wlan = new WlanClient();   //WlanClient is class from NativeWifi
            string SSIDret = "NotDetected";

            //
            //----added try catch method because during changing of wireless network checking of ssid from NativeWiFi can throw an exception
            //
            try
            {
                foreach (WlanClient.WlanInterface wlanInterface in wlan.Interfaces)
                {
                    IsWifiConnected = true;
                    Wlan.Dot11Ssid ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
                    SSIDret = new string(Encoding.ASCII.GetChars(ssid.SSID, 0, (int)ssid.SSIDLength));
                }
            }
            catch //if exception thrown during changing of wifi
            {
                SSIDret = "NotDetected";
            }

            return SSIDret;
        }

        public void GetAndShowParameters()
        {
            try
            { 
                //dbWB = double.Parse(Constants.WB);
                dbWP = double.Parse(Constants.WP);
                dbWM = double.Parse(Constants.WM);
                dbWC = double.Parse(Constants.WC);
                dbWE = double.Parse(Constants.WE);

                textBoxWB.Text = string.Format("{0:F2}", dbWM);
                textBoxWP.Text = string.Format("{0:F2}", dbWP);
                textBoxWC.Text = string.Format("{0:F2}", dbWE);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public void GetInputs()
        //{
        //    try
        //    {
        //        dbDI = double.Parse(textBoxDI.Text);
        //        dbDO = double.Parse(textBoxDO.Text);
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public object GetRAMusage()
        {
            double memAvailable, memPhysical;

            PerformanceCounter pCntr = new PerformanceCounter("Memory", "Available KBytes");
            memAvailable = (double)pCntr.NextValue();  // Returns Available RAM memory in KBytes
            memAvailable = memAvailable / 1000 / 1024;

            memPhysical = GetPhysicalMemory();

            return Math.Truncate((memPhysical - memAvailable) * 100 / memPhysical);

        }

        private double GetPhysicalMemory()
        {
            ObjectQuery winQuery = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(winQuery);

            double memory = 0;
            foreach (ManagementObject item in searcher.Get())
            {
                memory = double.Parse(item["TotalPhysicalMemory"].ToString()); // Returns total RAM memory in bytes
            }
            return Math.Truncate(memory / 1000 / 1024 / 1024);
        }

        public object GetRAMinUse()
        {
            double memAvailable, memPhysical;

            PerformanceCounter pCntr = new PerformanceCounter("Memory", "Available KBytes");
            memAvailable = (double)pCntr.NextValue();   // Returns Available RAM memory in KBytes
            memAvailable = memAvailable / 1000 / 1024;

            memPhysical = GetPhysicalMemory();

            //TEST
            //But next release can be done yet, because this can be adjusted in future
            return Math.Truncate(100 * (memPhysical - memAvailable + 0.23)) / 100;   //const 0.23 is a try to retrieve a proper value after truncate of Total Physical Memory, must be tested

        }

        public void CalculateDecision()
        {
            try
            {
                // getBattery
                stWireless = GetWirelessInfo();
                //textBoxBattery.Text = string.Format("{0:F2}%", dbBattery);

                this.PercentageRAMMemoryLabel = GetRAMusage().ToString();
                this.TotalRAMMemoryValueLabel = GetPhysicalMemory().ToString() + " GB";
                this.TotalRAMMemoryUsageValueLabel = GetRAMinUse().ToString() + " GB";
                //  ActualRAMusage = Int32.Parse(GetRAMusage().ToString());

                
                double availablerammemory = 100 - double.Parse(PercentageRAMMemoryLabel);
                textBoxRamMemory.Text = availablerammemory.ToString();

                dbPLocal = double.Parse(textBoxpLocal.Text);
                dbPCloud = double.Parse(textBoxpCloud.Text);

                double cCloud = dbDI + dbDO;
                double scoreLocal = 0.00;
                double scoreCloud = 0.00;


                if (availablerammemory < 25) // can be changed as per requirement of threshold
                {
                  dbWM = 0.6;
                  dbWP = 0.3;
                  textBoxWB.Text = string.Format("{0:F2}", dbWM);
                  textBoxWP.Text = string.Format("{0:F2}", dbWP);
                }
                else
                {
                  textBoxWB.Text = string.Format("{0:F2}", dbWM);
                  textBoxWP.Text = string.Format("{0:F2}", dbWP);
                  dbWM = 0.2;
                  dbWP = 0.7;
                }
                scoreLocal = dbPLocal * dbWP + availablerammemory * dbWM;
                scoreCloud = dbPCloud * dbWP + availablerammemory * dbWM;

                textBoxLocalScore.Text = string.Format("{0:F4}", scoreLocal);
                if(stWireless != "NotDetected")
                {
                    textBoxCloudScore.Text = string.Format("{0:F4}", scoreCloud);
                }
                

                string decision = "Same";

                if ((scoreLocal < scoreCloud) || (stWireless == "NotDetected" && IsCarrierChargesAllowed==false)) 
                    decision = "Local";
                else if (scoreLocal > scoreCloud)
                    decision = "Cloud";
                
                textBoxDecision.Text = decision;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 100; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
        public void CalculateDataCost() {
            try
            {
                if (IsCarrierChargesAllowed == true)// IsWifiConnected == false && 
                {
                    if (!NetworkInterface.GetIsNetworkAvailable())
                    {
                        lblWifiConnected.Text = "WIFI is not connected";
                        return;
                    }
                    else
                    {
                        lblWifiConnected.Text = "WIFI is not connected";
                    }

                    NetworkInterface[] interfaces
                        = NetworkInterface.GetAllNetworkInterfaces();

                    foreach (NetworkInterface ni in interfaces)
                    {
                        //1MB = 1048576 Bytes
                        //Console.WriteLine("    Bytes Sent: {0}", ni.GetIPv4Statistics().BytesSent);
                        //Console.WriteLine("    Bytes Received: {0}", ni.GetIPv4Statistics().BytesReceived);
                        if (ni.GetIPv4Statistics().BytesReceived != 0)
                        {
                            //totalUsedmb = totalUsedmb + ((ni.GetIPv4Statistics().BytesReceived / 1000) / 1024);
                            totalUsedmb = totalUsedmb + (ni.GetIPv4Statistics().BytesReceived / 1048576);

                            //lblCarrierCharge.Text = " Bytes Received: " + totalUsedmb.ToString();
                            
                        }
                    } 
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetAndShowParameters();
            //GetInputs();
            CalculateDecision();
        }

        private delegate void ThreadSafeSetControlTextCallback(string text);

        private void SetTextBoxpLocalText(string text)
        {
            if (this.textBoxpLocal.InvokeRequired)
            {
                ThreadSafeSetControlTextCallback d = new ThreadSafeSetControlTextCallback(SetTextBoxpLocalText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                textBoxpLocal.Text = text;
            }
        }

        private void CPUUsageRecordThreadFunc()
        {
            double cpuUsage;
            double cpuUsageSum = 0.0;
            int cnt = 0;
            try
            {
                while(bMonitorCPUUsage)
                {
                    cpuUsage = GetCPUUsage();
                    cpuUsageSum += cpuUsage;
                    ++cnt;
                    Thread.Sleep(200);
                }
            }
            catch 
            {
            }
            finally
            {
                dbPLocal = 0.0;
                if (cnt != 0)
                    dbPLocal = cpuUsageSum / (cnt * 100.0); // pecentage
                SetTextBoxpLocalText(string.Format("{0:F3}", dbPLocal));
            }
        }

        private void buttonTestLocal_Click(object sender, EventArgs e)
        {
            string localEndpoint = textBoxLocalEndpoint.Text;
            buttonTestLocal.Enabled = false;

            // try to initialize
            GetCPUUsage();

            try
            {
                // GetWirelessInfo
                stWireless = GetWirelessInfo();
                textBoxWireless.Text = string.Format("{0:F2}%", stWireless);

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(localEndpoint);
                request.Method = "Get";

                /*  input
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] buffer = encoding.GetBytes(RequestString.ToString());
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                */

                bMonitorCPUUsage = true;
                threadCPUUsage = new Thread(this.CPUUsageRecordThreadFunc);
                threadCPUUsage.IsBackground = true;
                threadCPUUsage.Start();

                string responseContent = "";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseContent = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bMonitorCPUUsage = false;
                buttonTestLocal.Enabled = true;
            }
        }

        private void buttonTestCloud_Click(object sender, EventArgs e)
        {
            string cloudEndpoints = textBoxCloudEndpoint.Text;
            string[] arrayCloudEndpoints = cloudEndpoints.Split(';');
            buttonTestCloud.Enabled = false;

            double dbDISum = 0.0, dbDOSum = 0.0, dbPCloudSum = 0.0;
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                Encoding encoding = Encoding.UTF8;
                foreach (var cloudEndpoint in arrayCloudEndpoints)
                { 
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(cloudEndpoint);
                    request.Method = "Get";
                
                    /*  input
                    request.ContentType = "application/x-www-form-urlencoded";
                    byte[] buffer = encoding.GetBytes(RequestString.ToString());
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                     */
                    long inputLength = request.ContentLength;
                    long outputLength = 0;
                    string responseContent = "";

                    DateTime beginTimestamp = DateTime.Now;
                    originalCharge = totalUsedmb;
                    CalculateDataCost();
                    BeforeCharge= totalUsedmb;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    CalculateDataCost();
                    AfterCharge = totalUsedmb;
                    originalCharge = originalCharge + (AfterCharge - BeforeCharge);
                    totalUsedmb = originalCharge;
                    txtCalculatedCost.Text = Convert.ToString((totalUsedmb) * dbWC) + " CAD ";
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        responseContent = reader.ReadToEnd();
                        byte[] buffer_tmp = encoding.GetBytes(responseContent.ToString());
                        outputLength = buffer_tmp.Length;
                    }
                    DateTime endTimestamp = DateTime.Now;

                    dbDISum += Convert.ToDouble(inputLength) / 1024.0; // in KB;
                    dbDOSum += Convert.ToDouble(outputLength) / 1024.0;

                    TimeSpan interval = endTimestamp - beginTimestamp;
                    dbPCloudSum += interval.TotalSeconds;
                }

                if (arrayCloudEndpoints.Length > 0)
                {
                    // record the values and show them into UI
                    dbDI = dbDISum / arrayCloudEndpoints.Length;
                    dbDO = dbDOSum / arrayCloudEndpoints.Length;

                    //textBoxDI.Text = string.Format("{0:F2}", dbDI);
                    //textBoxDO.Text = string.Format("{0:F2}", dbDO);

                    // This TR + RT + TO, in second
                    dbPCloud = dbPCloudSum / arrayCloudEndpoints.Length;
                    textBoxpCloud.Text = string.Format("{0:F3}", dbPCloud);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonTestCloud.Enabled = true;
            }
        }
    }
}

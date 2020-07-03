namespace DecisionMakingEngine
{
    partial class Form1
    {
        /// <summary>
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 

        /// <summary>
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonCalc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDecision = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblWC = new System.Windows.Forms.Label();
            this.textBoxWC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxWP = new System.Windows.Forms.TextBox();
            this.textBoxWB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxRamMemory = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxWireless = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxpCloud = new System.Windows.Forms.TextBox();
            this.textBoxpLocal = new System.Windows.Forms.TextBox();
            this.textBoxLocalScore = new System.Windows.Forms.TextBox();
            this.textBoxCloudScore = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonTestCloud = new System.Windows.Forms.Button();
            this.buttonTestLocal = new System.Windows.Forms.Button();
            this.textBoxCloudEndpoint = new System.Windows.Forms.TextBox();
            this.textBoxLocalEndpoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCarrierCharge = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblWifiConnected = new System.Windows.Forms.Label();
            this.txtCalculatedCost = new System.Windows.Forms.TextBox();
            this.lblCalculatedCost = new System.Windows.Forms.Label();
            this.btnCalculateCost = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCalc
            // 
            this.buttonCalc.Location = new System.Drawing.Point(372, 315);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(74, 45);
            this.buttonCalc.TabIndex = 0;
            this.buttonCalc.Text = "Calculate";
            this.buttonCalc.UseVisualStyleBackColor = true;
            this.buttonCalc.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Decision";
            // 
            // textBoxDecision
            // 
            this.textBoxDecision.Location = new System.Drawing.Point(172, 365);
            this.textBoxDecision.Name = "textBoxDecision";
            this.textBoxDecision.Size = new System.Drawing.Size(191, 20);
            this.textBoxDecision.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblWC);
            this.groupBox1.Controls.Add(this.textBoxWC);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxWP);
            this.groupBox1.Controls.Add(this.textBoxWB);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 57);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // lblWC
            // 
            this.lblWC.AutoSize = true;
            this.lblWC.Location = new System.Drawing.Point(304, 25);
            this.lblWC.Name = "lblWC";
            this.lblWC.Size = new System.Drawing.Size(25, 13);
            this.lblWC.TabIndex = 18;
            this.lblWC.Text = "WE";
            // 
            // textBoxWC
            // 
            this.textBoxWC.Location = new System.Drawing.Point(335, 22);
            this.textBoxWC.Name = "textBoxWC";
            this.textBoxWC.ReadOnly = true;
            this.textBoxWC.Size = new System.Drawing.Size(76, 20);
            this.textBoxWC.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(185, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "WP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "WM";
            // 
            // textBoxWP
            // 
            this.textBoxWP.Location = new System.Drawing.Point(208, 22);
            this.textBoxWP.Name = "textBoxWP";
            this.textBoxWP.ReadOnly = true;
            this.textBoxWP.Size = new System.Drawing.Size(76, 20);
            this.textBoxWP.TabIndex = 14;
            // 
            // textBoxWB
            // 
            this.textBoxWB.Location = new System.Drawing.Point(81, 19);
            this.textBoxWB.Name = "textBoxWB";
            this.textBoxWB.ReadOnly = true;
            this.textBoxWB.Size = new System.Drawing.Size(76, 20);
            this.textBoxWB.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxRamMemory);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxWireless);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxpCloud);
            this.groupBox2.Controls.Add(this.textBoxpLocal);
            this.groupBox2.Location = new System.Drawing.Point(12, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 84);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Performance";
            // 
            // textBoxRamMemory
            // 
            this.textBoxRamMemory.Location = new System.Drawing.Point(81, 58);
            this.textBoxRamMemory.Name = "textBoxRamMemory";
            this.textBoxRamMemory.ReadOnly = true;
            this.textBoxRamMemory.Size = new System.Drawing.Size(76, 20);
            this.textBoxRamMemory.TabIndex = 21;
            this.textBoxRamMemory.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "RAM Memory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Wireless";
            // 
            // textBoxWireless
            // 
            this.textBoxWireless.Location = new System.Drawing.Point(347, 22);
            this.textBoxWireless.Name = "textBoxWireless";
            this.textBoxWireless.ReadOnly = true;
            this.textBoxWireless.Size = new System.Drawing.Size(76, 20);
            this.textBoxWireless.TabIndex = 18;
            this.textBoxWireless.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(161, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "pCloud";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "pLocal";
            // 
            // textBoxpCloud
            // 
            this.textBoxpCloud.Location = new System.Drawing.Point(208, 22);
            this.textBoxpCloud.Name = "textBoxpCloud";
            this.textBoxpCloud.ReadOnly = true;
            this.textBoxpCloud.Size = new System.Drawing.Size(76, 20);
            this.textBoxpCloud.TabIndex = 9;
            this.textBoxpCloud.Text = "0";
            // 
            // textBoxpLocal
            // 
            this.textBoxpLocal.Location = new System.Drawing.Point(81, 25);
            this.textBoxpLocal.Name = "textBoxpLocal";
            this.textBoxpLocal.ReadOnly = true;
            this.textBoxpLocal.Size = new System.Drawing.Size(76, 20);
            this.textBoxpLocal.TabIndex = 8;
            this.textBoxpLocal.Text = "0";
            // 
            // textBoxLocalScore
            // 
            this.textBoxLocalScore.Location = new System.Drawing.Point(172, 315);
            this.textBoxLocalScore.Name = "textBoxLocalScore";
            this.textBoxLocalScore.Size = new System.Drawing.Size(191, 20);
            this.textBoxLocalScore.TabIndex = 6;
            // 
            // textBoxCloudScore
            // 
            this.textBoxCloudScore.Location = new System.Drawing.Point(172, 340);
            this.textBoxCloudScore.Name = "textBoxCloudScore";
            this.textBoxCloudScore.Size = new System.Drawing.Size(191, 20);
            this.textBoxCloudScore.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Objective Function for Local";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Objective Function for Cloud";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonTestCloud);
            this.groupBox4.Controls.Add(this.buttonTestLocal);
            this.groupBox4.Controls.Add(this.textBoxCloudEndpoint);
            this.groupBox4.Controls.Add(this.textBoxLocalEndpoint);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 202);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(431, 89);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Endpoints";
            // 
            // buttonTestCloud
            // 
            this.buttonTestCloud.Location = new System.Drawing.Point(347, 51);
            this.buttonTestCloud.Name = "buttonTestCloud";
            this.buttonTestCloud.Size = new System.Drawing.Size(78, 23);
            this.buttonTestCloud.TabIndex = 22;
            this.buttonTestCloud.Text = "Test Cloud";
            this.buttonTestCloud.UseVisualStyleBackColor = true;
            this.buttonTestCloud.Click += new System.EventHandler(this.buttonTestCloud_Click);
            // 
            // buttonTestLocal
            // 
            this.buttonTestLocal.Location = new System.Drawing.Point(347, 22);
            this.buttonTestLocal.Name = "buttonTestLocal";
            this.buttonTestLocal.Size = new System.Drawing.Size(78, 23);
            this.buttonTestLocal.TabIndex = 21;
            this.buttonTestLocal.Text = "Test Local";
            this.buttonTestLocal.UseVisualStyleBackColor = true;
            this.buttonTestLocal.Click += new System.EventHandler(this.buttonTestLocal_Click);
            // 
            // textBoxCloudEndpoint
            // 
            this.textBoxCloudEndpoint.Location = new System.Drawing.Point(110, 51);
            this.textBoxCloudEndpoint.Name = "textBoxCloudEndpoint";
            this.textBoxCloudEndpoint.Size = new System.Drawing.Size(231, 20);
            this.textBoxCloudEndpoint.TabIndex = 20;
            //this.textBoxCloudEndpoint.Text = "http://ec2-35-175-151-42.compute-1.amazonaws.com/ipimgnkypts/api/values";
            this.textBoxCloudEndpoint.Text = "http://35.175.151.42/Matkyptcnt/api/values";
            // 
            // textBoxLocalEndpoint
            // 
            this.textBoxLocalEndpoint.Location = new System.Drawing.Point(110, 22);
            this.textBoxLocalEndpoint.Name = "textBoxLocalEndpoint";
            this.textBoxLocalEndpoint.Size = new System.Drawing.Size(231, 20);
            this.textBoxLocalEndpoint.TabIndex = 19;
            this.textBoxLocalEndpoint.Text = "http://localhost:55250/api/values/MatchedKeyPtCount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cloud Endpoint";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Local Endpoint";
            // 
            // lblCarrierCharge
            // 
            this.lblCarrierCharge.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.lblCarrierCharge.AutoSize = true;
            this.lblCarrierCharge.ForeColor = System.Drawing.Color.Red;
            this.lblCarrierCharge.Location = new System.Drawing.Point(9, 445);
            this.lblCarrierCharge.Name = "lblCarrierCharge";
            this.lblCarrierCharge.Size = new System.Drawing.Size(81, 13);
            this.lblCarrierCharge.TabIndex = 16;
            this.lblCarrierCharge.Text = "lblCarrierCharge";
            // 
            // lblWifiConnected
            // 
            this.lblWifiConnected.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.lblWifiConnected.AutoSize = true;
            this.lblWifiConnected.ForeColor = System.Drawing.Color.Red;
            this.lblWifiConnected.Location = new System.Drawing.Point(9, 470);
            this.lblWifiConnected.Name = "lblWifiConnected";
            this.lblWifiConnected.Size = new System.Drawing.Size(87, 13);
            this.lblWifiConnected.TabIndex = 17;
            this.lblWifiConnected.Text = "WiFi is not connected";
            // 
            // txtCalculatedCost
            // 
            this.txtCalculatedCost.Enabled = false;
            this.txtCalculatedCost.Location = new System.Drawing.Point(172, 391);
            this.txtCalculatedCost.Name = "txtCalculatedCost";
            this.txtCalculatedCost.Size = new System.Drawing.Size(191, 20);
            this.txtCalculatedCost.TabIndex = 18;
            // 
            // lblCalculatedCost
            // 
            this.lblCalculatedCost.AutoSize = true;
            this.lblCalculatedCost.Location = new System.Drawing.Point(86, 394);
            this.lblCalculatedCost.Name = "lblCalculatedCost";
            this.lblCalculatedCost.Size = new System.Drawing.Size(80, 13);
            this.lblCalculatedCost.TabIndex = 19;
            this.lblCalculatedCost.Text = "Calculated cost";
            // 
            // btnCalculateCost
            // 
            this.btnCalculateCost.Location = new System.Drawing.Point(172, 417);
            this.btnCalculateCost.Name = "btnCalculateCost";
            this.btnCalculateCost.Size = new System.Drawing.Size(191, 26);
            this.btnCalculateCost.TabIndex = 20;
            this.btnCalculateCost.Text = "Calculate cost";
            this.btnCalculateCost.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 492);
            this.Controls.Add(this.btnCalculateCost);
            this.Controls.Add(this.lblCalculatedCost);
            this.Controls.Add(this.txtCalculatedCost);
            this.Controls.Add(this.lblWifiConnected);
            this.Controls.Add(this.lblCarrierCharge);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCloudScore);
            this.Controls.Add(this.textBoxLocalScore);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxDecision);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCalc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "DecisionMakingEngine";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCalc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDecision;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxLocalScore;
        private System.Windows.Forms.TextBox textBoxCloudScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxWP;
        private System.Windows.Forms.TextBox textBoxWB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxpCloud;
        private System.Windows.Forms.TextBox textBoxpLocal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonTestCloud;
        private System.Windows.Forms.Button buttonTestLocal;
        private System.Windows.Forms.TextBox textBoxCloudEndpoint;
        private System.Windows.Forms.TextBox textBoxLocalEndpoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxWireless;
        private System.Windows.Forms.TextBox textBoxRamMemory;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCarrierCharge;
        private System.Windows.Forms.Label lblWC;
        private System.Windows.Forms.TextBox textBoxWC;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblWifiConnected;
        private System.Windows.Forms.TextBox txtCalculatedCost;
        private System.Windows.Forms.Label lblCalculatedCost;
        private System.Windows.Forms.Button btnCalculateCost;
    }
}


namespace CarrierAPI_Test_Cases
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbServiceUsed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbServiceID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.btnShipPackage = new System.Windows.Forms.Button();
            this.rtbResults = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbServiceUsed
            // 
            this.cmbServiceUsed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceUsed.FormattingEnabled = true;
            this.cmbServiceUsed.Items.AddRange(new object[] {
            "FedEx",
            "UPS"});
            this.cmbServiceUsed.Location = new System.Drawing.Point(3, 16);
            this.cmbServiceUsed.Name = "cmbServiceUsed";
            this.cmbServiceUsed.Size = new System.Drawing.Size(282, 21);
            this.cmbServiceUsed.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shipping Provider";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cmbServiceUsed);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cmbServiceID);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.nudWidth);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.nudHeight);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.nudLength);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.nudWeight);
            this.flowLayoutPanel1.Controls.Add(this.btnShipPackage);
            this.flowLayoutPanel1.Controls.Add(this.rtbResults);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(290, 413);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Shipping Service";
            // 
            // cmbServiceID
            // 
            this.cmbServiceID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceID.FormattingEnabled = true;
            this.cmbServiceID.Items.AddRange(new object[] {
            "FedEx Ground",
            "FedEx AIR",
            "UPS Express",
            "UPS 2DAY"});
            this.cmbServiceID.Location = new System.Drawing.Point(3, 56);
            this.cmbServiceID.Name = "cmbServiceID";
            this.cmbServiceID.Size = new System.Drawing.Size(282, 21);
            this.cmbServiceID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Package Width (cm)";
            // 
            // nudWidth
            // 
            this.nudWidth.DecimalPlaces = 2;
            this.nudWidth.Location = new System.Drawing.Point(3, 96);
            this.nudWidth.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(120, 20);
            this.nudWidth.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Package Height (cm)";
            // 
            // nudHeight
            // 
            this.nudHeight.DecimalPlaces = 2;
            this.nudHeight.Location = new System.Drawing.Point(3, 135);
            this.nudHeight.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(120, 20);
            this.nudHeight.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Package Length (cm)";
            // 
            // nudLength
            // 
            this.nudLength.DecimalPlaces = 2;
            this.nudLength.Location = new System.Drawing.Point(3, 174);
            this.nudLength.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudLength.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(120, 20);
            this.nudLength.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Package Weight (kg)";
            // 
            // nudWeight
            // 
            this.nudWeight.DecimalPlaces = 2;
            this.nudWeight.Location = new System.Drawing.Point(3, 213);
            this.nudWeight.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudWeight.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(120, 20);
            this.nudWeight.TabIndex = 11;
            // 
            // btnShipPackage
            // 
            this.btnShipPackage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnShipPackage.Location = new System.Drawing.Point(3, 239);
            this.btnShipPackage.Name = "btnShipPackage";
            this.btnShipPackage.Size = new System.Drawing.Size(282, 23);
            this.btnShipPackage.TabIndex = 3;
            this.btnShipPackage.Text = "Ship Package";
            this.btnShipPackage.UseVisualStyleBackColor = true;
            this.btnShipPackage.Click += new System.EventHandler(this.btnShipPackage_Click);
            // 
            // rtbResults
            // 
            this.rtbResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbResults.Location = new System.Drawing.Point(3, 268);
            this.rtbResults.Name = "rtbResults";
            this.rtbResults.ReadOnly = true;
            this.rtbResults.Size = new System.Drawing.Size(282, 133);
            this.rtbResults.TabIndex = 12;
            this.rtbResults.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 413);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarrierAPI Testing App";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbServiceUsed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbServiceID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.Button btnShipPackage;
        private System.Windows.Forms.RichTextBox rtbResults;
    }
}


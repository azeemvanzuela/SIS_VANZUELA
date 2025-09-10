namespace WindowsFormsApp1.Admin
{
    partial class ResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPassword));
            this.label1 = new System.Windows.Forms.Label();
            this.btnForgotPass = new RoundedButton();
            this.txtForgotPass = new RoundedTextBox();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.forgotpassPanel = new System.Windows.Forms.Panel();
            this.panelCode = new System.Windows.Forms.Panel();
            this.btnSend = new RoundedButton();
            this.txtCode = new RoundedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelNewPass = new System.Windows.Forms.Panel();
            this.btnSubmit = new RoundedButton();
            this.txtNewPass = new RoundedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmPass = new RoundedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelDisplay.SuspendLayout();
            this.forgotpassPanel.SuspendLayout();
            this.panelCode.SuspendLayout();
            this.panelNewPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(28, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter Email";
            // 
            // btnForgotPass
            // 
            this.btnForgotPass.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnForgotPass.BorderColor = System.Drawing.Color.Transparent;
            this.btnForgotPass.BorderRadius = 20;
            this.btnForgotPass.BorderSize = 0;
            this.btnForgotPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForgotPass.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgotPass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnForgotPass.Location = new System.Drawing.Point(129, 150);
            this.btnForgotPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnForgotPass.Name = "btnForgotPass";
            this.btnForgotPass.Size = new System.Drawing.Size(138, 39);
            this.btnForgotPass.TabIndex = 4;
            this.btnForgotPass.Text = "Send code";
            this.btnForgotPass.UseVisualStyleBackColor = false;
            this.btnForgotPass.Click += new System.EventHandler(this.btnForgotPass_Click);
            // 
            // txtForgotPass
            // 
            this.txtForgotPass.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.txtForgotPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtForgotPass.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtForgotPass.ForeColor = System.Drawing.SystemColors.Info;
            this.txtForgotPass.Location = new System.Drawing.Point(32, 82);
            this.txtForgotPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtForgotPass.Multiline = true;
            this.txtForgotPass.Name = "txtForgotPass";
            this.txtForgotPass.Size = new System.Drawing.Size(311, 40);
            this.txtForgotPass.TabIndex = 3;
            // 
            // panelDisplay
            // 
            this.panelDisplay.BackColor = System.Drawing.Color.Transparent;
            this.panelDisplay.Controls.Add(this.label5);
            this.panelDisplay.Controls.Add(this.panelNewPass);
            this.panelDisplay.Controls.Add(this.panelCode);
            this.panelDisplay.Controls.Add(this.forgotpassPanel);
            this.panelDisplay.Location = new System.Drawing.Point(12, 12);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(398, 426);
            this.panelDisplay.TabIndex = 6;
            // 
            // forgotpassPanel
            // 
            this.forgotpassPanel.Controls.Add(this.btnForgotPass);
            this.forgotpassPanel.Controls.Add(this.txtForgotPass);
            this.forgotpassPanel.Controls.Add(this.label1);
            this.forgotpassPanel.Location = new System.Drawing.Point(18, 124);
            this.forgotpassPanel.Name = "forgotpassPanel";
            this.forgotpassPanel.Size = new System.Drawing.Size(362, 255);
            this.forgotpassPanel.TabIndex = 6;
            // 
            // panelCode
            // 
            this.panelCode.Controls.Add(this.btnSend);
            this.panelCode.Controls.Add(this.txtCode);
            this.panelCode.Controls.Add(this.label2);
            this.panelCode.Location = new System.Drawing.Point(18, 124);
            this.panelCode.Name = "panelCode";
            this.panelCode.Size = new System.Drawing.Size(362, 255);
            this.panelCode.TabIndex = 7;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSend.BorderColor = System.Drawing.Color.Transparent;
            this.btnSend.BorderRadius = 20;
            this.btnSend.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSend.Location = new System.Drawing.Point(129, 150);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(138, 39);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Enter Code";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCode.Location = new System.Drawing.Point(32, 82);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(311, 40);
            this.txtCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(28, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter your code";
            // 
            // panelNewPass
            // 
            this.panelNewPass.Controls.Add(this.txtConfirmPass);
            this.panelNewPass.Controls.Add(this.label4);
            this.panelNewPass.Controls.Add(this.btnSubmit);
            this.panelNewPass.Controls.Add(this.txtNewPass);
            this.panelNewPass.Controls.Add(this.label3);
            this.panelNewPass.Location = new System.Drawing.Point(18, 101);
            this.panelNewPass.Name = "panelNewPass";
            this.panelNewPass.Size = new System.Drawing.Size(362, 296);
            this.panelNewPass.TabIndex = 8;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSubmit.BorderColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BorderRadius = 20;
            this.btnSubmit.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubmit.Location = new System.Drawing.Point(128, 234);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(138, 39);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtNewPass
            // 
            this.txtNewPass.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.txtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewPass.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.ForeColor = System.Drawing.SystemColors.Info;
            this.txtNewPass.Location = new System.Drawing.Point(32, 82);
            this.txtNewPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewPass.Multiline = true;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(311, 40);
            this.txtNewPass.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(28, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "New Password";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.txtConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPass.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPass.ForeColor = System.Drawing.SystemColors.Info;
            this.txtConfirmPass.Location = new System.Drawing.Point(32, 167);
            this.txtConfirmPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfirmPass.Multiline = true;
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(311, 40);
            this.txtConfirmPass.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(28, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Confirm Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(73, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Reset your password";
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(418, 450);
            this.Controls.Add(this.panelDisplay);
            this.Name = "ResetPassword";
            this.Text = "ResetPassword";
            this.panelDisplay.ResumeLayout(false);
            this.panelDisplay.PerformLayout();
            this.forgotpassPanel.ResumeLayout(false);
            this.forgotpassPanel.PerformLayout();
            this.panelCode.ResumeLayout(false);
            this.panelCode.PerformLayout();
            this.panelNewPass.ResumeLayout(false);
            this.panelNewPass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private RoundedButton btnForgotPass;
        public RoundedTextBox txtForgotPass;
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.Panel forgotpassPanel;
        private System.Windows.Forms.Panel panelCode;
        private RoundedButton btnSend;
        public RoundedTextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelNewPass;
        public RoundedTextBox txtConfirmPass;
        private System.Windows.Forms.Label label4;
        private RoundedButton btnSubmit;
        public RoundedTextBox txtNewPass;
        private System.Windows.Forms.Label label3;
    }
}
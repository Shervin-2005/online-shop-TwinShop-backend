namespace Shop.UI.User.UI
{
    partial class VerifyCode
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
            components = new System.ComponentModel.Container();
            txtCode = new TextBox();
            btnEnterCode = new Button();
            lblTimer = new Label();
            OtpTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // txtCode
            // 
            txtCode.Location = new Point(41, 31);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(158, 23);
            txtCode.TabIndex = 0;
            // 
            // btnEnterCode
            // 
            btnEnterCode.Location = new Point(83, 60);
            btnEnterCode.Name = "btnEnterCode";
            btnEnterCode.Size = new Size(75, 23);
            btnEnterCode.TabIndex = 1;
            btnEnterCode.Text = "Enter Code";
            btnEnterCode.UseVisualStyleBackColor = true;
            btnEnterCode.Click += btnEnterCode_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(104, 86);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(28, 15);
            lblTimer.TabIndex = 2;
            lblTimer.Text = "0:00";
            // 
            // OtpTimer
            // 
            OtpTimer.Interval = 1000;
            OtpTimer.Tick += Otptimer_Tick;
            // 
            // VerifyCode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(253, 124);
            Controls.Add(lblTimer);
            Controls.Add(btnEnterCode);
            Controls.Add(txtCode);
            Name = "VerifyCode";
            Text = "VerifyCode";
            Load += VerifyCode_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCode;
        private Button btnEnterCode;
        private Label lblTimer;
        private System.Windows.Forms.Timer OtpTimer;
    }
}
namespace Client
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlAlternateLoginMethods = new System.Windows.Forms.Panel();
            this.chbRemember = new System.Windows.Forms.CheckBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.parAppNet = new Client.SignInWith();
            this.signInWith1 = new Client.SignInWith();
            this.txtPassword = new Client.TitledTextbox();
            this.txtUsername = new Client.TitledTextbox();
            this.pnlRoot.SuspendLayout();
            this.pnlAlternateLoginMethods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRoot
            // 
            this.pnlRoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRoot.Controls.Add(this.pnlAlternateLoginMethods);
            this.pnlRoot.Controls.Add(this.txtPassword);
            this.pnlRoot.Controls.Add(this.txtUsername);
            this.pnlRoot.Controls.Add(this.chbRemember);
            this.pnlRoot.Controls.Add(this.picHeader);
            this.pnlRoot.Controls.Add(this.btnCancel);
            this.pnlRoot.Controls.Add(this.btnOK);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Size = new System.Drawing.Size(297, 229);
            this.pnlRoot.TabIndex = 0;
            this.pnlRoot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseDown);
            // 
            // pnlAlternateLoginMethods
            // 
            this.pnlAlternateLoginMethods.Controls.Add(this.parAppNet);
            this.pnlAlternateLoginMethods.Controls.Add(this.signInWith1);
            this.pnlAlternateLoginMethods.Location = new System.Drawing.Point(12, 47);
            this.pnlAlternateLoginMethods.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAlternateLoginMethods.Name = "pnlAlternateLoginMethods";
            this.pnlAlternateLoginMethods.Size = new System.Drawing.Size(275, 67);
            this.pnlAlternateLoginMethods.TabIndex = 19;
            // 
            // chbRemember
            // 
            this.chbRemember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbRemember.AutoSize = true;
            this.chbRemember.Checked = true;
            this.chbRemember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRemember.Location = new System.Drawing.Point(12, 174);
            this.chbRemember.Name = "chbRemember";
            this.chbRemember.Size = new System.Drawing.Size(95, 17);
            this.chbRemember.TabIndex = 16;
            this.chbRemember.Text = "Remember Me";
            this.chbRemember.UseVisualStyleBackColor = true;
            // 
            // picHeader
            // 
            this.picHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picHeader.Image = ((System.Drawing.Image)(resources.GetObject("picHeader.Image")));
            this.picHeader.Location = new System.Drawing.Point(12, 6);
            this.picHeader.Margin = new System.Windows.Forms.Padding(0);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(275, 35);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHeader.TabIndex = 15;
            this.picHeader.TabStop = false;
            this.picHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(207, 192);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(121, 192);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "Login";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // parAppNet
            // 
            this.parAppNet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parAppNet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.parAppNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parAppNet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parAppNet.Location = new System.Drawing.Point(0, 36);
            this.parAppNet.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.parAppNet.Name = "parAppNet";
            this.parAppNet.ServiceIcon = ((System.Drawing.Bitmap)(resources.GetObject("parAppNet.ServiceIcon")));
            this.parAppNet.ServiceName = "Git";
            this.parAppNet.Size = new System.Drawing.Size(275, 30);
            this.parAppNet.TabIndex = 10;
            this.parAppNet.TabStop = false;
            // 
            // signInWith1
            // 
            this.signInWith1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signInWith1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(80)))), ((int)(((byte)(129)))));
            this.signInWith1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signInWith1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signInWith1.Location = new System.Drawing.Point(0, 0);
            this.signInWith1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.signInWith1.Name = "signInWith1";
            this.signInWith1.ServiceIcon = ((System.Drawing.Bitmap)(resources.GetObject("signInWith1.ServiceIcon")));
            this.signInWith1.ServiceName = "Bitbucket";
            this.signInWith1.Size = new System.Drawing.Size(275, 30);
            this.signInWith1.TabIndex = 9;
            this.signInWith1.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.DefaultText = "Password";
            this.txtPassword.DefaultTextColor = System.Drawing.Color.Gray;
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(12, 148);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.NonDefaultTextColor = System.Drawing.Color.Black;
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.ShowingDefaultText = true;
            this.txtPassword.Size = new System.Drawing.Size(275, 20);
            this.txtPassword.TabIndex = 18;
            this.txtPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.DefaultText = "Login";
            this.txtUsername.DefaultTextColor = System.Drawing.Color.Gray;
            this.txtUsername.ForeColor = System.Drawing.Color.Gray;
            this.txtUsername.Location = new System.Drawing.Point(12, 122);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.NonDefaultTextColor = System.Drawing.Color.Black;
            this.txtUsername.ShowingDefaultText = true;
            this.txtUsername.Size = new System.Drawing.Size(275, 20);
            this.txtUsername.TabIndex = 17;
            this.txtUsername.Text = "Login";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(297, 229);
            this.Controls.Add(this.pnlRoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormLogin_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseDown);
            this.pnlRoot.ResumeLayout(false);
            this.pnlRoot.PerformLayout();
            this.pnlAlternateLoginMethods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Panel pnlAlternateLoginMethods;
        private SignInWith parAppNet;
        private SignInWith signInWith1;
        private TitledTextbox txtPassword;
        private TitledTextbox txtUsername;
        private System.Windows.Forms.CheckBox chbRemember;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
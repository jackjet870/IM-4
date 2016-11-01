namespace Dual_Client_Test
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.btnSend1 = new System.Windows.Forms.Button();
            this.txtConversation1 = new System.Windows.Forms.TextBox();
            this.txtMessage1 = new System.Windows.Forms.TextBox();
            this.btnSend2 = new System.Windows.Forms.Button();
            this.txtConversation2 = new System.Windows.Forms.TextBox();
            this.txtMessage2 = new System.Windows.Forms.TextBox();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.btnSend1);
            this.splitMain.Panel1.Controls.Add(this.txtConversation1);
            this.splitMain.Panel1.Controls.Add(this.txtMessage1);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.btnSend2);
            this.splitMain.Panel2.Controls.Add(this.txtConversation2);
            this.splitMain.Panel2.Controls.Add(this.txtMessage2);
            this.splitMain.Size = new System.Drawing.Size(1191, 606);
            this.splitMain.SplitterDistance = 595;
            this.splitMain.TabIndex = 0;
            // 
            // btnSend1
            // 
            this.btnSend1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSend1.BackgroundImage")));
            this.btnSend1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend1.Location = new System.Drawing.Point(531, 552);
            this.btnSend1.Name = "btnSend1";
            this.btnSend1.Size = new System.Drawing.Size(61, 51);
            this.btnSend1.TabIndex = 2;
            this.btnSend1.UseVisualStyleBackColor = true;
            this.btnSend1.Click += new System.EventHandler(this.btnSend1_Click);
            // 
            // txtConversation1
            // 
            this.txtConversation1.Location = new System.Drawing.Point(3, 3);
            this.txtConversation1.Multiline = true;
            this.txtConversation1.Name = "txtConversation1";
            this.txtConversation1.ReadOnly = true;
            this.txtConversation1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConversation1.Size = new System.Drawing.Size(589, 543);
            this.txtConversation1.TabIndex = 1;
            // 
            // txtMessage1
            // 
            this.txtMessage1.Location = new System.Drawing.Point(3, 552);
            this.txtMessage1.Multiline = true;
            this.txtMessage1.Name = "txtMessage1";
            this.txtMessage1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage1.Size = new System.Drawing.Size(522, 51);
            this.txtMessage1.TabIndex = 0;
            this.txtMessage1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage1_KeyDown);
            // 
            // btnSend2
            // 
            this.btnSend2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSend2.BackgroundImage")));
            this.btnSend2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend2.Location = new System.Drawing.Point(528, 552);
            this.btnSend2.Name = "btnSend2";
            this.btnSend2.Size = new System.Drawing.Size(61, 51);
            this.btnSend2.TabIndex = 3;
            this.btnSend2.UseVisualStyleBackColor = true;
            this.btnSend2.Click += new System.EventHandler(this.btnSend2_Click);
            // 
            // txtConversation2
            // 
            this.txtConversation2.Location = new System.Drawing.Point(3, 3);
            this.txtConversation2.Multiline = true;
            this.txtConversation2.Name = "txtConversation2";
            this.txtConversation2.ReadOnly = true;
            this.txtConversation2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConversation2.Size = new System.Drawing.Size(586, 543);
            this.txtConversation2.TabIndex = 3;
            this.txtConversation2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConversation2_KeyDown);
            // 
            // txtMessage2
            // 
            this.txtMessage2.Location = new System.Drawing.Point(3, 552);
            this.txtMessage2.Multiline = true;
            this.txtMessage2.Name = "txtMessage2";
            this.txtMessage2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage2.Size = new System.Drawing.Size(519, 51);
            this.txtMessage2.TabIndex = 2;
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 606);
            this.Controls.Add(this.splitMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "ChatBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TextBox txtMessage1;
        private System.Windows.Forms.TextBox txtConversation1;
        private System.Windows.Forms.TextBox txtConversation2;
        private System.Windows.Forms.TextBox txtMessage2;
        private System.Windows.Forms.Button btnSend1;
        private System.Windows.Forms.Button btnSend2;
        private System.Windows.Forms.Timer tmrRefresh;
    }
}


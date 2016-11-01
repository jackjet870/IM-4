using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class TitledTextbox : TextBox
    {
        private string _defaultText;
        public string DefaultText
        {
            get { return this._defaultText; }
            set
            {
                if (this.ShowingDefaultText)
                {
                    this.Text = this._defaultText;
                }

                this._defaultText = value;
            }
        }
        
        public new char PasswordChar { get; set; }

        public bool ShowingDefaultText
        {
            get
            {
                return this.ForeColor == this.DefaultTextColor &&
                    this.Text == this.DefaultText;
            }
            set
            {
                this.ForeColor = this.DefaultTextColor;
                this.Text = this.DefaultText;
            }
        }

        public Color DefaultTextColor { get; set; }

        public Color NonDefaultTextColor { get; set; }

        public TitledTextbox() : this("Default") { }

        public TitledTextbox(string defaultText)
        {
            this.Enter += OnEnter;
            this.Leave += OnLeave;

            this.DefaultText = defaultText;

            this.Text = defaultText;

            this.ForeColor = this.DefaultTextColor;

            this.DefaultTextColor = Color.Gray;

            this.NonDefaultTextColor = Color.Black;
        }
        
        private void OnEnter(object sender, EventArgs eventArgs)
        {
            if (this.ShowingDefaultText)
            {
                this.ForeColor = this.NonDefaultTextColor;

                this.Text = string.Empty;

                base.PasswordChar = this.PasswordChar;
            }
        }

        private void OnLeave(object sender, EventArgs eventArgs)
        {
            if (this.Text == string.Empty)
            {
                this.ForeColor = this.DefaultTextColor;

                this.Text = this.DefaultText;

                base.PasswordChar = '\0'; // Empty
            }
        }
    }
}

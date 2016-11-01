using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class SignInWith : UserControl
    {
        /*
         Active Directory - windows logins
         App.net - one login, many apps
         Bitbucket - code repo
         Dropbox - file sharing
         Facebook - social service
         Flickr - picture sharing
         Foursquare - location sharing (places to go)
         GitHub - code repo
         Google - Social service, video sharing and email provider. Provides services to businesses
         Instagram - social service
         LinkedIn - social service for business
         Microsoft - product management services for microsoft and email provider.
         Odnoklassniki - social service (russian)
         OpenID - one login, many apps
         Pinterest - picture sharing
         Reddit - social service
         SoundCloud - music sharing
         Tumblr - social service
         Twitter - social service
         Vimeo - video sharing
         VK - social service (russian)
         Yahoo! - email provider
        */

        public new Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;

                // If new BackColor is dark, set font to white else set font to black
                this.label1.ForeColor = value.GetBrightness() < 0.9 ? Color.White : Color.Black;
            }
        }

        public string ServiceName
        {
            get
            {
                return this.label1.Text.Substring(this.label1.Text.LastIndexOf(' ') + 1);
            }
            set
            {
                this.label1.Text = "Sign in with " + value;
            }
        }

        public Bitmap ServiceIcon
        {
            get
            {
                return (Bitmap)this.pictureBox1.Image;
            }
            set
            {
                this.pictureBox1.Image = value;
            }
        }

        public SignInWith()
        {
            InitializeComponent();

            this.Cursor = Cursors.Hand;
        }

        public SignInWith(Bitmap serviceLogo, Color backgroundColor, string serviceName) : this()
        {
            this.pictureBox1.Image = serviceLogo;

            this.ServiceName = serviceName;

            this.BackColor = backgroundColor;
        }

        private void SignInWith_Resize(object sender, System.EventArgs e)
        {
            SuspendLayout();

            this.pictureBox1.Size = new Size(this.Height, this.Height);

            this.label1.Size = new Size(this.Width - (this.pictureBox1.Width + 6), this.Height);

            ResumeLayout(true);
        }
    }
}

using System;

namespace FinalHttpFramework
{
    class Message
    {
        public string UserFrom { get; }

        public string UserTo { get; }

        public string Contents { get; }

        public DateTime SentAt { get; }

        public Message(string userFrom, string userTo, string contents)
        {
            this.UserFrom = userFrom;
            this.UserTo = userTo;
            this.Contents = contents;
            this.SentAt = DateTime.Now;
        }

        public Message(string userFrom, string userTo, string contents, DateTime sentAt)
        {
            this.UserFrom = userFrom;
            this.UserTo = userTo;
            this.Contents = contents;
            this.SentAt = sentAt;
        }

        public override string ToString()
        {
            return "From: " + this.UserFrom + ", To: " + this.UserTo + ", Sent At: " + this.SentAt.ToShortDateString() +
                   ", " + this.SentAt.ToShortTimeString() +
                   Environment.NewLine + this.Contents;
        }
    }
}

using FinalHttpFramework;
using System.IO;
using System.Net;

namespace Client
{
    public static class HttpClient
    {
        public static string SendData(string dataToSend, string fullTargetAddress)
        {
            return SendData(dataToSend.ToWebBytes(), fullTargetAddress).WebBytesToString();
        }

        public static byte[] SendData(byte[] dataToSend, string fullTargetAddress)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullTargetAddress);

            request.Timeout = 15000;
            request.ContinueTimeout = 15000;
            request.ReadWriteTimeout = 15000;
            request.ReadWriteTimeout = 15000;

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dataToSend.Length;
            
            using (Stream writer = request.GetRequestStream())
            {
                writer.Write(dataToSend, 0, dataToSend.Length);
            }
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();

            if (responseStream != null && response.ContentLength >= 0)
            {
                using (Stream reader = responseStream)
                {
                    byte[] returnBytes = new byte[response.ContentLength];
                    reader.Read(returnBytes, 0, returnBytes.Length);

                    return returnBytes;
                }
            }
            
            return new byte[0];
        }

        public static byte[] GetData(string fullTargetAddress)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullTargetAddress);

            request.Timeout = 15000;
            request.ContinueTimeout = 15000;
            request.ReadWriteTimeout = 15000;

            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            
            if (responseStream != null)
            {
                using (Stream reader = responseStream)
                {
                    byte[] returnBytes = new byte[response.ContentLength];

                    reader.Read(returnBytes, 0, returnBytes.Length);
                }
            }

            return new byte[0];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections;
using System.Threading;
using System.Timers;

namespace DoubanFM
{
    public class DownloadFile
    {
        string remoteFilePath;
        string localFilePath;

        public DownloadFile(string remoteFilePath, string localFilePath)
        {
            this.remoteFilePath = remoteFilePath;
            this.localFilePath = localFilePath;
        }

        public void DownloadFile(object inDelegate)
        {

            WebRequest wreq = WebRequest.Create(remoteFilePath);
            WebResponse wresp = wreq.GetResponse();
            Stream respStream = wresp.GetResponseStream();
            int length = (int)wresp.ContentLength;
            BinaryReader br = new BinaryReader(respStream);
            FileStream fs;

            fs = File.Create(localFilePath);
            fs.Write(br.ReadBytes(length), 0, length);

            br.Close();
            fs.Close();

            Form1.CallBackDelegate myDelegate = inDelegate as Form1.CallBackDelegate;
            myDelegate(true);

        }
    }
}

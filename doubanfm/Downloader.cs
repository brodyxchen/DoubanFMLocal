using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.ComponentModel;

namespace DoubanFM
{
        
    public class DownloadFileInfo
    {
        
        public string remotePath { get; set; }
        public string localPath { get; set; }
        public CallbackMethodDelegate callbackMethod { get; set; }

        public DownloadFileInfo(string remotePath, string localPath, CallbackMethodDelegate callbackMethod)
        {
            this.remotePath = remotePath;
            this.localPath = localPath;
            this.callbackMethod = callbackMethod;
        }
    }

    public class Downloader
    {
        BackgroundWorker worker;
        Queue<DownloadFileInfo> awaitQueue;
        Queue<DownloadFileInfo> completedQueue;
        DownloadFileInfo downloadingFile;


        public Downloader()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += new DoWorkEventHandler(DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(UpdateProgress);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);
            

            awaitQueue = new Queue<DownloadFileInfo>();
            completedQueue = new Queue<DownloadFileInfo>();

            
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            while (awaitQueue.Count > 0)
            {
                if (worker.CancellationPending)
                {
                    return;
                }

                downloadingFile = awaitQueue.Dequeue();

                CheckDirectory();
                DownloadCore();

                completedQueue.Enqueue(downloadingFile);
                worker.ReportProgress(1);
            }

        }

        private void UpdateProgress(object sender, ProgressChangedEventArgs e)
        {

            DownloadFileInfo doneFile = completedQueue.Dequeue();
            Console.WriteLine("downloaded one : " + doneFile.localPath);

            downloadingFile.callbackMethod(doneFile.localPath);
        }

        private void CompletedWork(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        public void PushBack(string remotePath, string localPath, CallbackMethodDelegate callbackMethod)
        {
            awaitQueue.Enqueue(new DownloadFileInfo(remotePath, localPath, callbackMethod));
        }

        public void Start()
        {
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        public void Stop()
        {
            worker.CancelAsync();
        }

        public void Clear()
        {
            awaitQueue.Clear();
            completedQueue.Clear();
        }

        public int DownloadCore()
        {

            WebRequest wreq = WebRequest.Create(downloadingFile.remotePath);
            WebResponse wresp = wreq.GetResponse();
            Stream respStream = wresp.GetResponseStream();
            int length = (int)wresp.ContentLength;
            BinaryReader br = new BinaryReader(respStream);
            FileStream fs;

            fs = File.Create(downloadingFile.localPath);
            fs.Write(br.ReadBytes(length), 0, length);

            br.Close();
            fs.Close();

            return 1;
        }


        public void CheckDirectory()
        {
            string folderPath = Path.GetDirectoryName(downloadingFile.localPath);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}

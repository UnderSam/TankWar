using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;
using System.Threading;
using System.IO;

namespace server
{
    class Program
    {
        static int Count;
        static int numberOfClient = 0;
        static TcpClient[] clientSocket = new TcpClient[100];
        static bool isOver = false;
        static bool isStart = false;
        static int MapNum;
        static int playerInitLoc;
        static Random rdm = new Random();
        static void Main(string[] args)
        {
            Count = 0;
            TcpListener serverSocket = new TcpListener(9487);  //server的socket(listener)
            serverSocket.Start();
            Console.WriteLine("等待連線中......");

            BackgroundWorker[] bw = new BackgroundWorker[100]; // 一個bkw階一個client

            TcpClient tempclient;  //accept的東西丟到tempclient

            while (true)
            {
                if (Count == 0)
                {
                    isStart = false;
                    MapNum = rdm.Next(1, 3);
                }

                //開背景執行
                bw[numberOfClient] = new BackgroundWorker();
                bw[numberOfClient].WorkerReportsProgress = true; // 沒用到
                bw[numberOfClient].WorkerSupportsCancellation = true; //可以終止這個worker
                bw[numberOfClient].DoWork += Bw_DoWork; //可以寫response  如果觸發就去progress
                bw[numberOfClient].ProgressChanged += Bw_ProgressChanged;  // +=會自己變出thread函氏
                bw[numberOfClient].RunWorkerCompleted += Bw_RunWorkerCompleted;
                //接client
                tempclient = serverSocket.AcceptTcpClient();
                clientSocket[numberOfClient] = tempclient;
                Console.WriteLine("連到囉");
                Thread.Sleep(1000);
                if (tempclient.Connected)  //判斷是否有連到
                {
                    StreamWriter swInit = new StreamWriter(clientSocket[numberOfClient].GetStream());
                    string init = Convert.ToString(Count) + Convert.ToString(MapNum);
                    swInit.WriteLine(init);
                    swInit.Flush();
                    Console.WriteLine(Count);
                    Console.WriteLine("you send initMessage:" + init);
                    bw[numberOfClient].RunWorkerAsync(clientSocket[numberOfClient]); //讀到這行就開始坐do work的事情
                    numberOfClient++;
                    Count++;
                    if(Count==2)
                    {
                        for(int i=0;i<numberOfClient;i++)
                        {
                            StreamWriter start = new StreamWriter(clientSocket[i].GetStream());
                            start.WriteLine("yes");
                            start.Flush();
                        }
                        Count = 0;
                    }
                   
                }
            }
        }

        private static void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private static void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private static void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backw = sender as BackgroundWorker;
            TcpClient tempclient = e.Argument as TcpClient;
            while (true)
            {
                if (backw.CancellationPending == true || isOver == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    NetworkStream networkStream = tempclient.GetStream();
                    StreamReader sr = new StreamReader(networkStream);
                    string data = sr.ReadLine();
                    string response;
                    if (data[0] == '1') //送equip座標和type
                    {
                        Console.WriteLine("client:" + data);
                        response = data + Convert.ToString(rdm.Next(5, 7));
                        for (int i = 0; i < numberOfClient; i++) //全送
                        {
                            NetworkStream tempStream = clientSocket[i].GetStream();
                            StreamWriter sw = new StreamWriter(tempStream);
                            sw.WriteLine(response);
                            tempStream.Flush();
                            sw.Flush();
                        }
                        Console.WriteLine(">>" + "response message(all):"+response);
                    }
                    else
                    {
                        if (data == "end")
                        {
                            isOver = true;
                        }
                        Console.WriteLine("client:" + data);
                        response = "response message:" + data;
                        for (int i = 0; i < numberOfClient; i++)
                        {
                            if (clientSocket[i] != tempclient)
                            {
                                NetworkStream tempStream = clientSocket[i].GetStream();
                                StreamWriter sw = new StreamWriter(tempStream);
                                sw.WriteLine(data);
                                if (isOver)
                                {
                                    clientSocket[i].Close();
                                }
                                tempStream.Flush();
                                sw.Flush();
                            }
                        }
                        Console.WriteLine(">>" + response);
                    }
                }
            }

        }
    }
}

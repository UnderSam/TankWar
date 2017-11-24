using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankWar.Properties;

//playerTank(int colors,int x,int y,int speed,int life,Direction dir)
namespace TankWar
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //剛開始會由startform改變playernum
            InitializeComponent();
            Singleton.Instance.ScoreSumOfSingle = 0;
            InitGame();
            if (serverNoap)
            {
                Singleton.Instance.Cancel_for_Form1 = true;
                this.Close();
            }
            Singleton.Instance.GameIsOver = false;
            this.KeyPreview = true;
        }

        TcpClient clientSocket = new TcpClient();
        NetworkStream networkStream;
        private static string address;
        private StreamReader sr;
        private StreamWriter sw;
        private bool isConnected = false;
        private string P2control;
        private Random rdm = new Random();
        private int controlTime;
        private int n = 0;
        private bool triger = false;
        private bool isStart = false;
        private int enemySetType;
        private string[] equipLoc = new string[4];
        private int Enumber = 12;
        private string pass;
        int OtherPlayerTag;
        private bool serverNoap = false;
        Graphics g;
        Thread newThred;
        int SinglePlayerTag;
        string hi;
        //private int xpose = 200,ypose=220;
        private static Image Etank = Resources.Enemy_flag;
        private static Image select = Resources.gray12;
        private static Image gameWin = Resources.you_win;
        private static Image gameOver = Resources.you_lose;
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(780, 720);
        }
      
        private void InitGame()
        {
            Singleton.Instance.Cancel_for_Form1 = false;
            controlTime = 0;
            if(Singleton.Instance.PlayerNum==1) 
            {
                Singleton.Instance.IsMapNum = rdm.Next(1, 3);
                Singleton.Instance.initialMap();
                SinglePlayerTag = 0;
                label1.Visible = false;
                isStart = false;
                triger = false;
                Enumber = 12;
                n = 0;
                Singleton.Instance.Player_win[SinglePlayerTag] = false;
                player2Hp.Visible = false;
                player2Flag.Visible = false;
                scoreSing2.Text = Convert.ToString(Singleton.Instance.ScoreSumOfSingle);
                initPlayer();
                liveCount.Text = Convert.ToString(Singleton.Instance.GetSingleplayerLives);
            }
            else if(Singleton.Instance.PlayerNum == 2)
            {
               
                isStart = false;
                initMulti();
                while (serverNoap)
                    return;
                Singleton.Instance.initialMap();
                Enumber = 0;
                Singleton.Instance.IsCreateEquip = false;
                Singleton.Instance.Player_win[0] = false;
                Singleton.Instance.Player_win[1] = false;
                liveFlag.Visible = false;
                liveCount.Visible = false;
                label1.Visible = true;
                player2Hp.Visible = true;
                player2Flag.Visible = true;
                enemyFlag.Visible = false;
                enemyCount.Visible = false;
                scoreSing1.Visible = false;
                scoreSing2.Visible = false;
                initPlayer();
            }
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            //label2.Text = Convert.ToString(SinglePlayerTag);
            if (Singleton.Instance.PlayerNum == 1)
            {
                if (Singleton.Instance.GameIsOver == false)
                {
                    Singleton.Instance.Draw_Map(e.Graphics);
                    Singleton.Instance.Draw(e.Graphics);
                    player1Hp.Text = Convert.ToString(Singleton.Instance.getP1hp());
                    scoreSing2.Text = Convert.ToString(Singleton.Instance.ScoreSumOfSingle);
                    liveCount.Text = Convert.ToString(Singleton.Instance.GetSingleplayerLives);
                    e.Dispose();
                }
                else if (Singleton.Instance.GameIsOver == true && Singleton.Instance.getP1hp() <= 0)
                {
                    Graphics g = e.Graphics;
                    g.DrawImage(gameOver, 210, 280);
                    escapeTo.Visible = true;
                    timer.Stop();
                }
                else if(Singleton.Instance.GameIsOver == true && Singleton.Instance.Player_win[SinglePlayerTag]==true)
                {
                    Graphics g = e.Graphics;
                    g.DrawImage(gameWin, 210, 280);
                    escapeTo.Visible = true;
                    timer.Stop();
                }
            }
            else if(Singleton.Instance.PlayerNum==2)
            {
                player1Hp.Text = Convert.ToString(Singleton.Instance.getP1hp());
                player2Hp.Text = Convert.ToString(Singleton.Instance.getP2hp());
                label1.Text = "P" + Convert.ToString(SinglePlayerTag + 1);
                if (Singleton.Instance.GameIsOver == false && Singleton.Instance.Player_win[SinglePlayerTag] == false)
                {
                    Singleton.Instance.Draw_Map(e.Graphics);
                    Singleton.Instance.Draw(e.Graphics);
                    e.Dispose();
                }

                if (Singleton.Instance.GameIsOver == true && Singleton.Instance.Player_win[SinglePlayerTag] == false)
                {
                    Singleton.Instance.Draw_Map(e.Graphics);
                    Singleton.Instance.Draw(e.Graphics);
                    Graphics g = e.Graphics;
                    g.DrawImage(gameOver, 220, 280);
                    escapeTo.Visible = true;
                    timer.Stop();
                }
                else if (Singleton.Instance.GameIsOver == true && Singleton.Instance.Player_win[SinglePlayerTag] == true)
                {
                    Singleton.Instance.Draw_Map(e.Graphics);
                    Singleton.Instance.Draw(e.Graphics);
                    Graphics g = e.Graphics;
                    g.DrawImage(gameWin, 110, 180);
                    timer.Stop();
                    escapeTo.Visible = true;
                }
            }
        }
        private void isKeyDown(object sender, KeyEventArgs e)
        {
            if (isStart == true)
            {
                if (Singleton.Instance.PlayerNum == 2 && e.KeyCode == Keys.Escape)  //多人模式中棄權
                {
                    Singleton.Instance.GameIsOver = true;
                    newThred.Abort();
                    this.Close();
                    return;
                }
                if (e.KeyCode == Keys.Escape && Singleton.Instance.GameIsOver == true)
                {
                    this.Close();
                }
                if (Singleton.Instance.GameIsOver == true)
                    return;
                Singleton.Instance.GetPlayer(SinglePlayerTag).Keydown(e);
                if (Singleton.Instance.PlayerNum == 2)
                {
                    if (e.KeyCode != Keys.Space)
                        pass = "0" + Convert.ToString(e.KeyCode) + "1";
                    else
                    {
                        pass = "0F";
                    }
                    sw.WriteLine(pass);
                    sw.Flush();
                }
                if (e.KeyCode == Keys.Escape && Singleton.Instance.PlayerNum == 1)  //單人遊戲的暫停選單
                {
                    //this.Close();
                    controlTime++;
                    if (controlTime % 2 != 0)
                    {
                        triger = true;
                        g = panel.CreateGraphics();
                        g.DrawImage(select, 200, 220);
                        timer.Stop();
                    }
                    else
                        timer.Start();
                }
            }
        }
        private void isKeyUp(object sender, KeyEventArgs e)
        {
            if (isStart == true)
            {
                if (Singleton.Instance.GameIsOver == true)
                    return;
                Singleton.Instance.GetPlayer(SinglePlayerTag).KeyUp(e);
                if (Singleton.Instance.PlayerNum == 2)
                {
                    if (e.KeyCode != Keys.Space)
                        pass = "0" + Convert.ToString(e.KeyCode) + "0";
                    else
                    {
                        pass = "n";
                    }
                    sw.WriteLine(pass);
                    sw.Flush();
                }
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {

            //label2.Text = P2control;
            if (isStart == true)
            {
                if (Singleton.Instance.PlayerNum == 1)
                {
                    Singleton.Instance.CreateThread();
                    setEnemy();
                    enemyCount.Text = Convert.ToString(Enumber + Singleton.Instance.count);
                }
                else
                {
                    Singleton.Instance.Thread_for_Multi();
                    if (Singleton.Instance.IsCreateEquip)
                    {
                        try
                        {
                            sw.WriteLine(Singleton.Instance.PassMap);
                            sw.Flush();
                            Singleton.Instance.IsCreateEquip = false;
                        }
                        catch
                        {
                            MessageBox.Show("server is down");
                        }
                    }
                    if (Singleton.Instance.GameIsOver == false)
                    {
                        int locX = Singleton.Instance.GetPlayer(SinglePlayerTag).X;
                        int locY = Singleton.Instance.GetPlayer(SinglePlayerTag).Y;
                        int locD = (int)Singleton.Instance.GetPlayer(SinglePlayerTag).dir;
                        string packet = "2/" + locX.ToString() + "/" + locY.ToString() + "/" + locD.ToString();
                        try
                        {
                            sw.WriteLine(packet);
                            sw.Flush();
                        }
                        catch
                        {
                            MessageBox.Show("server is down");
                        }
                    }
                    if (Singleton.Instance.GameIsOver == true)
                    {
                        try
                        {
                            sw.WriteLine("end");
                            sw.Flush();
                        }
                        catch
                        {
                            MessageBox.Show("server is down");
                        }
                    }
                }
            }
              panel.Invalidate();
        }
        private void setEnemy()
        {
            if (!isStart && Singleton.Instance.PlayerNum==1)
            {
                if (n < 3)
                {
                    switch (enemySetType)
                    {
                        case 1:
                            switch (rdm.Next(0, 2)) {
                                case 0:
                                    Singleton.Instance.AddElement(new Enemy(600, 0, 1, Direction.left));
                                    break;
                                case 1:
                                    Singleton.Instance.AddElement(new Enemy(0, 600, 1, Direction.right));
                                    break;
                                case 2:
                                    Singleton.Instance.AddElement(new Enemy(600, 600, 1, Direction.left));
                                    break;
                            }
                            break;
                        case 2:
                            switch (rdm.Next(0, 2))
                            {
                                case 0:
                                    Singleton.Instance.AddElement(new Enemy(600, 0, 1, Direction.left));
                                    break;
                                case 1:
                                    Singleton.Instance.AddElement(new Enemy(0, 600, 1, Direction.right));
                                    break;
                                case 2:
                                    Singleton.Instance.AddElement(new Enemy(600, 600, 1, Direction.left));
                                    break;
                            }
                            break;
                        case 3:
                            switch (rdm.Next(0, 2))
                            {
                                case 0:
                                    Singleton.Instance.AddElement(new Enemy(600, 0, 1, Direction.left));
                                    break;
                                case 1:
                                    Singleton.Instance.AddElement(new Enemy(0, 600, 1, Direction.right));
                                    break;
                                case 2:
                                    Singleton.Instance.AddElement(new Enemy(600, 600, 1, Direction.left));
                                    break;
                            }
                            break;
                        default: break;
                    }
                    n++;
                }
            }
            else
            {
                if(Singleton.Instance.count<3 && Enumber>0 && Singleton.Instance.PlayerNum == 1)
                {
                    switch (enemySetType)
                    {
                        case 1:
                            switch (rdm.Next(0, 2))
                            {
                                case 0:
                                    Singleton.Instance.AddElement(new Enemy(600, 0, 1, Direction.left));
                                    break;
                                case 1:
                                    Singleton.Instance.AddElement(new Enemy(0, 600, 1, Direction.right));
                                    break;
                                case 2:
                                    Singleton.Instance.AddElement(new Enemy(600, 600, 1, Direction.left));
                                    break;
                            }
                            break;
                        case 2:
                            switch (rdm.Next(0, 2))
                            {
                                case 0:
                                    Singleton.Instance.AddElement(new Enemy(600, 0, 1, Direction.left));
                                    break;
                                case 1:
                                    Singleton.Instance.AddElement(new Enemy(0, 600, 1, Direction.right));
                                    break;
                                case 2:
                                    Singleton.Instance.AddElement(new Enemy(600, 600, 1, Direction.left));
                                    break;
                            }
                            break;
                        case 3:
                            switch (rdm.Next(0, 2))
                            {
                                case 0:
                                    Singleton.Instance.AddElement(new Enemy(600, 0, 1, Direction.left));
                                    break;
                                case 1:
                                    Singleton.Instance.AddElement(new Enemy(0, 600, 1, Direction.right));
                                    break;
                                case 2:
                                    Singleton.Instance.AddElement(new Enemy(600, 600, 1, Direction.left));
                                    break;
                            }
                            break;
                        default: break;
                    }
                    Enumber--;
                }
                else if(Singleton.Instance.count==0 && Singleton.Instance.PlayerNum == 1)
                {
                   
                    Singleton.Instance.Player_win[SinglePlayerTag] = true;
                    Singleton.Instance.GameIsOver = true;
                }
            }
        }
        private void isMoving(object sender, MouseEventArgs e)
        {
           // label1.Text = Convert.ToString(e.X);
            //label2.Text = Convert.ToString(e.Y);
            if(triger)
            {
                if (e.X > 220 && e.X < 410 && e.Y > 305 && e.Y < 350)
                {
                    this.Cursor = Cursors.Hand;
                    
                }
                else if (e.X > 270 && e.X < 365  && e.Y > 375 && e.Y < 420)
                {
                    this.Cursor = Cursors.Hand;
                    
                }
                else this.Cursor = Cursors.Arrow;
            }
        }
        private void isClicking(object sender, MouseEventArgs e)
        {
            if (triger)
            {
                if (e.X > 220 && e.X < 410 && e.Y > 305 && e.Y < 350)
                {
                    if(e.Button == MouseButtons.Left)
                    {
                        this.Close();    
                    }
                }
                else if (e.X > 270 && e.X < 365 && e.Y > 375 && e.Y < 420)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        triger = false;
                        controlTime++;
                        g.Dispose();
                        timer.Start();
                    }
                }
                else this.Cursor = Cursors.Arrow;
            }
        }
        private void initPlayer()
        {
            if (Singleton.Instance.PlayerNum == 1)
            {
                switch (Singleton.Instance.IsMapNum)
                {

                    case 1:
                        Singleton.Instance.AddElement(new playerTank(0, 0, 0, 5, 3, Direction.right, 0));
                        enemySetType = 1;
                        break;
                    case 2:
                        Singleton.Instance.AddElement(new playerTank(0, 0, 0, 5, 3, Direction.right, 0));
                        enemySetType = 2;
                        break;
                    case 3:
                        Singleton.Instance.AddElement(new playerTank(0, 0, 0, 5, 3, Direction.down, 0));
                        enemySetType = 3;
                        break;
                        
                }
                isStart = true;
            }
            else if (Singleton.Instance.PlayerNum == 2)
            {
                switch (Singleton.Instance.IsMapNum)
                {
                    case 1:
                        Singleton.Instance.AddElement(new playerTank(0, 0, 0, 5, 5, Direction.right, 0));
                        Singleton.Instance.AddElement(new playerTank(1, 600, 600, 5, 5, Direction.left, 1));
                        break;
                    case 2:
                        Singleton.Instance.AddElement(new playerTank(0, 0, 300, 5, 5, Direction.right, 0));
                        Singleton.Instance.AddElement(new playerTank(1, 600,300, 5, 5, Direction.left, 1));
                        break;
                    case 3:
                        Singleton.Instance.AddElement(new playerTank(0, 300, 0, 5, 5, Direction.down, 0));
                        Singleton.Instance.AddElement(new playerTank(1, 300, 600, 5, 5, Direction.up, 1));
                        break;

                }
               
            }
            
        }
        private void initMulti()
        {
            address = Microsoft.VisualBasic.Interaction.InputBox("輸入Server IP :", "IP ADDRESS", "127.0.0.1");
            do
            {
               
                try {
                    clientSocket.Connect(address, 9487);
                }
                catch
                {
                    DialogResult result;
                    result = MessageBox.Show("Server no apply..", "Warning", MessageBoxButtons.RetryCancel);
                    if(result == DialogResult.Retry)
                    {

                    }
                    else
                    {
                        serverNoap = true;
                        break;
                    }
                   
                }
                if (clientSocket.Connected)
                {
                    Invalidate();
                    isConnected = true;
                    networkStream = clientSocket.GetStream();
                }

            } while (isConnected == false);
            
            if(serverNoap==true)
            {
                return;
            }

            sr = new StreamReader(networkStream);
            sw = new StreamWriter(networkStream);

            string start;

            hi = sr.ReadLine();

            switch (hi[0])
            {
                case '0':
                    SinglePlayerTag = 0;
                    OtherPlayerTag = 1;
                    break;
                case '1':
                    SinglePlayerTag = 1;
                    OtherPlayerTag = 0;
                    break;
            }
            Singleton.Instance.IsMapNum = hi[1] - '0';

            do
            {
                start = sr.ReadLine();
            } while (start != "yes");
            isStart = true;
            Create_Read_Thread();
        }
        public void Create_Read_Thread()
        {
            newThred = new Thread(new ThreadStart(P2_thread));
            newThred.Start();
        }
        private void P2_thread()
        {


            while (true)
            {

                P2control = sr.ReadLine();

                //判斷移動
                switch (Convert.ToChar(P2control[0]))
                {
                    case '0':
                    switch (Convert.ToChar(P2control[1]))
                    {
                        case 'W':
                            switch (Convert.ToChar(P2control[2]) - '0')
                            {
                                case 0:
                                    Singleton.Instance.GetPlayer(OtherPlayerTag).otherKeyUp((int)Keys.W);
                                    break;
                                case 1:
                                    Singleton.Instance.GetPlayer(OtherPlayerTag).otherKeydown((int)Keys.W);
                                    break;
                                default: break;
                            }
                            break;
                        case 'A':
                            switch (Convert.ToChar(P2control[2]) - '0')
                            {
                                case 0:
                                    Singleton.Instance.GetPlayer(OtherPlayerTag).otherKeyUp((int)Keys.A);
                                    break;
                                case 1:
                                    Singleton.Instance.GetPlayer(OtherPlayerTag).otherKeydown((int)Keys.A);
                                    break;
                                default: break;
                            }
                            break;
                        case 'S':
                            switch (Convert.ToChar(P2control[2]) - '0')
                            {
                                case 0:
                                    Singleton.Instance.GetPlayer(OtherPlayerTag).otherKeyUp((int)Keys.S);
                                    break;
                                case 1:
                                    Singleton.Instance.GetPlayer(OtherPlayerTag).otherKeydown((int)Keys.S);
                                    break;
                                default: break;
                            }
                            break;
                        case 'D':
                            switch (Convert.ToChar(P2control[2]) - '0')
                            {
                                case 0:
                                    Singleton.Instance.GetPlayer(OtherPlayerTag).otherKeyUp((int)Keys.D);
                                    break;
                                case 1:
                                    Singleton.Instance.GetPlayer(OtherPlayerTag).otherKeydown((int)Keys.D);
                                    break;
                                default: break;
                            }
                            break;
                        case 'F':
                            Singleton.Instance.GetPlayer(OtherPlayerTag).otherKeydown((int)Keys.Space);
                            break;
                        default: break;
                        }
                        break;
                    case '1':
                        char[] delimiterChars = { '/' };
                        string[] words = P2control.Split(delimiterChars);
                        Singleton.Instance.AddElement(new Equipment(int.Parse(words[1]), int.Parse(words[2]), int.Parse(words[3])));
                        break;
                    case '2':
                        char[] delimiterChar = { '/' };
                        string[] loc = P2control.Split(delimiterChar);
                        Singleton.Instance.GetPlayer(OtherPlayerTag).X = int.Parse(loc[1]);
                        Singleton.Instance.GetPlayer(OtherPlayerTag).Y = int.Parse(loc[2]);
                        switch (int.Parse(loc[3]))
                        {
                            case 0:
                                Singleton.Instance.GetPlayer(OtherPlayerTag).dir = Direction.up;
                                break;
                            case 1:
                                Singleton.Instance.GetPlayer(OtherPlayerTag).dir = Direction.left;
                                break;
                            case 2:
                                Singleton.Instance.GetPlayer(OtherPlayerTag).dir = Direction.down;
                                break;
                            case 3:
                                Singleton.Instance.GetPlayer(OtherPlayerTag).dir = Direction.right;
                                break;
                        }
                        break;
                    default: break;
                }
                if(P2control == "end")
                {
                    break;
                }
            }

        }
    }
}

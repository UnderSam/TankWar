using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankWar.Properties;
namespace TankWar
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            
        }
        private static Image imgTitle = Resources.title1;
        private static Image imgselect = Resources.title2;
        private static Image imgCursor = Resources.bWhite4;
        private Graphics g;

        private int xpos = 130, ypos = 235;
        private int roll = 500;

        private void StartForm_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(imgTitle, 130, 50 + roll);
            g.DrawImage(imgselect, 210, 220 + roll);
            g.DrawImage(imgCursor, xpos, ypos + roll);
            rollThread();
        }

        private void iskeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void StartForm_MouseMove(object sender, MouseEventArgs e)
        {
            //label1.Text = Convert.ToString(e.X);
            //label2.Text = Convert.ToString(e.Y);
            if (e.X > 233 && e.X < 511 && e.Y > 228 && e.Y < 295)
            {
                this.Cursor = Cursors.Hand;
                ypos = 235;
                Invalidate();
            }
            else if (e.X > 233 && e.X < 511 && e.Y > 341 && e.Y < 404)
            {
                this.Cursor = Cursors.Hand;
                ypos = 351;
                Invalidate();
            }
            else if (e.X > 305 && e.X < 440 + imgselect.Width && e.Y > 449 && e.Y < 508)
            {
                this.Cursor = Cursors.Hand;
                ypos = 459;
                Invalidate();
            }
            else this.Cursor = Cursors.Arrow;
        }

        private void StartForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > 233 && e.X < 511 && e.Y > 228 && e.Y < 295)
            {
                Singleton.Instance.PlayerNum = 1;
                Singleton.Instance.ClearAll();
                Start();
            }
            else if (e.X > 233 && e.X < 511 && e.Y > 341 && e.Y < 404)
            {
                Singleton.Instance.PlayerNum = 2;
                Singleton.Instance.ClearAll();
                Start();
            }
            else if (e.X > 305 && e.X < 440 + imgselect.Width && e.Y > 449 && e.Y < 508)
            {
                this.Close();
            }
        }

        private void Start()
        {
            //MessageBox.Show("Start");
            MainForm startGame = new MainForm();
            //this.Visible = false;
            if (Singleton.Instance.Cancel_for_Form1 == true)
                return;
            startGame.ShowDialog(this);////設定Form2為Form1的上層，並開啟Form2視窗。由於在Form1的程式碼內使用this，所以this為Form1的物件本身
        }

        private void rollThread()
        {
            if (roll > 0)
            {
                roll -= 3;
                Thread.Sleep(5);
            }
            else
                return;
            Invalidate();

        }


    }
}

namespace TankWar
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.player1Hp = new System.Windows.Forms.Label();
            this.player2Hp = new System.Windows.Forms.Label();
            this.enemyCount = new System.Windows.Forms.Label();
            this.scoreSing1 = new System.Windows.Forms.Label();
            this.scoreSing2 = new System.Windows.Forms.Label();
            this.liveCount = new System.Windows.Forms.Label();
            this.liveFlag = new System.Windows.Forms.PictureBox();
            this.enemyFlag = new System.Windows.Forms.PictureBox();
            this.player2Flag = new System.Windows.Forms.PictureBox();
            this.player1Flag = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new TankWar.GamePanel();
            this.escapeTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.liveFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2Flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1Flag)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 30;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // player1Hp
            // 
            this.player1Hp.Font = new System.Drawing.Font("Pump Demi Bold LET", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Hp.Location = new System.Drawing.Point(701, 332);
            this.player1Hp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.player1Hp.Name = "player1Hp";
            this.player1Hp.Size = new System.Drawing.Size(44, 31);
            this.player1Hp.TabIndex = 0;
            this.player1Hp.Text = "0";
            // 
            // player2Hp
            // 
            this.player2Hp.Font = new System.Drawing.Font("Pump Demi Bold LET", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Hp.Location = new System.Drawing.Point(697, 390);
            this.player2Hp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.player2Hp.Name = "player2Hp";
            this.player2Hp.Size = new System.Drawing.Size(48, 31);
            this.player2Hp.TabIndex = 3;
            this.player2Hp.Text = "0";
            // 
            // enemyCount
            // 
            this.enemyCount.Font = new System.Drawing.Font("Pump Demi Bold LET", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyCount.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.enemyCount.Location = new System.Drawing.Point(710, 260);
            this.enemyCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.enemyCount.Name = "enemyCount";
            this.enemyCount.Size = new System.Drawing.Size(43, 26);
            this.enemyCount.TabIndex = 6;
            this.enemyCount.Text = "0";
            // 
            // scoreSing1
            // 
            this.scoreSing1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreSing1.Location = new System.Drawing.Point(679, 212);
            this.scoreSing1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scoreSing1.Name = "scoreSing1";
            this.scoreSing1.Size = new System.Drawing.Size(58, 31);
            this.scoreSing1.TabIndex = 7;
            this.scoreSing1.Text = "score";
            // 
            // scoreSing2
            // 
            this.scoreSing2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreSing2.Location = new System.Drawing.Point(679, 233);
            this.scoreSing2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scoreSing2.Name = "scoreSing2";
            this.scoreSing2.Size = new System.Drawing.Size(58, 25);
            this.scoreSing2.TabIndex = 8;
            this.scoreSing2.Text = "1000";
            // 
            // liveCount
            // 
            this.liveCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.liveCount.Font = new System.Drawing.Font("Pump Demi Bold LET", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveCount.Location = new System.Drawing.Point(681, 134);
            this.liveCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.liveCount.Name = "liveCount";
            this.liveCount.Size = new System.Drawing.Size(56, 32);
            this.liveCount.TabIndex = 11;
            this.liveCount.Text = "0";
            this.liveCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // liveFlag
            // 
            this.liveFlag.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.liveFlag.Image = ((System.Drawing.Image)(resources.GetObject("liveFlag.Image")));
            this.liveFlag.Location = new System.Drawing.Point(681, 89);
            this.liveFlag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.liveFlag.Name = "liveFlag";
            this.liveFlag.Size = new System.Drawing.Size(55, 77);
            this.liveFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.liveFlag.TabIndex = 9;
            this.liveFlag.TabStop = false;
            // 
            // enemyFlag
            // 
            this.enemyFlag.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.enemyFlag.Image = ((System.Drawing.Image)(resources.GetObject("enemyFlag.Image")));
            this.enemyFlag.Location = new System.Drawing.Point(682, 260);
            this.enemyFlag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.enemyFlag.Name = "enemyFlag";
            this.enemyFlag.Size = new System.Drawing.Size(24, 26);
            this.enemyFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemyFlag.TabIndex = 5;
            this.enemyFlag.TabStop = false;
            // 
            // player2Flag
            // 
            this.player2Flag.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.player2Flag.Image = ((System.Drawing.Image)(resources.GetObject("player2Flag.Image")));
            this.player2Flag.Location = new System.Drawing.Point(676, 368);
            this.player2Flag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.player2Flag.Name = "player2Flag";
            this.player2Flag.Size = new System.Drawing.Size(50, 53);
            this.player2Flag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player2Flag.TabIndex = 2;
            this.player2Flag.TabStop = false;
            this.player2Flag.Visible = false;
            // 
            // player1Flag
            // 
            this.player1Flag.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.player1Flag.Image = ((System.Drawing.Image)(resources.GetObject("player1Flag.Image")));
            this.player1Flag.Location = new System.Drawing.Point(681, 307);
            this.player1Flag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.player1Flag.Name = "player1Flag";
            this.player1Flag.Size = new System.Drawing.Size(45, 57);
            this.player1Flag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player1Flag.TabIndex = 1;
            this.player1Flag.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(674, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 52);
            this.label1.TabIndex = 12;
            this.label1.Text = "PT";
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel.Controls.Add(this.escapeTo);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(2);
            this.panel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(660, 660);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.isClicking);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.isMoving);
            // 
            // escapeTo
            // 
            this.escapeTo.AutoSize = true;
            this.escapeTo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.escapeTo.Enabled = false;
            this.escapeTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escapeTo.Location = new System.Drawing.Point(136, 498);
            this.escapeTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.escapeTo.Name = "escapeTo";
            this.escapeTo.Size = new System.Drawing.Size(427, 73);
            this.escapeTo.TabIndex = 5;
            this.escapeTo.Text = "按ESC以退出";
            this.escapeTo.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(764, 662);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enemyCount);
            this.Controls.Add(this.liveCount);
            this.Controls.Add(this.liveFlag);
            this.Controls.Add(this.scoreSing2);
            this.Controls.Add(this.scoreSing1);
            this.Controls.Add(this.enemyFlag);
            this.Controls.Add(this.player2Hp);
            this.Controls.Add(this.player1Hp);
            this.Controls.Add(this.player2Flag);
            this.Controls.Add(this.player1Flag);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.isKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.isKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.liveFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2Flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1Flag)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GamePanel panel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox player1Flag;
        private System.Windows.Forms.PictureBox player2Flag;
        private System.Windows.Forms.Label player1Hp;
        private System.Windows.Forms.Label player2Hp;
        private System.Windows.Forms.PictureBox enemyFlag;
        private System.Windows.Forms.Label enemyCount;
        private System.Windows.Forms.Label scoreSing1;
        private System.Windows.Forms.Label scoreSing2;
        private System.Windows.Forms.Label escapeTo;
        private System.Windows.Forms.PictureBox liveFlag;
        private System.Windows.Forms.Label liveCount;
        private System.Windows.Forms.Label label1;
    }
}


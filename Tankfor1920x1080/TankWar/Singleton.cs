using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TankWar
{
    class Singleton
    {
        private int bulletN;

        public int BulletN
        {
            get
            {
                return playerBullet.Count;
            }

            set
            {
                bulletN = value;
            }
        }

        private bool cancel_for_Form1;
        private int newMultiEquipX;
        private int newMultiEquipY;
        private int newMultiEquipType;
        private bool isCreateEquip;
        private bool gameIsOver;
        private int playerNum;
        private int isMapNum;
        private bool lock_thread;
        public int count;
        private int getSingleplayerLives;
        private int scoreSumOfSingle = 0;
        private bool p1_win = false;
        private string passMap;
        private bool[] player_win = new bool[2]; 
        private List<playerTank> pTank = new List<playerTank> { };
        private List<Enemy> enemy = new List<Enemy> { };
        private List<myBullet> playerBullet = new List<myBullet> { };
        private List<P2Bullet> player2Bullet = new List<P2Bullet> { };
        private List<eBullet> enemyBullet = new List<eBullet> { };
        private List<Bomb> dieBomb = new List<Bomb> { };
        private List<Born> shine = new List<Born> { };
        private List<Equipment> equip = new List<Equipment> { };
        private List<MapModule> gameMap1 = new List<MapModule> { };
        private List<MapModule> gameMap2 = new List<MapModule> { };
        private List<MapModule> gameMap3 = new List<MapModule> { };
        private List<enemyScore> eScore = new List<enemyScore> { };
        private MapModule resetMap;
        private Singleton() { }
        public void initialMap()
        {
            AddElement(new MapModule(0, 0, 0, -1));
            resetMap.Create(isMapNum);
        }
        private static Singleton instance = null;

        internal static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        public playerTank GetPlayer(int nums)
        {
            return pTank[nums];
        }
        
        public int PlayerNum
        {
            get
            {
                return playerNum;
            }

            set
            {
                playerNum = value;
            }
        }

        public int IsMapNum
        {
            get
            {
                return isMapNum;
            }

            set
            {
                isMapNum = value;
            }
        }

        public MapModule ResetMap
        {
            get
            {
                return resetMap;
            }

            set
            {
                resetMap = value;
            }
        }

        public bool GameIsOver
        {
            get
            {
                return gameIsOver;
            }

            set
            {
                gameIsOver = value;
            }
        }

        public bool P1_win
        {
            get
            {
                return p1_win;
            }

            set
            {
                p1_win = value;
            }
        }


        public int ScoreSumOfSingle
        {
            get
            {
                return scoreSumOfSingle;
            }

            set
            {
                scoreSumOfSingle = value;
            }
        }

        public int GetSingleplayerLives
        {
            get
            {
                return pTank[0].IsLive;
            }

            set
            {
                getSingleplayerLives = value;
            }
        }

        public bool Lock_thread
        {
            get
            {
                return lock_thread;
            }

            set
            {
                lock_thread = value;
            }
        }

        public bool[] Player_win
        {
            get
            {
                return player_win;
            }

            set
            {
                player_win = value;
            }
        }

        public int NewMultiEquipX
        {
            get
            {
                return newMultiEquipX;
            }

            set
            {
                newMultiEquipX = value;
            }
        }

        public int NewMultiEquipY
        {
            get
            {
                return newMultiEquipY;
            }

            set
            {
                newMultiEquipY = value;
            }
        }

        public bool IsCreateEquip
        {
            get
            {
                return isCreateEquip;
            }

            set
            {
                isCreateEquip = value;
            }
        }

        public int NewMultiEquipType
        {
            get
            {
                return newMultiEquipType;
            }

            set
            {
                newMultiEquipType = value;
            }
        }

        public string PassMap
        {
            get
            {
                return passMap;
            }

            set
            {
                passMap = value;
            }
        }

        public bool Cancel_for_Form1
        {
            get
            {
                return cancel_for_Form1;
            }

            set
            {
                cancel_for_Form1 = value;
            }
        }

        public int getP1hp()
        {
            return pTank[0].Life;
        }
        public int getP2hp()
        {
            return pTank[1].Life;
        }
        public void CreateThread()
        {
            Thread hitThread = new Thread(new ThreadStart(HitCheck));
            hitThread.Start();
            count = enemy.Count;
        }

        public void Thread_for_Multi()
        {
            Thread hitThread2 = new Thread(new ThreadStart(HitCheck2));
            hitThread2.Start();
        }
        public void AddElement(Element e)
        {
            if (e is playerTank)  // 如果是就true
            {
                pTank.Add(e as playerTank);
                return;
            }
            if (e is Enemy)
            {
                enemy.Add(e as Enemy);
                return;
            }
            if (e is myBullet)
            {
                playerBullet.Add(e as myBullet);
                return;
            }
            if (e is eBullet)
            {
                enemyBullet.Add(e as eBullet);
                return;
            }
            if(e is P2Bullet)
            {
                player2Bullet.Add(e as P2Bullet);
                return;
            }
            if (e is Bomb)
            {
                dieBomb.Add(e as Bomb);
                return;
            }
            if (e is Born)
            {
                shine.Add(e as Born);
                return;
            }
            if(e is Equipment)
            {
                equip.Add(e as Equipment);
                return;
            }

            if(e is enemyScore)
            {
                eScore.Add(e as enemyScore);
                return;
            }

            if (e is MapModule)
            {
                switch ((e as MapModule).NumMap) {
                    case 1:
                        gameMap1.Add(e as MapModule);
                        break;
                    case 2:
                        gameMap2.Add(e as MapModule);
                        break;
                    case 3:
                        gameMap3.Add(e as MapModule);
                        break;
                    default:
                        resetMap = (e as MapModule);
                        break;
                }
                  return;
            }
        }
        public void Draw_Map(Graphics g)
        {
            switch (IsMapNum)
            {
                case 1:
                    for (int i = 0; i < gameMap1.Count; i++)
                        if(lock_thread == false )gameMap1[i].Draw(g);
                    break;
                case 2:
                    for (int i = 0; i < gameMap2.Count; i++)
                        if (lock_thread == false) gameMap2[i].Draw(g);
                    break;
                case 3:
                    for (int i = 0; i < gameMap3.Count; i++)
                        if (lock_thread == false) gameMap3[i].Draw(g);
                    break;
            }
        }
        public void Draw(Graphics g)
        {
            for (int i=0;i<pTank.Count;i++)
            {
                if(pTank[i].PlayerIsDead_bool==false)
                pTank[i].Draw(g);
            }
            for (int i = 0; i < enemy.Count; i++)
            {
                if (!enemy[i].isDad)
                {
                    enemy[i].Draw(g);
                }
                else
                    enemy.Remove(enemy[i]); 
            }
            for (int i = 0; i < playerBullet.Count; i++)
            {
                playerBullet[i].Draw(g);
            }
            for(int i=0;i<player2Bullet.Count;i++)
            {
                player2Bullet[i].Draw(g);
            }
            for (int i = 0; i < enemyBullet.Count; i++)
            {
                enemyBullet[i].Draw(g);
            }
            for (int i = 0; i < dieBomb.Count; i++)
            {
                dieBomb[i].Draw(g);
            }
            for (int i = 0; i < shine.Count; i++)
            {
                shine[i].Draw(g);
            }
            for (int i=0; i<equip.Count;i++)
            {
                equip[i].Draw(g);
            }
            for(int i=0;i<eScore.Count;i++)
            {
                eScore[i].Draw(g);
            }

        }
        public void RemoveElement(Element e)
        {
            if(e is playerTank)
            {
                pTank.Remove(e as playerTank);
                return;
            }
            if (e is Bomb)
            {
                dieBomb.Remove(e as Bomb);
                return;
            }
            
            if (e is Enemy)
            {
                enemy.Remove(e as Enemy);
                return;
            }
            if(e is Equipment)
            {
                equip.Remove(e as Equipment);
                return;
            }
       
           if (e is MapModule)
              {
                switch ((e as MapModule).NumMap)
                    {
                     case 1:
                            gameMap1.Remove(e as MapModule);
                            break;
                     case 2:
                            gameMap2.Remove(e as MapModule);
                            break;
                     case 3:
                            gameMap3.Remove(e as MapModule);
                            break;
                     default:
                           break;
                    }
                    return;
             }
            if(e is enemyScore)
            {
                eScore.Remove(e as enemyScore);
                return;
            }
            if(e is myBullet)
            {
                playerBullet.Remove(e as myBullet);
                pTank[0].FireCount--;
                return;
            }
            if(e is eBullet)
            {
                enemyBullet.Remove(e as eBullet);
                return;
            }
            if(e is P2Bullet)
            {
                player2Bullet.Remove(e as P2Bullet);
                return;
            }
        }
        public void HitCheck2()
        {
            Lock_thread = true;
            player_enemy_collision_map();
            P1_P2_bullet_to_each();
            player1_bullet_collision_map();
            player2_bullet_collision_map();
            equip_element_all();
            Lock_thread = false;
        }
        public void HitCheck()
        {
            Lock_thread = true;
            player_enemy_collision_map();
            player_enemy_bullet_collision_single();
            player1_bullet_collision_map();
            enemy_bullet_collision_map();
            equip_element_all();
            Lock_thread = false;
        }

        public void Equip(int type,int who)
        {
            switch (type)
            {
                case 0:
                    if (pTank[who].Tpower < 2)
                    {
                        pTank[who].Tpower++;
                    }
                    if (pTank[who].Tpower == 2)
                        pTank[who].Life++;
                    break;
                case 1:
                        for (int i=0;i<enemy.Count;i++)
                        {
                        enemy[i].Life = 0;
                        enemy[i].isDead();
                        }
                    break;
                case 2:
                    for (int i = 0; i < enemy.Count; i++)
                    {
                        enemy[i].Movable = false;
                    }
                    break;
                case 3:
                    pTank[who].Penatrate = true;
                    break;
                case 4:
                    if (pTank[who].TankType < 2)
                    {
                        pTank[who].TankType++;
                        pTank[who].Life += 3;
                        break;
                    }
                    else
                        pTank[who].Life += 2;
                        break;
                case 5:
                    if (pTank[who].Tpower < 2)
                    {
                        pTank[who].Tpower++;
                    }
                    if (pTank[who].Tpower == 2)
                        pTank[who].Life++;
                    break;            
                case 6:
                    pTank[who].Penatrate = true;
                    break;
                case 7:
                    if (pTank[who].TankType < 2)
                    {
                        pTank[who].TankType++;
                        pTank[who].Life += 3;
                        break;
                    }
                    else
                        pTank[who].Life += 2;
                    break;
                default: break;
            }
        }
        public void ClearAll()
        {
            pTank.Clear();
            enemy.Clear();
            playerBullet.Clear();
            enemyBullet.Clear();
            dieBomb.Clear();
            shine.Clear();
            equip.Clear();
            gameMap1.Clear();
            gameMap2.Clear();
            gameMap3.Clear();
        }
        private void player_enemy_collision_map()
        {
            switch (IsMapNum)
            {
                case 1:
                    try
                    {
                        for (int i = 0; i < gameMap1.Count; i++)
                            for (int j = 0; j < pTank.Count; j++)
                            {
                                if (pTank[j].GetRectangle().IntersectsWith(gameMap1[i].getRectangle()))
                                {
                                    if (gameMap1[i].Type > 2)
                                    {
                                        switch(gameMap1[i].Type)
                                        {
                                            case 3: //4
                                                switch (pTank[j].dir)
                                                {
                                                    case Direction.up:
                                                        pTank[j].Y = gameMap1[i].Y + gameMap1[i].Height;
                                                        break;
                                                    case Direction.left:
                                                        pTank[j].X = gameMap1[i].X + gameMap1[i].Width;
                                                        break;
                                                    case Direction.down:
                                                        pTank[j].Y = gameMap1[i].Y - pTank[j].Height;
                                                        break;
                                                    case Direction.right:
                                                        pTank[j].X = gameMap1[i].X - pTank[j].Width;
                                                        break;
                                                }
                                                break;
                                            case 4: //16
                                                switch (pTank[j].dir)
                                                {
                                                    case Direction.up:
                                                        pTank[j].Y = gameMap1[i].Y + gameMap1[i].Height;
                                                        break;
                                                    case Direction.left:
                                                        pTank[j].X = gameMap1[i].X + gameMap1[i].Width;
                                                        break;
                                                    case Direction.down:
                                                        pTank[j].Y = gameMap1[i].Y - pTank[j].Height;
                                                        break;
                                                    case Direction.right:
                                                        pTank[j].X = gameMap1[i].X - pTank[j].Width;
                                                        break;
                                                }
                                                break;
                                            case 5: //60x120
                                                switch (pTank[j].dir)
                                                {
                                                    case Direction.up:
                                                        pTank[j].Y = gameMap1[i].Y + gameMap1[i].Height;
                                                        break;
                                                    case Direction.left:
                                                        pTank[j].X = gameMap1[i].X + gameMap1[i].Width;
                                                        break;
                                                    case Direction.down:
                                                        pTank[j].Y = gameMap1[i].Y - pTank[j].Height;
                                                        break;
                                                    case Direction.right:
                                                        pTank[j].X = gameMap1[i].X - pTank[j].Width;
                                                        break;
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        switch (pTank[j].dir)
                                        {
                                            case Direction.up:
                                                pTank[j].Y = gameMap1[i].Y + gameMap1[i].Height;
                                                break;
                                            case Direction.left:
                                                pTank[j].X = gameMap1[i].X + gameMap1[i].Width;
                                                break;
                                            case Direction.down:
                                                pTank[j].Y = gameMap1[i].Y - pTank[j].Height;
                                                break;
                                            case Direction.right:
                                                pTank[j].X = gameMap1[i].X - pTank[j].Width;
                                                break;
                                        }
                                    }
                                }
                            }
                        for (int i = 0; i < gameMap1.Count; i++)
                            for (int j = 0; j < enemy.Count; j++)
                            {
                                if (enemy[j].GetRectangle().IntersectsWith(gameMap1[i].getRectangle()))
                                {
                                    switch (enemy[j].dir)
                                    {
                                        case Direction.up:
                                            enemy[j].Y = gameMap1[i].Y + gameMap1[i].Height;
                                            break;
                                        case Direction.left:
                                            enemy[j].X = gameMap1[i].X + gameMap1[i].Width;
                                            break;
                                        case Direction.down:
                                            enemy[j].Y = gameMap1[i].Y - enemy[j].Height;
                                            break;
                                        case Direction.right:
                                            enemy[j].X = gameMap1[i].X - enemy[j].Width;
                                            break;
                                    }
                                }
                            }

                    }
                    catch { }
                    break;

                case 2:
                    try
                    {
                        for (int i = 0; i < gameMap2.Count; i++)
                            for (int j = 0; j < pTank.Count; j++)
                            {
                                if (pTank[j].GetRectangle().IntersectsWith(gameMap2[i].getRectangle()))
                                {
                                    switch (pTank[j].dir)
                                    {
                                        case Direction.up:
                                            pTank[j].Y = gameMap2[i].Y + gameMap2[i].Height;
                                            break;
                                        case Direction.left:
                                            pTank[j].X = gameMap2[i].X + gameMap2[i].Width;
                                            break;
                                        case Direction.down:
                                            pTank[j].Y = gameMap2[i].Y - pTank[j].Height;
                                            break;
                                        case Direction.right:
                                            pTank[j].X = gameMap2[i].X - pTank[j].Width;
                                            break;
                                    }
                                }
                            }
                        for (int i = 0; i < gameMap2.Count; i++)
                            for (int j = 0; j < enemy.Count; j++)
                            {
                                if (enemy[j].GetRectangle().IntersectsWith(gameMap2[i].getRectangle()))
                                {
                                    switch (enemy[j].dir)
                                    {
                                        case Direction.up:
                                            enemy[j].Y = gameMap2[i].Y + gameMap2[i].Height;
                                            break;
                                        case Direction.left:
                                            enemy[j].X = gameMap2[i].X + gameMap2[i].Width;
                                            break;
                                        case Direction.down:
                                            enemy[j].Y = gameMap2[i].Y - enemy[j].Height;
                                            break;
                                        case Direction.right:
                                            enemy[j].X = gameMap2[i].X - enemy[j].Width;
                                            break;
                                    }
                                }
                            }

                    }
                    catch { }
                    break;

                case 3:
                    try
                    {
                        for (int i = 0; i < gameMap3.Count; i++)
                            for (int j = 0; j < pTank.Count; j++)
                            {
                                if (pTank[j].GetRectangle().IntersectsWith(gameMap3[i].getRectangle()))
                                {
                                    switch (pTank[j].dir)
                                    {
                                        case Direction.up:
                                            pTank[j].Y = gameMap3[i].Y + gameMap3[i].Height;
                                            break;
                                        case Direction.left:
                                            pTank[j].X = gameMap3[i].X + gameMap3[i].Width;
                                            break;
                                        case Direction.down:
                                            pTank[j].Y = gameMap3[i].Y - pTank[j].Height;
                                            break;
                                        case Direction.right:
                                            pTank[j].X = gameMap3[i].X - pTank[j].Width;
                                            break;
                                    }
                                }
                            }
                        for (int i = 0; i < gameMap3.Count; i++)
                            for (int j = 0; j < enemy.Count; j++)
                            {
                                if (enemy[j].GetRectangle().IntersectsWith(gameMap3[i].getRectangle()))
                                {
                                    switch (enemy[j].dir)
                                    {
                                        case Direction.up:
                                            enemy[j].Y = gameMap3[i].Y + gameMap3[i].Height;
                                            break;
                                        case Direction.left:
                                            enemy[j].X = gameMap3[i].X + gameMap3[i].Width;
                                            break;
                                        case Direction.down:
                                            enemy[j].Y = gameMap3[i].Y - enemy[j].Height;
                                            break;
                                        case Direction.right:
                                            enemy[j].X = gameMap3[i].X - enemy[j].Width;
                                            break;
                                    }
                                }
                            }

                    }
                    catch { }
                    break;
            }
        }
        private void player_enemy_bullet_collision_single()
        {
            
            for (int i = 0; i < enemyBullet.Count; i++)
            {
                if (pTank[0].BornTime < 48) continue;
                try
                {
                    if (pTank[0].GetRectangle().IntersectsWith(enemyBullet[i].GetRectangle()))
                    {
                        pTank[0].Life -= enemyBullet[i].power;
                        enemyBullet.Remove(enemyBullet[i]);
                        pTank[0].isDead();
                        if (pTank[0].IsLive < 0)
                        {
                            GameIsOver = true;
                        }
                    }
                }
                catch { }
            }

            for (int i = 0; i < playerBullet.Count; i++)
                for (int j = 0; j < enemy.Count; j++)
                {
                    if (enemy[0].BornTime < 48) continue;
                    try
                    {
                        if (playerBullet[i].GetRectangle().IntersectsWith(enemy[j].GetRectangle()))
                        {
                            enemy[j].Life -= playerBullet[i].power;
                            enemy[j].isDead();
                            if (pTank[0].Penatrate == false)
                                playerBullet.Remove(playerBullet[i]);
                        }
                    }
                    catch { }
                }
        }

        private void player1_bullet_collision_map()
        {
            switch (IsMapNum)
            {
                case 1:
                   
                        for (int i = 0; i < gameMap1.Count; i++)
                            for (int j = 0; j < playerBullet.Count; j++)
                            {
                                try
                                {
                                    if (playerBullet[j].GetRectangle().IntersectsWith(gameMap1[i].getRectangle()))
                                    {
                                        if (gameMap1[i].Type < 2)  //磚頭或金屬
                                        {
                                            if (gameMap1[i].Type == 1)
                                            {
                                                if (pTank[0].TankType < 1)
                                                { 
                                                    playerBullet.Remove(playerBullet[j]);
                                                }
                                                else
                                                {
                                                    gameMap1[i].Life -= playerBullet[j].power;
                                                    gameMap1[i].isBreak();
                                                    playerBullet.Remove(playerBullet[j]);
                                                }
                                            }
                                            else if (gameMap1[i].Type == 0)
                                            {
                                                gameMap1[i].Life -= playerBullet[j].power;
                                                gameMap1[i].isBreak();
                                                playerBullet.Remove(playerBullet[j]);
                                            }
                                        }
                                        else   //河流
                                        {
                                            //不做事
                                        }
                                    }
                                 }
                                catch { }
                        }
                   
                    break;

                case 2:
                    try
                    {
                        for (int i = 0; i < playerBullet.Count; i++)
                            for (int j = 0; j < gameMap2.Count; j++)
                            {

                                if (playerBullet[i].GetRectangle().IntersectsWith(gameMap2[j].getRectangle()))
                                {
                                    if (gameMap2[j].Type < 2)  //磚頭或金屬
                                    {
                                        if (gameMap2[j].Type == 1)
                                        {
                                            if (pTank[0].TankType < 1)
                                            {
                                                playerBullet.Remove(playerBullet[i]);
                                            }
                                            else
                                            {
                                                gameMap2[j].Life -= playerBullet[i].power;
                                                gameMap2[j].isBreak();
                                                playerBullet.Remove(playerBullet[i]);
                                            }
                                        }
                                        else if (gameMap2[j].Type == 0)
                                        {
                                            gameMap2[j].Life -= playerBullet[i].power;
                                            gameMap2[j].isBreak();
                                            playerBullet.Remove(playerBullet[i]);
                                        }
                                    }
                                    else   //河流
                                    {
                                        //不做事
                                    }
                                }
                            }
                    }
                    catch { }
                    break;

                case 3:
                    try
                    {
                        for (int i = 0; i < playerBullet.Count; i++)
                            for (int j = 0; j < gameMap3.Count; j++)
                            {

                                if (playerBullet[i].GetRectangle().IntersectsWith(gameMap3[j].getRectangle()))
                                {
                                    if (gameMap3[j].Type < 2)  //磚頭或金屬
                                    {
                                        if (gameMap3[j].Type == 1)
                                        {
                                            if (pTank[0].TankType < 1)
                                            {
                                                playerBullet.Remove(playerBullet[i]);
                                            }
                                            else
                                            {
                                                gameMap3[j].Life -= playerBullet[i].power;
                                                gameMap3[j].isBreak();
                                                playerBullet.Remove(playerBullet[i]);
                                            }
                                        }
                                        else if (gameMap3[j].Type == 0)
                                        {
                                            gameMap3[j].Life -= playerBullet[i].power;
                                            gameMap3[j].isBreak();
                                            playerBullet.Remove(playerBullet[i]);
                                        }
                                    }
                                    else   //河流
                                    {
                                        //不做事
                                    }
                                }
                            }
                    }
                    catch { }
                    break;
            }
        }
        private void player2_bullet_collision_map()
        {
            switch (IsMapNum)
            {
                case 1:
                    try
                    {
                        for (int i = 0; i < player2Bullet.Count; i++)
                            for (int j = 0; j < gameMap1.Count; j++)
                            {

                                if (player2Bullet[i].GetRectangle().IntersectsWith(gameMap1[j].getRectangle()))
                                {
                                    if (gameMap1[j].Type < 2)  //磚頭或金屬
                                    {
                                        if (gameMap1[j].Type == 1)
                                        {
                                            if (pTank[1].TankType < 1)
                                            {
                                                player2Bullet.Remove(player2Bullet[i]);
                                            }
                                            else
                                            {
                                                gameMap1[j].Life -= player2Bullet[i].power;
                                                gameMap1[j].isBreak();
                                                player2Bullet.Remove(player2Bullet[i]);
                                            }
                                        }
                                        else if (gameMap1[j].Type == 0)
                                        {
                                            gameMap1[j].Life -= player2Bullet[i].power;
                                            gameMap1[j].isBreak();
                                            player2Bullet.Remove(player2Bullet[i]);
                                        }
                                    }
                                    else   //河流
                                    {
                                        //不做事
                                    }
                                }
                            }
                    }
                    catch { }
                    break;

                case 2:
                    try
                    {
                        for (int i = 0; i < player2Bullet.Count; i++)
                            for (int j = 0; j < gameMap2.Count; j++)
                            {

                                if (player2Bullet[i].GetRectangle().IntersectsWith(gameMap2[j].getRectangle()))
                                {
                                    if (gameMap2[j].Type < 2)  //磚頭或金屬
                                    {
                                        if (gameMap2[j].Type == 1)
                                        {
                                            if (pTank[1].TankType < 1)
                                            {
                                                player2Bullet.Remove(player2Bullet[i]);
                                            }
                                            else
                                            {
                                                gameMap2[j].Life -= player2Bullet[i].power;
                                                gameMap2[j].isBreak();
                                                player2Bullet.Remove(player2Bullet[i]);
                                            }
                                        }
                                        else if (gameMap2[j].Type == 0)
                                        {
                                            gameMap2[j].Life -= player2Bullet[i].power;
                                            gameMap2[j].isBreak();
                                            player2Bullet.Remove(player2Bullet[i]);
                                        }
                                    }
                                    else   //河流
                                    {
                                        //不做事
                                    }
                                }
                            }
                    }
                    catch { }
                    break;

                case 3:
                    try
                    {
                        for (int i = 0; i < player2Bullet.Count; i++)
                            for (int j = 0; j < gameMap3.Count; j++)
                            {

                                if (player2Bullet[i].GetRectangle().IntersectsWith(gameMap3[j].getRectangle()))
                                {
                                    if (gameMap3[j].Type < 2)  //磚頭或金屬
                                    {
                                        if (gameMap3[j].Type == 1)
                                        {
                                            if (pTank[1].TankType < 1)
                                            {
                                                player2Bullet.Remove(player2Bullet[i]);
                                            }
                                            else
                                            {
                                                gameMap3[j].Life -= player2Bullet[i].power;
                                                gameMap3[j].isBreak();
                                                player2Bullet.Remove(player2Bullet[i]);
                                            }
                                        }
                                        else if (gameMap3[j].Type == 0)
                                        {
                                            gameMap3[j].Life -= player2Bullet[i].power;
                                            gameMap3[j].isBreak();
                                            player2Bullet.Remove(player2Bullet[i]);
                                        }
                                    }
                                    else   //河流
                                    {
                                        //不做事
                                    }
                                }
                            }
                    }
                    catch { }
                    break;
            }
        }
        private void enemy_bullet_collision_map()
        {
            switch (IsMapNum)
            {
                case 1:
                    try
                    {
                        for (int i = 0; i < enemyBullet.Count; i++)
                            for (int j = 0; j < gameMap1.Count; j++)
                            {

                                if (enemyBullet[i].GetRectangle().IntersectsWith(gameMap1[j].getRectangle()))
                                {
                                    if (gameMap1[j].Type < 2)  //磚頭或金屬
                                    {
                                        enemyBullet.Remove(enemyBullet[i]);
                                    }
                                    else   //河流
                                    {
                                        //不做事
                                    }
                                }
                            }
                    }
                    catch { }
                    break;

                case 2:
                    try
                    {
                        for (int i = 0; i < enemyBullet.Count; i++)
                            for (int j = 0; j < gameMap2.Count; j++)
                            {

                                if (enemyBullet[i].GetRectangle().IntersectsWith(gameMap2[j].getRectangle()))
                                {
                                    if (gameMap2[j].Type < 2)  //磚頭或金屬
                                    {
                                        enemyBullet.Remove(enemyBullet[i]);
                                    }
                                    else   //河流
                                    {
                                        //不做事
                                    }
                                }
                            }
                    }
                    catch { }
                    break;

                case 3:
                    try
                    {
                        for (int i = 0; i < enemyBullet.Count; i++)
                            for (int j = 0; j < gameMap3.Count; j++)
                            {

                                if (enemyBullet[i].GetRectangle().IntersectsWith(gameMap3[j].getRectangle()))
                                {
                                    if (gameMap3[j].Type < 2)  //磚頭或金屬
                                    {
                                        enemyBullet.Remove(enemyBullet[i]);
                                    }
                                    else   //河流
                                    {
                                        //不做事
                                    }
                                }
                            }
                    }
                    catch { }
                    break;
            }
        }

        private void P1_P2_bullet_to_each()
        {
            for (int i = 0; i < playerBullet.Count; i++)
            {   //p1對p2得射擊判定
                try
                {
                    if (playerBullet[i].GetRectangle().IntersectsWith(pTank[1].GetRectangle()))
                    {
                        pTank[1].Life -= playerBullet[i].power;
                        if (pTank[1].Life <= 0)
                        {
                            pTank[1].Life = 0;
                            pTank[1].PlayerIsDead_bool = true;
                            Player_win[0] = true;
                            Player_win[1] = false;
                            GameIsOver = true;
                        }
                        playerBullet.Remove(playerBullet[i]);
                    }
                }
                catch { }
            }
            for (int i = 0; i < player2Bullet.Count; i++) //p2對p1得射擊判定
            {
                try
                {
                    if (player2Bullet[i].GetRectangle().IntersectsWith(pTank[0].GetRectangle()))
                    {
                        pTank[0].Life -= player2Bullet[i].power;
                        if (pTank[0].Life <= 0)
                        {
                            pTank[0].Life = 0;
                            pTank[0].PlayerIsDead_bool = true;
                            Player_win[1] = true;
                            Player_win[0] = false;
                            GameIsOver = true;
                        }
                        player2Bullet.Remove(player2Bullet[i]);
                    }
                }
                catch { }
            }
        }
        private void equip_element_all()
        {
            for (int i = 0; i < pTank.Count; i++)
                for (int j = 0; j < equip.Count; j++)
                {
                    try
                    {
                        if (pTank[i].GetRectangle().IntersectsWith(equip[j].getRectangle()))
                        {
                            Equip(equip[j].Flag, i);
                            equip.Remove(equip[j]);
                        }
                    }
                    catch { }
                }
        }
       
    }
}

using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FormMain : Form
    {
        public PackmanController Controller { get; set; }
        public ListEntities Entities { get; set; }
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        FormReport form;


        Bitmap map;
        Graphics graphics;

        public bool IsGameOver => Controller.IsGameOver;
        public int Score => Controller.Score;

        public FormMain(PackmanController controller, ListEntities entities, int mapWidth, int mapHeight)
        {
            InitializeComponent();
            Controller = controller;
            Entities = entities;
            MapWidth = mapWidth;
            MapHeight = mapHeight;


            controller.NewGame();

            map = new Bitmap(MapWidth, MapHeight);
            graphics = Graphics.FromImage(map);
            Draw();
        }

        private void Draw()
        {
            if (!IsGameOver)
            {
                graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, MapWidth, MapHeight);

                Entities.Kolobok.Draw(graphics);

                foreach (var apple in Entities.Apples)
                {
                    apple.Draw(graphics);
                }
                foreach (var wall in Entities.Walls)
                {
                    wall.Draw(graphics);
                }
                
                foreach (var tank in Entities.Tanks)
                {
                    tank.Draw(graphics);
                }
                
                foreach (var bullet in Entities.Bullets)
                {
                    bullet.Draw(graphics);
                }

                graphics.DrawString($"Score : {Score}", new Font(FontFamily.GenericSansSerif, 20), new SolidBrush(Color.White), 660, 0);
            }
            else
            {
                graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, MapWidth, MapHeight);
                graphics.DrawString("Game over", new Font(FontFamily.GenericSansSerif, 30), new SolidBrush(Color.White), 300, 150);
                graphics.DrawString($"Score : {Score}", new Font(FontFamily.GenericSansSerif, 30), new SolidBrush(Color.White), 320, 230);
                graphics.DrawString("Press SPACE for new game", new Font(FontFamily.GenericSansSerif, 30), new SolidBrush(Color.White), 150, 350);
            }

            pictureBox.Image = map;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsGameOver)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        Controller.ChangeKolobokDirection(Direction.UP);
                        break;

                    case Keys.A:
                        Controller.ChangeKolobokDirection(Direction.LEFT);
                        break;

                    case Keys.S:
                        Controller.ChangeKolobokDirection(Direction.DOWN);
                        break;

                    case Keys.D:
                        Controller.ChangeKolobokDirection(Direction.RIGHT);
                        break;

                    case Keys.R:
                        if (form == null || form.IsDisposed)
                        {
                            form = new FormReport(Entities);
                            form.Show();
                        }
                        form.KeyDown += FormMain_KeyDown;
                        break;

                    case Keys.Space:
                        Controller.Shoot();
                        break;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Space)
                {
                    Controller.NewGame();
                }
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!IsGameOver)
            {
                Controller.Update();
                Draw();
            }
        }
    }
}

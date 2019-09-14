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
        public PackmanController Controller { get; }
        public ListEntities Entities { get; }
        public GameModel GameModel { get; }
        public int MapWidth { get; }
        public int MapHeight { get; }

        bool gameOver = false;

        public int Score { get; set; }

        public FormMain(PackmanController controller, ListEntities entities, GameModel gameModel, int mapWidth, int mapHeight)
        {
            InitializeComponent();
            Controller = controller;
            Entities = entities;
            GameModel = gameModel;
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            controller.NewGame();
            Draw();
        }

        private void Draw()
        {
            Bitmap map = new Bitmap(MapWidth, MapHeight);
            Graphics graphics = Graphics.FromImage(map);

            if (!gameOver)
            {
                graphics.FillRectangle(new SolidBrush(Color.DarkGray), 0, 0, MapWidth, MapHeight);

                Entities.Kolobok.Draw(graphics);

                foreach (var wall in Entities.Walls)
                {
                    wall.Draw(graphics);
                }

                foreach (var apple in Entities.Apples)
                {
                    apple.Draw(graphics);
                }

                foreach (var tank in Entities.Tanks)
                {
                    tank.Draw(graphics);
                }

                foreach (var bullet in Entities.Bullets)
                {
                    bullet.Draw(graphics);
                }
            }
            else
            {
                graphics.FillRectangle(new SolidBrush(Color.DarkGray), 0, 0, MapWidth, MapHeight);
                graphics.DrawString("Game over", new Font(FontFamily.GenericSansSerif, 30), new SolidBrush(Color.White), 300, 200);

            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    PackmanController.ChangePackmanDirection(eDirection.UP);
                    break;
                case Keys.A:
                    PackmanController.ChangePackmanDirection(eDirection.LEFT);
                    break;
                case Keys.S:
                    PackmanController.ChangePackmanDirection(eDirection.DOWN);
                    break;
                case Keys.D:
                    PackmanController.ChangePackmanDirection(eDirection.RIGHT);
                    break;
                case Keys.R:
                    FormReport form = new FormReport();
                    form.Show();
                    break;
                case Keys.Space:
                    PackmanController.Shoot();
                    break;
                default:break;
            }
        }
    }
}

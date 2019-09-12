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
        public IPackmanController Controller { get; }
        public int MapWidth { get; }
        public int MapHeight { get; }

        bool gameOver = false;

        public ListEntities entities = new ListEntities();

        public FormMain(IPackmanController controller, ListEntities entities, int mapWidth, int mapHeight)
        {
            InitializeComponent();
            Controller = controller;
            this.entities = entities;
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

                entities.Kolobok.Draw(graphics);

                foreach (var wall in entities.Walls)
                {
                    wall.Draw(graphics);
                }

                foreach (var apple in entities.Apples)
                {
                    apple.Draw(graphics);
                }

                foreach (var tank in entities.Tanks)
                {
                    tank.Draw(graphics);
                }

                foreach (var bullet in entities.Bullets)
                {
                    bullet.Draw(graphics);
                }


            }
        }

    }
}

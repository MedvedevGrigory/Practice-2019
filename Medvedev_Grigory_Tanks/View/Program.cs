﻿using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    static class Program
    {
        

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int mapWidth = 800;
            int mapHeight = 500;

            ListEntities entities = new ListEntities();
            IGameModel gameModel = new GameModel(mapWidth, mapHeight, entities);
            IPackmanController controller = new PackmanController(gameModel);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(controller, entities, mapWidth, mapHeight));
        }
    }
}

using Controller;
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
            MovableObject.speed = 3;
            int maxAppleCount = 5;
            int maxTankCount = 5;

            ListEntities entities = new ListEntities();
            GameModel gameModel = new GameModel(mapWidth, mapHeight, entities, maxAppleCount, maxTankCount);
            PackmanController controller = new PackmanController(gameModel);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(controller, entities, mapWidth, mapHeight));
        }
    }
}

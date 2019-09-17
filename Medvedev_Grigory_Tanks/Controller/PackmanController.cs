using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PackmanController
    {
        GameModel gameModel;
        public bool IsGameOver => gameModel.IsGameOver;
        public int Score => gameModel.Score;

        public PackmanController(GameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        public void NewGame()
        {
            gameModel.NewGame();
        }

        public void Update()
        {
            gameModel.Update();
        }

        public void ChangeKolobokDirection(Direction direction)
        {
            gameModel.ChangeKolobokDirection(direction);
        }

        public void Shoot()
        {
            gameModel.Shoot();
        }
    }
}

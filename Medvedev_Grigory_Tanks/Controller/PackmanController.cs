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

        public PackmanController(GameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        public int Score { get => throw new NotImplementedException(); }

        public void NewGame()
        {
            gameModel.NewGame();
        }

        public void Update(int dt)
        {
            gameModel.Update();
        }

        public void ChangeKolobokDirection(eDirection direction)
        {
            gameModel.ChangePackmanDirection(direction);
        }

        public static void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}

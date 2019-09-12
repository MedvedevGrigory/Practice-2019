using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PackmanController : IPackmanController
    {
        private IGameModel gameModel;

        public PackmanController(IGameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        public int Score { get => throw new NotImplementedException(); }

        public void NewGame()
        {
            throw new NotImplementedException();
        }

        public void Update(int dt)
        {
            throw new NotImplementedException();
        }
    }
}

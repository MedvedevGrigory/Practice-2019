using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IPackmanController
    {
        void NewGame();
        void Update(int dt);
        int Score { get; }
    }
}

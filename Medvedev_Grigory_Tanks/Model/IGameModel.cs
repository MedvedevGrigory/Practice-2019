using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IGameModel
    {
        int Score { get; set; }
        int MapWidth { get; set; }
        int MapHeight { get; set; }
        void NewGame(bool gameOver);
        void Update();
        void GameOver();
        void Shoot();
        void ChangeDirection(eDirection direction);
    }
}

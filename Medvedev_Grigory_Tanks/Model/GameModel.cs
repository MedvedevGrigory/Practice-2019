using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model
{
    public class GameModel : IGameModel
    {
        public int Score { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MapWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MapHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ListEntities Entities;

        public GameModel(int mapWidth, int mapHeight, ListEntities entities)
        {
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            Entities = entities;
        }

        public void ChangeDirection(eDirection direction)
        {
            throw new NotImplementedException();
        }

        public void GameOver()
        {
            throw new NotImplementedException();
        }

        public void NewGame(bool gameOver)
        {
            throw new NotImplementedException();
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

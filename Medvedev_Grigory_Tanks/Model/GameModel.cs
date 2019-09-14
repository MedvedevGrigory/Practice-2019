using System;

namespace Model
{
    public struct Pos
    {
        public int x, y;
    }

    public struct Size
    {
        public int width, height;
    }

    public class GameModel
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

        public void ChangePackmanDirection(eDirection direction)
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

        public void ChangeTankDirection(eDirection direction)
        {
            throw new NotImplementedException();
        }
    }
}

using System;

namespace Model
{
    public struct Position
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
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }

        public ListEntities Entities;
        int speed;

        public GameModel(int mapWidth, int mapHeight, ListEntities entities)
        {
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            Entities = entities;
        }

        public void ChangePackmanDirection(eDirection direction)
        {
            Entities.Kolobok.Direction = direction;
        }

        public void GameOver()
        {
            throw new NotImplementedException();
        }

        public void NewGame()
        {
            Position pos = new Position() { x = 10, y = 400 };
            Entities.Kolobok = new KolobokView(pos);
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            Move();
        }

        private void Move()
        {
            speed = Entities.Kolobok.speed;
            switch (Entities.Kolobok.Direction)
            {
                case eDirection.LEFT:
                    Entities.Kolobok.Pos.x -= speed;
                    break;

                case eDirection.RIGHT:
                    Entities.Kolobok.Pos.x += speed;
                    break;

                case eDirection.UP:
                    Entities.Kolobok.Pos.y -= speed;
                    break;

                case eDirection.DOWN:
                    Entities.Kolobok.Pos.y += speed;
                    break;
            }
        }

        public void ChangeTankDirection(eDirection direction)
        {
            throw new NotImplementedException();
        }
    }
}

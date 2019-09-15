using System;
using System.Collections.Generic;
using System.Drawing;

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
        public int Score { get ; set ; }
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        Random random = new Random();

        public ListEntities Entities;
        int speed;

        public GameModel(int mapWidth, int mapHeight, ListEntities entities)
        {
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            Entities = entities;
        }

        public void ChangeKolobokDirection(Direction direction)
        {
            Entities.Kolobok.Direction = direction;
            switch (direction)
            {
                case Direction.LEFT:
                    Entities.Kolobok.sprite = Image.FromFile(@"..\..\..\Sprites\KolobokL.png");
                    break;
                case Direction.RIGHT:
                    Entities.Kolobok.sprite = Image.FromFile(@"..\..\..\Sprites\KolobokR.png");
                    break;
                case Direction.UP:
                    Entities.Kolobok.sprite = Image.FromFile(@"..\..\..\Sprites\KolobokU.png");
                    break;
                case Direction.DOWN:
                    Entities.Kolobok.sprite = Image.FromFile(@"..\..\..\Sprites\KolobokD.png");
                    break;
                default:
                    break;
            }
        }

        public void GameOver()
        {
            throw new NotImplementedException();
        }

        public void NewGame()
        {
            Position pos = new Position() { x = 10, y = 400 };
            Entities.Kolobok = new KolobokView(pos);

            Entities.Walls = new List<WallView>();
            InitWalls();

            Entities.Apples = new List<AppleView>();
        }

        private void InitWalls()
        {
            Position pos = new Position() { x = 60, y = 60 };
            for (int i = 0; i < 6; i++)
            {
                Entities.Walls.Add(new WallView(pos));
                pos.y += 50;
            }

            pos.x = 70;
            pos.y = 310;
            for (int i = 0; i < 3; i++)
            {
                Entities.Walls.Add(new WallView(pos));
                pos.x += 50;
            }

            pos.x = 170;
            pos.y = 60;
            for (int i = 0; i < 4; i++)
            {
                Entities.Walls.Add(new WallView(pos));
                pos.y += 50;
            }

            pos.x = 280;
            pos.y = 60;
            for (int i = 0; i < 6; i++)
            {
                Entities.Walls.Add(new WallView(pos));
                pos.y += 50;
            }

            pos.x = 690;
            pos.y = 60;
            for (int i = 0; i < 6; i++)
            {
                Entities.Walls.Add(new WallView(pos));
                pos.y += 50;
            }

            pos.x = 280;
            pos.y = 130;
            for (int i = 0; i < 7; i++)
            {
                Entities.Walls.Add(new WallView(pos));
                pos.x += 50;
            }

            pos.x = 390;
            pos.y = 250;
            for (int i = 0; i < 7; i++)
            {
                Entities.Walls.Add(new WallView(pos));
                pos.x += 50;
            }
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            if (Entities.Apples.Count < 5)
            {
                InitApple();
            }
            
            Move();
        }

        private void InitApple()
        {
            Position pos = new Position()
            {
                x = random.Next(MapWidth - Apple.size.width),
                y = random.Next(MapHeight - Apple.size.height)
            };

            Entities.Apples.Add(new AppleView(pos));
        }

        private void Move()
        {
            speed = Entities.Kolobok.speed;
            switch (Entities.Kolobok.Direction)
            {
                case Direction.LEFT:
                    Entities.Kolobok.Pos.x -= speed;
                    break;

                case Direction.RIGHT:
                    Entities.Kolobok.Pos.x += speed;
                    break;

                case Direction.UP:
                    Entities.Kolobok.Pos.y -= speed;
                    break;

                case Direction.DOWN:
                    Entities.Kolobok.Pos.y += speed;
                    break;
            }
        }

        public void ChangeTankDirection(TankView tank ,Direction direction)
        {
            switch (tank.Direction)
            {
                case Direction.LEFT:
                    tank.Direction = Direction.RIGHT;
                    break;

                case Direction.RIGHT:
                    tank.Direction = Direction.LEFT;
                    break;

                case Direction.UP:
                    tank.Direction = Direction.DOWN;
                    break;

                case Direction.DOWN:
                    tank.Direction = Direction.UP;
                    break;
            }
        }
    }
}

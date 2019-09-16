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
        public int Score { get; set; }
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }

        public bool GameOver { get; set; }


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

        public void NewGame()
        {
            Position pos = new Position() { x = 10, y = 400 };
            Entities.Kolobok = new KolobokView(pos);

            Entities.Walls = new List<WallView>();
            InitWalls();

            Entities.Apples = new List<AppleView>();

            Entities.Tanks = new List<TankView>();
        }

        private void InitWalls()
        {
            Position pos = new Position() { x = 60, y = 60 };
            for (int i = 0; i < 6; i++)
            {
                Entities.Walls.Add(new WallView(pos));
                pos.y += 50;
            }

            pos.x = 60;
            pos.y = 360;
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
            for (int i = 0; i < 7; i++)
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

            pos.x = 330;
            pos.y = 130;
            for (int i = 0; i < 6; i++)
            {
                Entities.Walls.Add(new WallView(pos));
                pos.x += 50;
            }

            pos.x = 390;
            pos.y = 250;
            for (int i = 0; i < 6; i++)
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

            if (Entities.Tanks.Count < 5)
            {
                InitTank();
            }

            CheckCollisions();
            RandomChangeTankDirection();
            ChangeTankSprite();
            Move();
        }

        private void ChangeTankSprite()
        {
            foreach (var tank in Entities.Tanks)
            {
                switch (tank.Direction)
                {
                    case Direction.LEFT:
                        tank.sprite = Image.FromFile(@"..\..\..\Sprites\TankL.png");
                        break;
                    case Direction.RIGHT:
                        tank.sprite = Image.FromFile(@"..\..\..\Sprites\TankR.png");
                        break;
                    case Direction.UP:
                        tank.sprite = Image.FromFile(@"..\..\..\Sprites\TankU.png");
                        break;
                    case Direction.DOWN:
                        tank.sprite = Image.FromFile(@"..\..\..\Sprites\TankD.png");
                        break;
                }
            }
        }

        private void RandomChangeTankDirection()
        {
            Random random = new Random();

            foreach (var tank in Entities.Tanks)
            {
                if (random.Next(500) < 10)
                {
                    tank.Direction = (Direction)random.Next(4);
                } 
            }
        }

        private void CheckCollisions()
        {
            CheckPlayerBounds();

            foreach (var tank in Entities.Tanks)
            {
                Size sizeTank = Tank.size;

                if (boxCollides(tank.Pos, sizeTank, Entities.Kolobok.Pos, Entities.Kolobok.size))
                {
                    //GameOver = true;
                }

                if ((tank.Pos.x < 0) || 
                    (tank.Pos.x > MapWidth - Tank.size.width)||
                    (tank.Pos.y < 0)||
                    (tank.Pos.y > MapHeight - Tank.size.height))
                {
                    ChangeTankDirection(tank, tank.Direction);
                }

                foreach (var otherTank in Entities.Tanks)
                {
                    if (otherTank != tank)
                    {
                        if (boxCollides(tank.Pos, sizeTank, otherTank.Pos, sizeTank))
                        {
                            ChangeTankDirection(tank, tank.Direction);
                            ChangeTankDirection(otherTank, otherTank.Direction);
                            break;
                        } 
                    }
                }

                foreach (var wall in Entities.Walls)
                {
                    Position posWall = wall.Pos;
                    Size sizeWall = wall.size;

                    if (boxCollides(tank.Pos, sizeTank, posWall, sizeWall))
                    {
                        ChangeTankDirection(tank, tank.Direction);
                        break;
                    }
                }
            }
        }

        private bool boxCollides(Position pos, Size size, Position pos2, Size size2)
        {
            return collides(pos.x,
                            pos.y,
                            pos.x + size.width,
                            pos.y + size.height,
                            pos2.x,
                            pos2.y,
                            pos2.x + size2.width,
                            pos2.y + size2.height);
        }

        private bool collides(int x, int y, int r, int b, int x2, int y2, int r2, int b2)
        {
            return !(r <= x2 || x >= r2 ||
                    b <= y2 || y >= b2);
        }

        private void CheckPlayerBounds()
        {
            KolobokView kolobok = Entities.Kolobok;
            if (kolobok.Pos.x < 0)
            {
                kolobok.Pos.x = 0;
            }
            else if (kolobok.Pos.x > MapWidth - kolobok.size.width)
            {
                kolobok.Pos.x = MapWidth - kolobok.size.width;
            }

            if (kolobok.Pos.y < 0)
            {
                kolobok.Pos.y = 0;
            }
            else if (kolobok.Pos.y > MapHeight - kolobok.size.height)
            {
                kolobok.Pos.y = MapHeight - kolobok.size.height;
            }
        }

        private void InitTank()
        {
            Random random = new Random();

            Position pos = new Position()
            {
                x = random.Next(MapWidth - Tank.size.width),
                y = random.Next(MapHeight - Tank.size.height)
            };

            foreach (var wall in Entities.Walls)
            {
                Position posWall = wall.Pos;
                Size sizeWall = wall.size;

                if (boxCollides(pos, Tank.size, posWall, sizeWall))
                {
                    return;
                }
            }

            foreach (var tank in Entities.Tanks)
            {
                Position posTank = tank.Pos;

                if (boxCollides(pos, Tank.size, posTank, Tank.size))
                {
                    return;
                }
            }

            Direction direction = (Direction)random.Next(4);

            Entities.Tanks.Add(new TankView(pos, direction));
        }

        private void InitApple()
        {
            Random random = new Random();

            Position pos = new Position()
            {
                x = random.Next(MapWidth - Apple.size.width),
                y = random.Next(MapHeight - Apple.size.height)
            };

            Entities.Apples.Add(new AppleView(pos));
        }

        private void Move()
        {
            speed = MovableObject.speed;
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

            foreach (var tank in Entities.Tanks)
            {
                switch (tank.Direction)
                {
                    case Direction.LEFT:
                        tank.Pos.x -= speed;
                        break;

                    case Direction.RIGHT:
                        tank.Pos.x += speed;
                        break;

                    case Direction.UP:
                        tank.Pos.y -= speed;
                        break;

                    case Direction.DOWN:
                        tank.Pos.y += speed;
                        break;
                }
            }
        }

        public void ChangeTankDirection(TankView tank, Direction direction)
        {
            switch (tank.Direction)
            {
                case Direction.LEFT:
                    tank.Pos.x += speed;
                    tank.Direction = Direction.RIGHT;
                    break;

                case Direction.RIGHT:
                    tank.Pos.x -= speed;
                    tank.Direction = Direction.LEFT;
                    break;

                case Direction.UP:
                    tank.Pos.y += speed;
                    tank.Direction = Direction.DOWN;
                    break;

                case Direction.DOWN:
                    tank.Pos.y -= speed;
                    tank.Direction = Direction.UP;
                    break;
            }
        }
    }
}

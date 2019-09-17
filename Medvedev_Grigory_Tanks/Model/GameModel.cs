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

        public bool IsGameOver { get; set; }

        public ListEntities Entities;
        int speed;

        public int maxAppleCount = 5;
        public int maxTankCount = 5;

        public GameModel(int mapWidth, int mapHeight, ListEntities entities, int maxAppleCount, int maxTankCount)
        {
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            Entities = entities;
            this.maxAppleCount = maxAppleCount;
            this.maxTankCount = maxTankCount;
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
            IsGameOver = false;
            Score = 0;
            Position pos = new Position() { x = 10, y = 450 };
            Entities.Kolobok = new KolobokView(pos);

            Entities.Walls = new List<WallView>();
            InitWalls();

            Entities.Apples = new List<AppleView>();

            Entities.Tanks = new List<TankView>();

            Entities.Bullets = new List<BulletView>();
        }

        private void InitWalls()
        {
            Position pos = new Position() { x = 60, y = 60 };
            for (int i = 0; i < 2; i++)
            {
                Entities.Walls.Add(new WallView(pos));
                pos.y += 50;
            }

            pos.x = 60;
            pos.y = 260;
            for (int i = 0; i < 2; i++)
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
            KolobokView kolobok = Entities.Kolobok;
            Position pos = new Position()
            {
                x = kolobok.Pos.x + kolobok.size.width / 2 - Bullet.size.width / 2,
                y = kolobok.Pos.y + kolobok.size.height / 2 - Bullet.size.height / 2
            };

            Entities.Bullets.Add(new BulletView(pos, kolobok.Direction, false));
        }

        public void Update()
        {
            if (Entities.Apples.Count < maxAppleCount)
            {
                InitApple();
            }

            if (Entities.Tanks.Count < maxTankCount)
            {
                InitTank();
            }

            CheckCollisions();
            RandomChangeTankDirection();

            foreach (var tank in Entities.Tanks)
            {
                TankShoot(tank, Tank.size, Entities.Kolobok);
            }

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
            CheckKolobokCollisoins();

            CheckTanksCollisions();

            foreach (var bullet in Entities.Bullets)
            {
                if (CheckBulletCollisions(bullet))
                {
                    break;
                }
            }
        }

        private void CheckTanksCollisions()
        {
            foreach (var tank in Entities.Tanks)
            {
                Size sizeTank = Tank.size;
                KolobokView kolobok = Entities.Kolobok;

                if (BoxCollides(tank.Pos, sizeTank, kolobok.Pos, kolobok.size))
                {
                    GameOver();
                    return;
                }


                if ((tank.Pos.x < 0) ||
                    (tank.Pos.x > MapWidth - Tank.size.width) ||
                    (tank.Pos.y < 0) ||
                    (tank.Pos.y > MapHeight - Tank.size.height))
                {
                    ChangeTankDirection(tank, tank.Direction);
                    MoveTank(tank);
                }

                foreach (var otherTank in Entities.Tanks)
                {
                    if (otherTank != tank)
                    {
                        if (BoxCollides(tank.Pos, sizeTank, otherTank.Pos, sizeTank))
                        {
                            ChangeTankDirection(tank, tank.Direction);
                            MoveTank(tank);
                            //ChangeTankDirection(otherTank, otherTank.Direction);
                            break;
                        }
                    }
                }

                foreach (var wall in Entities.Walls)
                {
                    Position posWall = wall.Pos;
                    Size sizeWall = wall.size;

                    if (BoxCollides(tank.Pos, sizeTank, posWall, sizeWall))
                    {
                        ChangeTankDirection(tank, tank.Direction);
                        MoveTank(tank);
                        break;
                    }
                }
            }
        }

        private void MoveTank(TankView tank)
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

        private bool CheckBulletCollisions(BulletView bullet)
        {
            Size sizeBullet = Bullet.size;
            Position posBullet = bullet.Pos;

            if (bullet.isEnemyBullet)
            {
                if (BoxCollides(posBullet, sizeBullet, Entities.Kolobok.Pos, Entities.Kolobok.size))
                {
                    GameOver();
                    return true;
                } 
            }

            if ((posBullet.x < 0) ||
                (posBullet.x > MapWidth - Bullet.size.width) ||
                (posBullet.y < 0) ||
                (posBullet.y > MapHeight - Bullet.size.height))
            {
                Entities.Bullets.Remove(bullet);
                return true;
            }

            foreach (var wall in Entities.Walls)
            {
                Position posWall = wall.Pos;
                Size sizeWall = wall.size;

                if (BoxCollides(posBullet, sizeBullet, posWall, sizeWall))
                {
                    Entities.Bullets.Remove(bullet);
                    return true;
                }
            }

            if (!bullet.isEnemyBullet)
            {
                foreach (var tank in Entities.Tanks)
                {
                    Position posTank = tank.Pos;
                    Size sizeTank = Tank.size;

                    if (BoxCollides(posBullet, sizeBullet, posTank, sizeTank))
                    {
                        Entities.Bullets.Remove(bullet);
                        Entities.Tanks.Remove(tank);
                        return true;
                    }
                } 
            }

            //foreach (var otherBullet in Entities.Bullets)
            //{
            //    Position posOtherBullet = otherBullet.Pos;

            //    if (otherBullet != bullet)
            //    {
            //        if (boxCollides(posBullet, sizeBullet, posOtherBullet, sizeBullet))
            //        {
            //            Entities.Bullets.Remove(bullet);
            //            Entities.Bullets.Remove(otherBullet);
            //            return true;
            //        } 
            //    }
            //}

            return false;
        }

        private void TankShoot(TankView tank, Size sizeTank, KolobokView kolobok)
        {
            Position pos = new Position();
            Size size = new Size();

            pos.x = 0;
            pos.y = tank.Pos.y;

            size.width = tank.Pos.x + sizeTank.width;
            size.height = sizeTank.height;
            
            if (BoxCollides(pos, size, kolobok.Pos, kolobok.size))
            {
                if (!IsWallCollisions(pos, size))
                {
                    ChangeTankDirection(tank, Direction.RIGHT);
                    InitTankBullet(tank, sizeTank); 
                }
            }

            pos.x = tank.Pos.x;
            pos.y = tank.Pos.y;

            size.width = MapWidth - tank.Pos.x - sizeTank.width;
            size.height = sizeTank.height;

            if (BoxCollides(pos, size, kolobok.Pos, kolobok.size))
            {
                if (!IsWallCollisions(pos, size))
                {
                    ChangeTankDirection(tank, Direction.LEFT);
                    InitTankBullet(tank, sizeTank);
                }
            }

            pos.x = tank.Pos.x;
            pos.y = tank.Pos.y;

            size.width = sizeTank.width;
            size.height = MapHeight - tank.Pos.y - sizeTank.height;

            if (BoxCollides(pos, size, kolobok.Pos, kolobok.size))
            {
                if (!IsWallCollisions(pos, size))
                {
                    ChangeTankDirection(tank, Direction.UP);
                    InitTankBullet(tank, sizeTank);
                }
            }

            pos.x = tank.Pos.x;
            pos.y = 0;

            size.width = sizeTank.width;
            size.height = tank.Pos.y + sizeTank.height;

            if (BoxCollides(pos, size, kolobok.Pos, kolobok.size))
            {
                if (!IsWallCollisions(pos, size))
                {
                    ChangeTankDirection(tank, Direction.DOWN);
                    InitTankBullet(tank, sizeTank);
                }
            }
        }

        private bool IsWallCollisions(Position pos, Size size)
        {
            foreach (var wall in Entities.Walls)
            {
                if (BoxCollides(pos, size, wall.Pos, wall.size))
                {
                    return true;
                }
            }

            return false;
        }

        private void InitTankBullet(TankView tank, Size sizeTank)
        {
            Random random = new Random();
            if (random.Next(300) < 10)
            {
                Position posBullet = new Position()
                {
                    x = tank.Pos.x + sizeTank.width / 2 - Bullet.size.width / 2,
                    y = tank.Pos.y + sizeTank.height / 2 - Bullet.size.height / 2
                };
                Entities.Bullets.Add(new BulletView(posBullet, tank.Direction, true));
            }
        }

        private void GameOver()
        {
            IsGameOver = true;
            Entities.Apples.Clear();
            Entities.Tanks.Clear();
            Entities.Bullets.Clear();
            Entities.Walls.Clear();
        }

        private bool BoxCollides(Position pos, Size size, Position pos2, Size size2)
        {
            return Collides(pos.x,
                            pos.y,
                            pos.x + size.width,
                            pos.y + size.height,
                            pos2.x,
                            pos2.y,
                            pos2.x + size2.width,
                            pos2.y + size2.height);
        }

        private bool Collides(int x, int y, int r, int b, int x2, int y2, int r2, int b2)
        {
            return !(r <= x2 || x > r2 ||
                    b <= y2 || y > b2);
        }

        private void CheckKolobokCollisoins()
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

            foreach (var apple in Entities.Apples)
            {
                if (BoxCollides(apple.Pos, Apple.size, kolobok.Pos, kolobok.size))
                {
                    Entities.Apples.Remove(apple);
                    Score++;
                    break;
                }
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

                if (BoxCollides(pos, Tank.size, posWall, sizeWall))
                {
                    return;
                }
            }

            foreach (var tank in Entities.Tanks)
            {
                Position posTank = tank.Pos;

                if (BoxCollides(pos, Tank.size, posTank, Tank.size))
                {
                    return;
                }
            }

            if (BoxCollides(pos, Tank.size, Entities.Kolobok.Pos, Entities.Kolobok.size))
            {
                return;
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

            foreach (var wall in Entities.Walls)
            {
                Position posWall = wall.Pos;
                Size sizeWall = wall.size;

                if (BoxCollides(pos, Apple.size, posWall, sizeWall))
                {
                    return;
                }
            }

            foreach (var tank in Entities.Tanks)
            {
                Position posTank = tank.Pos;

                if (BoxCollides(pos, Apple.size, posTank, Apple.size))
                {
                    return;
                }

            }

            Entities.Apples.Add(new AppleView(pos));
        }

        private void Move()
        {
            speed = MovableObject.speed;
            switch (Entities.Kolobok.Direction)
            {
                case Direction.LEFT:
                    if (!CheckWallsCollision(-speed, 0))
                    {
                        Entities.Kolobok.Pos.x -= speed; 
                    }
                    break;

                case Direction.RIGHT:
                    if (!CheckWallsCollision(speed, 0))
                    {
                        Entities.Kolobok.Pos.x += speed; 
                    }
                    break;

                case Direction.UP:
                    if (!CheckWallsCollision(0, -speed))
                    {
                        Entities.Kolobok.Pos.y -= speed; 
                    }
                    break;

                case Direction.DOWN:
                    if (!CheckWallsCollision(0, speed))
                    {
                        Entities.Kolobok.Pos.y += speed; 
                    }
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

            foreach (var bullet in Entities.Bullets)
            {
                switch (bullet.Direction)
                {
                    case Direction.LEFT:
                        bullet.Pos.x -= 2 * speed;
                        break;

                    case Direction.RIGHT:
                        bullet.Pos.x += 2 * speed;
                        break;

                    case Direction.UP:
                        bullet.Pos.y -= 2 * speed;
                        break;

                    case Direction.DOWN:
                        bullet.Pos.y += 2 * speed;
                        break;
                }
            }
        }

        private bool CheckWallsCollision(int x, int y)
        {
            Position pos2 = new Position
            {
                x = Entities.Kolobok.Pos.x + x,
                y = Entities.Kolobok.Pos.y + y
            };

            foreach (var wall in Entities.Walls)
            {
                Position posWall = wall.Pos;
                Size sizeWall = wall.size;

                if (BoxCollides(pos2, Entities.Kolobok.size, posWall, sizeWall))
                {
                    return true;
                }
            }

            return false;
        }

        public void ChangeTankDirection(TankView tank, Direction direction)
        {
            switch (direction)
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

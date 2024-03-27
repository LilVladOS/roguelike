using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RIGALIK.Visual
{
    internal class Map
    {
        private readonly int _width;
        private readonly int _height;
        private readonly char[,] _tiles;
        private readonly Random _random;
        private int _exitX;
        private int _exitY; 
        private Player _player;
        private List<Enemy> _enemies;
        private char[,] _previousTiles;
        public Map(int width, int height,Player player)
        {  
            _width = width;
            _height = height;
            _tiles = new char[width, height];
            _random = new Random();
            _player = player;
            _enemies = new List<Enemy>();
            _previousTiles = new char[width, height];
        }
        public bool IsCellWalkable(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                return false;
            return _tiles[x, y] == ' ';
        }
        public bool CheckExitReached(int playerX, int playerY)
        {
            return playerX == _exitX && playerY == _exitY;
        }

        public void GenerationRandomMap()
        {
            
            
            //Filling da map with wall
            for (int y = 0; y < _height; y++) 
            {
                for(int  x = 0; x < _width; x++) 
                {
                    _tiles[x, y] = '#';
                }
            }


            // добавляет вверхнюю границу-filling the top boundary
            for (int x = 0; x < _width; x++)
            {
                _tiles[x, 0] = '#';
            }

            //choosing a random starting position
            int startX = _random.Next(1, _width - 2);
            int startY = _random.Next(1, _height - 2);

            //Player player = new Player(startX, startY);
            //_player = player;
            //_player = new Player(startX, startY);
            

            GenerateMaze(startX, startY);
            BreakWalls(15);//Метод крушения стен- Breaking walls method
            //FillWalls();

            //choosing random exit position
            int side = _random.Next(4);
            switch (side) 
            {
                case 0: //Top
                    _exitX = _random.Next(2, _width - 2);
                    _exitY = 0;
                    break;
                case 1: // Right
                    _exitX = _width - 1;
                    _exitY = _random.Next(2, _height - 2);
                    break;
                case 2: // Bottom
                    _exitX = _random.Next(2, _width - 2);
                    _exitY = _height - 1;
                    break;
                case 3: // Left
                    _exitX = 0;
                    _exitY = _random.Next(2, _height - 2);
                    break;

            }
            _tiles[_exitX, _exitY] = ' ';
        }
        private void BreakWalls(int numWallsToBreak)
        {
            for (int y = 1; y < _height - 1; y++)
            {
                for (int x = 1; x < _width - 1; x++)
                {
                    if (_tiles[x, y] == '#')
                    {
                        // Проверяем соседние ячейки
                        List<char> neighbors = new List<char>
                {
                    _tiles[x, y - 1], // Верхняя соседняя ячейка
                    _tiles[x, y + 1], // Нижняя соседняя ячейка
                    _tiles[x - 1, y], // Левая соседняя ячейка
                    _tiles[x + 1, y]  // Правая соседняя ячейка
                };

                        // Если хотя бы одна соседняя ячейка проходима, разрушаем стену
                        if (neighbors.Contains(' '))
                        {
                            _tiles[x, y] = ' ';
                        }
                    }
                }
            }
        }
        private void FillWalls()
        {
            for (int y = 0; y < _height; ++y)
            {
                for (int x=0; x < _width; ++x)
                {
                    _tiles[x, y] = '#';
                }
            }
        }

        private void Shuffle<T>(T[] array)
        {
            Random random = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        private void GenerateMaze(int x, int y) 
        {
            //установление текущей точки как проходимой-setting the current cell as passable
            _tiles[x, y] = ' ';

            //Случайное перемешивание порядка направления-random shuffle of the order of directions
            int[] directions = { 1, 2, 3, 4, };

            Shuffle(directions); // Перемешать направления

            foreach (int direction in directions)
            {
                switch (direction)
                {
                    case 1: // Вверх
                        if (y - 2 > 0 && _tiles[x, y - 2] == '#')
                        {
                            _tiles[x, y - 1] = ' ';
                            GenerateMaze(x, y - 2);
                        }
                        break;
                    case 2: // Вниз
                        if (y + 2 < _height - 1 && _tiles[x, y + 2] == '#')
                        {
                            _tiles[x, y + 1] = ' ';
                            GenerateMaze(x, y + 2);
                        }
                        break;
                    case 3: // Влево
                        if (x - 2 > 0 && _tiles[x - 2, y] == '#')
                        {
                            _tiles[x - 1, y] = ' ';
                            GenerateMaze(x - 2, y);
                        }
                        break;
                    case 4: // Вправо
                        if (x + 2 < _width - 1 && _tiles[x + 2, y] == '#')
                        {
                            _tiles[x + 1, y] = ' ';
                            GenerateMaze(x + 2, y);
                        }
                        break;
                }
            }


            /*for (int i=0; i<directions.Length; i++)
            {
                int tmp = directions[i];
                int r=_random.Next(i, directions.Length);
                directions[i] = directions[r];
                directions[r] = tmp;
            }
            foreach (int direction in directions)
            {
                switch (direction) 
                {
                    case 1:
                        if (y - 2 <= 0) continue;
                        if (_tiles[x, y - 2]!=' ')
                        {
                            _tiles[x, y - 1] = ' ';
                            GenerateMaze(x, y-2);
                        }
                         break;
                    case 2:
                        if (y + 2 >= _height-1) continue;
                        if (_tiles[x, y + 2] != ' ')
                        {
                            _tiles[x, y + 1] = ' ';
                            GenerateMaze(x, y + 2);
                        }
                        break;
                    case 3:
                        if (x - 2 <= 0) continue;
                        if (_tiles[x - 2, y ] != ' ')
                        {
                            _tiles[x - 1, y] = ' ';
                            GenerateMaze(x - 2, y );
                        }
                        break;
                    case 4:
                        if (x + 2 >= _width - 1) continue;
                        if (_tiles[x + 2, y ] != ' ')
                        {
                            _tiles[x + 1, y ] = ' ';
                            GenerateMaze(x + 2, y);
                        }
                        break;
                }
            }*/
        }

        /*public bool CheckExitReached(int playerX, int playerY)
         {
             return playerX == _exitX && playerY == _exitY;
         }*/

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        private void DrawEnemies()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Draw();
            }
        }



        public void Draw()
        {
            Console.Clear();
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (x == _player.X && y == _player.Y)
                    {
                        Console.Write('@');
                    }
                    else
                    {
                        bool enemyDrawn = false;
                        foreach (var enemy in _enemies)
                        {
                            if (enemy.Position.X == x && enemy.Position.Y == y && !enemy.IsDead)
                            {
                                Console.Write(enemy.Symbol);
                                enemyDrawn = true;
                                break;
                            }
                        }
                        if (!enemyDrawn)
                        {
                            Console.Write(_tiles[x, y]);
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Score: {_player.Score}  Health: {_player.Health}");
        }

        /*public void DrawUpdatedCells()
        {
            Console.SetCursorPosition(0, 0); // Сбрасываем позицию курсора в левый верхний угол

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    // Очищаем предыдущую позицию игрока, если он переместился
                    if (_previousTiles[x, y] != _tiles[x, y] && _previousTiles[x, y] == '@')
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(' '); // Очищаем старую позицию игрока
                    }

                    // Если содержимое клетки изменилось, или это позиция игрока, то рисуем ее заново
                    if (_tiles[x, y] != _previousTiles[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        if (_tiles[x, y] == '@')
                        {
                            Console.Write('@');
                        }
                        else
                        {
                            Console.Write(_tiles[x, y]);
                        }
                        _previousTiles[x, y] = _tiles[x, y]; // Обновляем предыдущее состояние
                    }
                }
            }

            // После отрисовки обновленных клеток, сбрасываем позицию курсора в нижний правый угол,
            // чтобы при следующем обновлении перерисовать только измененные клетки
            Console.SetCursorPosition(_width, _height);
        }*/

    }
}
/*
 * 
 */
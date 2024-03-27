using System;
using RIGALIK;
using RIGALIK.Visual;

class Program
{
    static void Main(string[] args)
    {
       // Map map = new Map(30, 20, player);

        int playerStartX = 1;
        int playerStartY = 1;
        Player player = new Player(playerStartX, playerStartY);



        // Создаем экземпляр класса Map
        Map map = new Map(30, 20, player);
        

        // Генерируем случайный лабиринт
        map.GenerationRandomMap();


        // Отображаем лабиринт в консоли
        map.Draw();

        UI ui = new UI();

        while (true)
        {
            

            // Отображаем лабиринт вместе с игроком
            map.Draw();

            // Ожидаем ввода от пользователя
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // Обрабатываем ввод игрока и обновляем его позицию
            player.ProcessInput(keyInfo);

            // Проверяем, достиг ли игрок выхода из лабиринта
            if (map.CheckExitReached(player.X, player.Y))
            {
                
                
            }
            //map.DrawUpdatedCells();
            ui.DisplayScore(player.Score);
            ui.DisplayHealth(player.Health);
        }
    }
}

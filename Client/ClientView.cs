using System;
using System.Collections.Generic;


namespace Client
{
    class View
    {

        public static void ResetConsole()
        {
            Console.Clear();
            Console.WriteLine(Graphics.GetLogo());
        }
        public static void GreetUser()
        {
            ResetConsole();
            Console.WriteLine("Давайте начнём работу с DataHandler!\n");
        }
        public static void PrintMenu()
        {
            Console.WriteLine("Что вы хотите сделать с файлом?" + '\n' +
            "Для выбора нажмите нужную кнопку:" + '\n' +
            "0. Выбрать файл для чтения и записи." + '\n' +
            "1. Вывести все строки файла. " + '\n' +
            "2. Вывести запись по номеру." + '\n' +
            "3. Записать новые данные в файл." + '\n' +
            "4. Удалить запись из файла." + '\n' +
            "esc. Завершить работу." + '\n');
        }
        public static void PrintByNumber(RequestController rc)
        {
            Console.WriteLine("Введите номер записи.");
            int position = int.Parse(Console.ReadLine());
            ResetConsole();
            Console.WriteLine(rc.GetLineByNumber(position));
        }
        public static void SaveNewData(RequestController rc)
        {
            string input = "";
            List<string> productData = new List<string>();

            Console.WriteLine("Введите название товара: ");
            while (!Validator.IsCorrectString(input))
            {
                input = Console.ReadLine();
            }
            productData.Add(input);
            input = "";

            Console.WriteLine("Введите название продавца: ");
            while (!Validator.IsCorrectString(input))
            {
                input = Console.ReadLine();
            }
            productData.Add(input);
            input = "";

            Console.WriteLine("Введите описание товара: ");
            while (!Validator.IsCorrectString(input))
            {
                input = Console.ReadLine();
            }
            productData.Add(input);
            input = "";

            while (!Validator.IsCorrectPrice(ref input))
            {
                Console.WriteLine("Введите стоимость товара:");
                input = Console.ReadLine();
            }
            productData.Add(input);
            input = "";
                        
            while (!Validator.IsCorrectBool(ref input))
            {
                Console.WriteLine("Есть ли товар в наличии? Да/Нет: ");
                input = Console.ReadLine();
            }
            productData.Add(input);
            input = "";

            while (!Validator.IsCorrectDate(ref input))
            {
                Console.WriteLine("Введите дату появления товара в формате дд.мм.гггг: ");
                input = Console.ReadLine();
            }
            productData.Add(input);

            rc.SaveNewData(productData);
            Console.WriteLine("Запись добавлена!");
        }
        public static void ChangePath(RequestController rc)
        {
            while (true)
            {
                Console.WriteLine("Введите путь до файла:");
                if (rc.SetAndCheckPath(Console.ReadLine()))
                {
                    Console.WriteLine("Файл открыт успешно!");
                    return;
                }
                else Console.WriteLine("Неверно введён путь или файл не существует.");
            }
        }
        public static void DeleteData(RequestController rc)
        {
            Console.WriteLine("Введите номер строки для удаления: ");
            int pos = int.Parse(Console.ReadLine());
            ResetConsole();
            if (rc.DeleteData(pos))
                Console.WriteLine($"Запись по номеру {pos} удалена!\n");
            else
                Console.WriteLine("Ввод некорректен или такой строки нет в файле!\n");
        }

        public static void ProcessUserAction(RequestController rc)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    ResetConsole();
                    ChangePath(rc);
                    break;
                case ConsoleKey.D1: 
                case ConsoleKey.NumPad1:
                    ResetConsole();
                    Console.WriteLine(Graphics.GetLine());
                    Console.WriteLine("Содержимое файла:");
                    rc.GetFullData().ForEach(Console.WriteLine);
                    Console.WriteLine(Graphics.GetLine() + '\n');
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ResetConsole();
                    PrintByNumber(rc);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ResetConsole();
                    SaveNewData(rc);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    DeleteData(rc);
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.WriteLine(Graphics.GetExit());
                    rc.Shutdown();
                    Environment.Exit(0);
                    break;

                default: 
                    Console.WriteLine("Неверный ввод. Введите цифру 1-5.\n");
                    break;
            }
        }
       
        public static void Main(string[] args)
        {
            RequestController rc = new RequestController("127.0.0.1", 8080);
            GreetUser();
            ChooseModel(rc);
            do
            {
                PrintMenu();
                ProcessUserAction(rc);
            } while (true);         
            
        }

        public static void ChooseModel(RequestController rc)
        {
            Console.WriteLine("Выберите тип модели: 1 - csv, 2 - sql");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    rc.SetModelType("csv");
                    ChangePath(rc);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    rc.SetModelType("sql");
                    break;
            }
        }
    }
}

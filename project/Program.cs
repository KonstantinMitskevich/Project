using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace project
{
    class Program
    {
        public static string pathTarifs = @"C:\Users\Exim\Documents\Visual Studio 2013\Projects\С#\project\project\Files\Tarifs.txt";
        public static string pathClients = @"C:\Users\Exim\Documents\Visual Studio 2013\Projects\С#\project\project\Files\Clients.txt";
        public static string pathOrders = @"C:\Users\Exim\Documents\Visual Studio 2013\Projects\С#\project\project\Files\Orders.txt";
        
        static void GetInfo(Firm firm)
        {
            using (StreamReader sr = new StreamReader(pathClients, Encoding.Default))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    Client client = new Client(line.Split(' ')[0], int.Parse(line.Split(' ')[1]));
                    firm.clients.Add(client);
                }
            }
            using (StreamReader sr = new StreamReader(pathTarifs, Encoding.Default))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    Tarif tarif = new Tarif(line.Split(' ')[0], double.Parse(line.Split(' ')[1]));
                    firm.tarifs.Add(tarif);
                }
            }

            using (StreamReader sr = new StreamReader(pathOrders, Encoding.Default))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    Order order = new Order(int.Parse(line.Split(' ')[0]), line.Split(' ')[1], line.Split(' ')[2], double.Parse(line.Split(' ')[3]), double.Parse(line.Split(' ')[4]));
                    firm.orders.Add(order);
                }
            }
        }

        static void Main(string[] args)
        {
            Firm firm = new Firm();
            GetInfo(firm);
            while (true)
            {
                metka:
                Console.Clear();
                Console.WriteLine("Вход в систему (введите цифру)");
                Console.WriteLine("1. Фирма");
                Console.WriteLine("2. Клиент");
                Console.WriteLine("3. Выход");
                int num = 0;
                try
                {
                    num = int.Parse(Console.ReadLine());
                }
                catch
                {
                Console.WriteLine("Неверный выбор!");
                Console.ReadLine();
                }
                switch (num)
                {
                    case 1:
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("1. Просмотр тарифов");
                                Console.WriteLine("2. Ввод тарифа");
                                Console.WriteLine("3. Уменьшение стоимости тарифа");
                                Console.WriteLine("4. Просмотр всех зарегистрированных клиентов");
                                Console.WriteLine("5. Просмотр всех заказов");
                                Console.WriteLine("6. Подсчет суммарной стоимости всех заказов");
                                Console.WriteLine("7. Поиск клиента с максимальным заказом");
                                Console.WriteLine("8. Выход в систему");
                                int choice = 0;
                                try
                                {
                                    choice = int.Parse(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("Неверный выбор!");
                                    Console.ReadLine();
                                }
                                switch (choice)
                                {
                                    case 1:
                                        {
                                            firm.ShowTarifs(firm.tarifs);
                                            Console.ReadLine();
                                            break;
                                        }
                                    case 2:
                                        {
                                            firm.AddTarif(firm.tarifs);
                                            break;
                                        }
                                    case 3:
                                        {
                                            firm.ChangeTarif(firm.tarifs);
                                            break;
                                        }
                                    case 4:
                                        {
                                            firm.AllClients(firm.clients);
                                            break;
                                        }
                                    case 5:
                                        {
                                            firm.AllOrdersShow(firm.orders);
                                            break;
                                        }
                                    case 6:
                                        {
                                            firm.TotalSumCount(firm.orders);
                                            break;
                                        }
                                    case 7:
                                        {
                                            firm.MaxOrderSearch(firm.orders);
                                            break;
                                        }
                                    case 8:
                                        {
                                            goto metka;
                                        }
                                    default: Console.WriteLine("Неверный выбор"); break;
                                    }
                                }
                            }
                        case 2:
                            {
                                while (true)
                                {
                                metka2:
                                    Console.Clear();
                                    Console.WriteLine("1. Зарегистрироваться в системе");
                                    Console.WriteLine("2. Войти");
                                    Console.WriteLine("3. Выход в систему");
                                    int choice = 0;
                                    try
                                    {
                                        choice = int.Parse(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Неверный выбор!");
                                        Console.ReadLine();
                                    }
                                    switch (choice)
                                    {
                                        case 1:
                                            {
                                                firm.ClientRegister(firm.clients);
                                                break;
                                            }
                                        case 2:
                                            {
                                                Client client = firm.Login(firm.clients);
                                                if (firm.clients.Contains(client))
                                                {
                                                    while (true)
                                                    {
                                                        Console.Clear();
                                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                                        Console.WriteLine("Здравствуйте, " + client.Name + "! ");
                                                        Console.ResetColor();
                                                        Console.WriteLine("Пожалуйста, сделайте выбор");
                                                        Console.WriteLine("1. Просмотр Ваших заказов");
                                                        Console.WriteLine("2. Оформить заказ");
                                                        Console.WriteLine("3. Выход");
                                                       
                                                        int ch = int.Parse(Console.ReadLine());
                                                        switch (ch)
                                                        {
                                                            case 1:
                                                                {
                                                                    firm.ShowOrders(firm.orders, client);
                                                                    break;
                                                                }
                                                            case 2:
                                                                {
                                                                    firm.PlaceOrder(firm.orders, firm.tarifs, client);
                                                                    break;
                                                                }
                                                            case 3:
                                                                {
                                                                    goto metka2;
                                                                }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Неверный логин!");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                goto metka;
                                            }
                                        default: Console.WriteLine("Неверный выбор!"); break;
                                    }
                                }
                            }
                        case 3:
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Неверный выбор!");
                                Console.ReadLine();
                                break;
                            }
                }
            }
        }
    }
}

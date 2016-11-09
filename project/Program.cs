using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            Firm firm = new Firm();
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

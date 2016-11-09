using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Firm
    {
        public List<Client> clients = new List<Client>();
        public List<Tarif> tarifs = new List<Tarif>();
        public List<Order> orders = new List<Order>();

        public void ClientRegister(List<Client> clients) // регистрация в системе
        {
            Client client = new Client();
            try
            {
                Console.WriteLine("Введите Ваше Имя");
                client.Name = Console.ReadLine();
                Console.WriteLine("Введите Ваш Id");
                client.ID = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }
            foreach (Client cl in clients)
            {
                if (cl.ID.Equals(client.ID))
                {
                    Console.WriteLine("Клиент с таким Id уже зарегистрирован в системе");
                    Console.ReadLine();
                    return;
                }
            }
            clients.Add(client);
            Console.WriteLine("Регистрация прошла успешно!");
            Console.ReadLine();
        }

        public Client Login(List<Client> clients)// вход в аккаунт
        {
            Console.WriteLine("Введите ваш ID");
            int id = int.Parse(Console.ReadLine());
            foreach (Client cl in clients)
            {
                if (cl.ID.Equals(id))
                {
                    return cl;
                }
            }
            return null;
        }

        public void ShowOrders(List<Order> orders, Client client)// вывод заказов клиента
        {
            int i = 1;
            foreach (Order order in orders)
            {
                if (order.ClientId.Equals(client.ID))
                {
                    Console.WriteLine(i++ + ". " + order);
                }
            }
            Console.ReadLine();
        }

        public void PlaceOrder(List<Order> orders, List<Tarif> tarifs, Client client) // размещение заказа
        {
            Console.WriteLine("Доступные тарифы:");
            ShowTarifs(tarifs);
            Order order = new Order();
            Console.WriteLine();

            Console.WriteLine("Введите направление из имеющихся тарифов");
            string destinationName = Console.ReadLine();
            bool flag = false;
            foreach (Tarif t in tarifs)
            {
                if (t.Destination.Equals(destinationName))
                {
                    order.Destination = t.Destination;
                    order.ClientId = client.ID;
                    order.ClientName = client.Name;
                    order.Price = t.Price;

                    Console.WriteLine("Введите вес груза");
                    order.CargoWeight = double.Parse(Console.ReadLine());
                    if (order.CargoWeight > 2000)
                        order.Price = order.getProcDisount();
                    else
                        order.Price = order.getFixedDiscount();
                    orders.Add(order);

                    flag = true;
                    Console.WriteLine("Ваш заказ оформлен!");
                    Console.ReadLine();
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Некорректный ввод!");
                Console.ReadLine();
                return;
            }
        }

        public void ShowTarifs(List<Tarif> tarifs) // отображение тарифов
        {
            if (tarifs.Count == 0)
            {
                Console.WriteLine("Список тарифов пуст.");
                return;
            }
            foreach (Tarif tarif in tarifs)
            {
                Console.WriteLine(tarif);
            }
        }

        public void AddTarif(List<Tarif> tarifs) //ввод тарифа
        {
            Console.WriteLine("Введите количество тарифов на ввод");
            int number = 0;
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < number; i++)
            {
                Tarif tarif = new Tarif();
                try
                {
                    Console.Write("Введите направление грузоперевозки: ");
                    tarif.Destination = Console.ReadLine();
                    Console.Write("Введите стоимость тарифа: ");
                    tarif.Price = double.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                    return;
                }
                tarifs.Add(tarif);
                Console.WriteLine("Тариф успешно добавлен!");
            }
            Console.ReadLine();
        }

        public void ChangeTarif(List<Tarif> tarifs)
        {
            Console.WriteLine("Доступные тарифы:");
            ShowTarifs(tarifs);
            Console.WriteLine();

            Console.WriteLine("Введите название тарифа для уменьшения стоимости");
            string name = Console.ReadLine();
            Tarif newTarif = null;
            foreach (Tarif tarif in tarifs)
            {
                if (tarif.Destination.Equals(name))
                {
                    Console.WriteLine("Введите скидку в руб.");
                    double money = double.Parse(Console.ReadLine());
                    newTarif = tarif - money; // использование перегруженного бинарного -
                    tarifs.Remove(tarif);
                    tarifs.Add(newTarif);
                    Console.WriteLine("Тариф изменен!");
                    break;
                }
            }
            Console.ReadLine();
        }

        public void AllClients(List<Client> clients) // просмотр всех зарег-х клиентов
        {
            int i = 1;
            foreach (Client cl in clients)
            {
                Console.WriteLine(i++ + ". " + cl);
            }
            Console.ReadLine();
        }

        public void AllOrdersShow(List<Order> orders) // вывод всех заказов
        {
            int i = 1;
            foreach (Order order in orders)
            {
                Console.WriteLine(i++ + ". " + order);
            }
            Console.ReadLine();
        }

        public void TotalSumCount(List<Order> orders) // вывод общей стоимости всех заказов
        {
            double totalSum = 0;
            foreach (Order order in orders)
            {
                totalSum += order.Price;
            }
            Console.WriteLine("Общая сумма всех заказов = {0:#.##} руб. ", totalSum);
            Console.ReadLine();
        }

        public void MaxOrderSearch(List<Order> orders) // поиск клиента с максимальным заказом
        {
            double maxOrder = 0;
            int id = 0;
            foreach (Order order in orders)
            {
                if (order.Price > maxOrder)
                {
                    maxOrder = order.Price;
                    id = order.ClientId;
                }
            }
            Console.WriteLine("Клиент c Id {0} имеет максимальный заказ на сумму = {1:#.##} руб. ", id, maxOrder);
            Console.ReadLine();
        }
    }
}

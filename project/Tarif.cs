using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Tarif
    {
        string destination;
        double price;

        public Tarif() { }

        public Tarif(string destination, double price)
        {
            this.destination = destination;
            this.price = price;
        }

        public string Destination
        {
            get { return destination; }
            set
            {
               // if (value.Length > 3)
                    destination = value;
               // else throw new Exception("Неверный ввод направления перевозки");
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
                else throw new Exception("Стоимость должна быть больше 0");
            }
        }

        public override string ToString()
        {
            return String.Format(Destination + " " + Price);
        }

        // перегруженный бинарный  оператор для уменьшения стоимости перевозки.
        public static Tarif operator -(Tarif t, double Price)
        {
            Tarif tarif = t;
            tarif.Price -= Price;
            return tarif;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Order
    {
        const double fixedDiscount = 100;
        const double percentDiscount = 10;

        string clientName;
        int clientId;
        string destination;
        double price;
        double cargoWeight;

        public Order(){}

        public Order(int clientId, string clientName, string destination, double cargoWeight, double price)
        {
            this.ClientId = clientId;
            this.clientName = clientName;
            this.destination = destination;
            this.price = price;
            this.cargoWeight = cargoWeight;
        }

        public double CargoWeight
        {
            get { return cargoWeight; }
            set
            {
                if (value > 0)
                    cargoWeight = value;
                else throw new Exception("Груз должен быть больше 0");
            }
        }

        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }
        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public double getFixedDiscount()
        {
            return Price - fixedDiscount;
        }

        public double getProcDisount()
        {
            return Price * (100 - percentDiscount) / 100;
        }

        public override string ToString()
        {
            return String.Format(ClientId + " " + clientName + " " + Destination + " " + CargoWeight + " " + Price);
        }
    }
}

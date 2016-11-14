using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Client
    {
        string name;
        int id;

        public Client() { }

        public Client(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 3)
                    name = value;
                else throw new Exception("Имя должно содеражать более 3 символов");
            }
        }
        public int ID
        {
            get { return id; }
            set
            {
                if (value.ToString().Length >= 4)
                    id = value;
                else throw new Exception("Id должен содеражать более 3 символов");
            }
        }
        public override string ToString()
        {
            return string.Format(Name + " " + ID);
        }
    }
}

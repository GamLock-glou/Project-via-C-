using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_and_Polymorphism
{
    class Constructor_BD
    {
        private int id;
        private string name;
        private string description;
        private string money;

        public Constructor_BD(string name, int id) : this(name, "Not specified", "Not specified", id)
        {
        }

        public Constructor_BD(string name, string description, int id):this(name, description, "Not specified", id)
        {
        }


        public Constructor_BD(string name, string description, string money, int id)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.money = money;
        }


        public string[] GetInfo()
        {
            string[] mass_string = new string[4];
            mass_string[0] = id.ToString();
            mass_string[1] = name;
            mass_string[2] = description;
            mass_string[3] = money;
            return mass_string;
        }
    }

    class Person
    {
        public string n;
        public string Name 
        { get { return n; }
            set
            {
                if ("Bill" == value)
                {
                    n = "lol";
                }
                else
                    n = value;
            }
        }
        public Person(string name)
        {
            Name = name;
        }
        public virtual void Display()
        {
            Console.WriteLine(Name);
        }
    }
    class Employee : Person
    {
        public string Company { get; set; }
        public Employee(string name, string company)
            : base(name)
        {
            Company = company;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name} работает в {Company}");
        }
    }

    class Em:Employee
    {
        public string description { get; set; }
        public Em(string name, string company, string description)
            : base(name, company)
        {
            this.description = description;
        }
        public override void Display()
        {
            Console.WriteLine($"{Name} работает в {Company} с описанием: '{description}'");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            Console.WriteLine(i + 10);
            Polymorphism();

            //Constructor();

        }
        static void Polymorphism()
        {
            Person p1 = new Person("Bill");
            p1.Display(); // вызов метода Display из класса Person

            Employee p2 = new Employee("Tom", "Microsoft");
            p2.Display(); // вызов метода Display из класса Employee

            Em p3 = new Em("1", "22", "111");
            p3.Display(); // вызов метода Display из класса Employee
            Console.ReadKey();
        }

        static void Constructor()
        {
            List<string> bd_in_list = new List<string>();
            Console.WriteLine("\t\tDatabase");
            int long_DB = descriptor();
            for (int i = 0; i < long_DB; i++)
            {
                Console.WriteLine("If you do not want to enter a description and how much your product costs, then enter 1, " +
                    "if you do not want to enter how much your product costs, then enter 2, if you are going to enter full information " +
                    "about your product, enter 3");
                char creating_a_sale = Convert.ToChar(Console.ReadLine());
                if (creating_a_sale == '1')
                {
                    Constructor_BD bd = new Constructor_BD(Console.ReadLine(), id_in_BD(i));
                    string newStr = String.Join("\t\t", bd.GetInfo());
                    bd_in_list.Add(newStr);
                }
                else if (creating_a_sale == '2')
                {
                    Constructor_BD bd = new Constructor_BD(Console.ReadLine(), Console.ReadLine(), id_in_BD(i));
                    string newStr = String.Join("\t\t  ", bd.GetInfo());
                    bd_in_list.Add(newStr);
                }
                else if (creating_a_sale == '3')
                {
                    Constructor_BD bd = new Constructor_BD(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), id_in_BD(i));
                    string newStr = String.Join("\t\t   ", bd.GetInfo());
                    bd_in_list.Add(newStr);
                }
            }
            Console.WriteLine("Do you want to withdraw your sales?");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("ID\t\tName\t\tDescription\t\tMoney");
                foreach (string list in bd_in_list)
                    Console.WriteLine(list);
            }
            Console.ReadLine();
        }
        static int descriptor()
        {
            Console.WriteLine("How many items do you want to sell?");
            return Convert.ToInt32(Console.ReadLine());
        }

        static int id_in_BD(int id)
        {
            return id + 1;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patern_adapter
{
    abstract class Abstract 
    {
        protected string Say(string a, string b) => a + b;
        public abstract void Sender();
    }
    
    interface ISend
    {
        void Send();
    }

    class Adapter : Person, ISend
    {
        public void Send()
        {
            this.Sender();
        }
    }

    class Person : Abstract
    { 
        public override void Sender()
        {
            Console.WriteLine(base.Say("Your adapter ", "is adapted"));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Да-да, я konfuchi, мне можно так оформлять код");
            Console.WriteLine("___________________________________________");
            ISend send = new Adapter();
            send.Send();
            Console.ReadLine();
        }
    }
}

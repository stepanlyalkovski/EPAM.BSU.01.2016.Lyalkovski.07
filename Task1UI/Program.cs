using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task1;
namespace Task1UI
{   
    public class User
    {
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public void React(object sender, EventArgs e)
        {
            Console.WriteLine($"User '{Name}' has recieved message from {sender.GetType()}");
        }

        public void Subscribe(Clock clock)
        {
            clock.TimeIsOver += React;
        }

        public void UnSubscribe(Clock clock)
        {
            clock.TimeIsOver -= React;
        }
    }

    public class SystemService
    {
        private int id;
        public string Name { get; private set; }

        public SystemService(int id, string Name)
        {
            this.id = id;
            this.Name = Name;
        }

        public void SystemAction(object sender, EventArgs e)
        {
            Console.WriteLine($"Time for {Name}({id}) is over");
        }

        public void Subscribe(Clock clock)
        {
            clock.TimeIsOver += SystemAction;
        }

        public void UnSubscribe(Clock clock)
        {
            clock.TimeIsOver -= SystemAction;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();            
            User user1 = new User("Jim");
            User user2 = new User("Bob");
            User user3 = new User("Ivan");
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("=== Clock UI Test Mode (Unsubscribe for one user!!!)===");
                Console.WriteLine("1)Set time 2)Subscribe 3)Unsubscribe 4)Turn On");
                string key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter Countdown time");
                            clock.SetCountDown(int.Parse(Console.ReadLine()));
                        }
                        break;

                    case "2":
                        {
                           user1.Subscribe(clock);
                           user2.Subscribe(clock);
                           user3.Subscribe(clock);
                        }
                        break;
                    case "3":
                        user3.UnSubscribe(clock);
                        break;
                    case "4":
                        {
                            clock.TurnOn();
                        }
                        break;
                    default:
                        isWorking = false;
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }                     
        }

    }
}

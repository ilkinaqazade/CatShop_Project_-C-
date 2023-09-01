using System;

namespace IdleKitty
{
    public class KittyShop
    {
        public string Location { get; set; } = "Yeni Yasamal";
        public bool IsPetFriendly { get; set; } = true;
        public int Id { get; set; }
        public static int ShopId { get; set; } = 1;
        public Kitty[] Kitties { get; set; }
        public int KittyCount { get; set; } = 0;

        public KittyShop()
        {
            Id = ShopId++;
        }

        public void AddKitty(Kitty kitty)
        {
            Kitty[] temp = new Kitty[++KittyCount];
            if (Kitties != null)
            {
                Kitties.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = kitty;
            Kitties = temp;
        }

        public void Show()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"      ':.
         []_____
        /\      \
    ___/  \__/\__\__
---/\___\ |''''''|__\-- ---
   ||'''| |''||''|''|
   ``""""""`""`""""))""""`""""`");
            Console.ResetColor();
            Console.WriteLine($"ID : {Id}");
            Console.WriteLine($"Location : {Location}");
            Console.WriteLine($"Is pet friendly {(IsPetFriendly ? "Yes" : "No")}");
            Console.WriteLine($"Total Kitties : {KittyCount}");

        }

        public void ShowKitties()
        {
            if (Kitties != null)
            {
                foreach (var kitty in Kitties)
                {
                    kitty.Show();
                    Console.WriteLine();
                }
            }
        }
    }

    public class KittyOwner
    {
        public string Name { get; set; } = "Alice";
        public int Energy { get; set; } = 100;
        public decimal Happiness { get; set; } = 20;
        public decimal EnergyPercent { get; set; } = 10;
        public decimal HappinessPercent { get; set; } = 10;
    }

    public class Kitty
    {
        public string Name { get; set; } = "Xoxan";
        public int Age { get; set; } = 3;
        public decimal Weight { get; set; } = 4.5m;
        public KittyOwner Owner { get; set; } = new KittyOwner(); 

        public void Feed(decimal food)
        {
            Weight += food;
        }

        public void Play()
        {
            if (Owner != null)
            {
                if (Owner.Energy > 0)
                {
                    Owner.Energy -= 5;
                    Owner.Happiness += 5;

                    if (Owner != null)
                    {
                        if (Owner.Energy > 0)
                        {
                            Owner.Energy -= 5;
                            Weight -= 0.2m;
                        }
                        else
                        {
                            Owner.Energy = 0;
                        }
                    }
                }
                else
                {
                    Owner.Energy = 0;
                }
            }
        }

        public void Sleep()
        {
            Owner.Energy = 100;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine(@"    /\_/\           ___
   = o_o =_______    \ \  -Yasamal Cat-
    __^      __(  \.__) )
(@)<_____>__(_____)____/");
            Console.WriteLine();
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Owner's Energy: {Owner?.Energy}");
            Console.WriteLine($"Happiness: {Owner?.Happiness}");
            Console.ResetColor();
        }
    }

    class GameController
    {
        public static void StartGame()
        {
            KittyShop shop = new KittyShop();

            Kitty kitty = new Kitty
            {
                Name = "Whiskers",
                Age = 3,
                Weight = 4.5m,
                Owner = new KittyOwner()
            };

            shop.AddKitty(kitty);

            do
            {
                Console.Clear();
                shop.Show();
                shop.ShowKitties();
                Console.WriteLine("1. Feed Kitty");
                Console.WriteLine("2. Play with Kitty");
                Console.WriteLine("3. Put Kitty to Sleep");
                Console.WriteLine("4. Exit");
                Console.Write("Select an action: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter the amount of food to feed: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal foodAmount))
                            {
                                foreach (var k in shop.Kitties)
                                {
                                    k.Feed(foodAmount);
                                }
                            }
                            break;
                        case 2:
                            foreach (var k in shop.Kitties)
                            {
                                k.Play();
                            }
                            break;
                        case 3:
                            foreach (var k in shop.Kitties)
                            {
                                k.Sleep();
                            }
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }

                Thread.Sleep(1000);
            } while (kitty.Owner.Energy > 0);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            GameController.StartGame();
        }
    }
}

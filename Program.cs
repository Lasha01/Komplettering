using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komplettering
{
    class Program
    {
        
        static void Main(string[] args)

        {

            new Game();

        }
         
    }
    class Game
    {
        public Game()
        {
            chooseFighter();
            Battle();
        }
        Queue<Fighter> f1 = new Queue<Fighter>();
        Queue<Fighter> f2 = new Queue<Fighter>();
        void chooseFighter()
        {
            Console.WriteLine("Hur många fighters ska finnas i lag 1?");
            while (true)
            {
                Console.Write("Antal:");

                if (Int32.TryParse(Console.ReadLine().Trim(), out int result))
                {
                    if (result > 0)
                    {
                        for (int i = 0; i < result; i++)
                        {
                            f1.Enqueue(new Fighter());
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Skriv ett heltal över 0");
                    }

                }
                else
                {
                    Console.WriteLine("Skriv ett heltal");
                }

            }
            Console.WriteLine("Hur många fighters ska finnas i lag 2?");
            while (true)
            {
                Console.Write("Antal:");

                if (Int32.TryParse(Console.ReadLine().Trim(), out int result))
                {
                    if (result > 0)
                    {
                        for (int i = 0; i < result; i++)
                        {
                            f2.Enqueue(new Fighter());
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Skriv ett heltal över 0");
                    }

                }
                else
                {
                    Console.WriteLine("Skriv ett heltal");
                }

            }
        }
        private void Battle()

        {
            bool f1alive = true;
            bool f2alive = true;
            int f1count = f1.Count;
            int f2count = f2.Count;
            while (f1alive && f2alive)
            {


                Console.WriteLine("Team 1 alive:" + f1.Count + "/" + f1count);
                Console.WriteLine("Team 2 alive:" + f2.Count + "/" + f2count);

                f2.Peek().takeDmg(f1.Peek().coolAttack());
                f1.Peek().takeDmg(f2.Peek().coolAttack());

                Console.WriteLine("Team 1 HP:" + f1.Peek().hp);
                Console.WriteLine("Team 2 HP:" + f2.Peek().hp);

                if (!f1.Peek().isAlive())
                {
                    f1.Dequeue();
                }
                if (!f2.Peek().isAlive())
                {
                    f2.Dequeue();
                }

                if (f1.Count <= 0)
                {
                    f1alive = false;
                    Console.WriteLine("Team 1 förlora");
                }
                else if (f2.Count <= 0)
                {
                    f2alive = false;
                    Console.WriteLine("Team 2 förlora");
                }
                else if (f1.Count <= 0 && f2.Count <= 0)
                {
                    f1alive = false;
                    f2alive = false;
                    Console.WriteLine("Oavgjort");
                }
                
            }
            Console.ReadKey();
        }
    }

    class Fighter
    {
        public int hp = 10;
        int attack = 2;

        public void takeDmg(int attack)
        {
             hp =- attack;
        }
        public int coolAttack()
        {
            return attack;
        }

        public bool isAlive()
        {
            return hp > 0;
        }
    }
}

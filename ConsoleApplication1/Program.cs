using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car(20, 0, "Audi");

            c.AddMethodToDelegate(HanderMethod);

            for (int i = 0; i < 5; i++)
            {
                c.Accelerate(10);
            }
        }

        public static void HanderMethod(string msg)
        {
            Console.WriteLine($"->{msg}<-");
        }

    }

    class Car
    {
        public int MaxSpeed { get; set; }
        public int CurrentSpeed { get; set; }
        public string  PetName { get; set; }

        private bool carIsDead = false;

        public Car()
        {
            MaxSpeed = 100;
        }

        public Car(int ms, int cs, string petname)

        {
            MaxSpeed = ms;
            CurrentSpeed = cs;
            PetName = petname;
        }


        public delegate void SomeEventDelegate(string message);
        private SomeEventDelegate methodField;

        public void AddMethodToDelegate(SomeEventDelegate addingMethod)
        {
            methodField += addingMethod;
        }

        public void Accelerate (int delta)
        {
            if (carIsDead)
            {
                if(methodField != null)
                methodField($"Sorry {PetName} is dead.(");
            }
            else
            {
                CurrentSpeed += delta;
                if(CurrentSpeed>=MaxSpeed-10 && methodField != null)
                {
                    methodField($"Автомобиль почти сломан currentSpeed is {CurrentSpeed}");
                    if(CurrentSpeed >= MaxSpeed)
                    {
                        carIsDead = true;
                    }
                }
                else
                {
                    Console.WriteLine($"Пока что все нормально {CurrentSpeed}");
                }
            }
            
        }
    }
}

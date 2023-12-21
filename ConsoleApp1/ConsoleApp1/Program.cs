using System;
using System.Threading;
using Builder;
using Singleton;

namespace MainSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////////////////////////////
            /*
             * Builder Pattern
             */

            // The client code creates a builder object, passes it to the
            // director and then initiates the construction process. The end
            // result is retrieved from the builder object.
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic product:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Standard full featured product:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            // Remember, the Builder pattern can be used without a Director
            // class.
            Console.WriteLine("Custom product:");
            builder.BuildPartA();
            builder.BuildPartC();
            Console.Write(builder.GetProduct().ListParts());

            ////////////////////////////////////////////////////////////
            /*
             * Singleton Pattern
             */

            Console.WriteLine(
               "{0}\n{1}\n\n{2}\n",
               "If you see the same value, then singleton was reused (yay!)",
               "If you see different values, then 2 singletons were created (booo!!)",
               "RESULT:"
           );

            Thread process1 = new Thread(() =>
            {
                TestSingleton("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }

        public static void TestSingleton(string value)
        {
            ClassSingleton singleton = ClassSingleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }

    }

}

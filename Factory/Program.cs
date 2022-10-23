using Microsoft.Win32.SafeHandles;
using System;

namespace CSDesignPattern
{
    abstract class Creator
    {
        public abstract IProduct FactoryMethod();
        public string SomeOperation()
        {
            var product = FactoryMethod();
            var result = "Creator: The same creator code hasjust worked with"
                + product.Operation();
            return result;
        }
    }
    class ConcreteCreator1 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }
    class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }

    public interface IProduct
    {
        string Operation();
    }

    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Resulf of ConcreteProduct1}";
        }
    }
    class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Resulf of ConcreteProduct2}";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Lainched with  the ConcreteCreator1.");
            ClientCode(new ConcreteCreator1());
            Console.WriteLine();
            Console.WriteLine("App: Launched with the ConcretrCreator.2");
            ClientCode(new ConcreteCreator2());
        }
        public void ClientCode(Creator creator)
        {
            Console.WriteLine("Client: Im not aware of the creator calss."
                + "but it still works.\n" + creator.SomeOperation());

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
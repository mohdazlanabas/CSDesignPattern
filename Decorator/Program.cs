using System;

namespace CSDesignPattern
{
    public abstract class Component
    {
        public abstract string Operation();
    }
    class ConcreteComponent : Component
    { public override string Operation()
        {
            return "ConcreteComponent";
        }
    }
    abstract class Decorator : Component
        {  
        protected Component _component;
        public Decorator(Component component)
        {
            this._component = component;
        }
        public void SetCOmponent(Component component)
        {
            this._component = component;
        }
        public override string Operation()
        {
           if (this._component != null)
            {
                return this._component.Operation();
            } else
            {
                return string.Empty;
            }
        }
    }
    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component comp) : base(comp)
        {

        }
        public override string Operation()
        {
                return $"ConcreteDecoratorA{base.Operation()})";
        }
    }
        class ConcreteDecoratorB : Decorator
        {
            public ConcreteDecoratorB(Component comp) : base(comp)
            {

            }
            public override string Operation()
            {
                return $"ConcreteDecoratorB({base.Operation()})";
            }
        }
        public class Client
        {
            public void ClientCode(Component compoennt)
            {
                Console.WriteLine($"RESULT: " + compoennt.Operation());
            }
        }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
                Client client = new Client();
                var simple = new ConcreteComponent();
                Console.WriteLine("Client: I get a simple compoennt: ");
                client.ClientCode(simple);
                Console.WriteLine();

                ConcreteDecoratorA Decorator1 = new ConcreteDecoratorA(simple);
                ConcreteDecoratorB Decorator2 = new ConcreteDecoratorB(Decorator1);
                Console.WriteLine("Client: Now Ive got a decorated component:");
                client.ClientCode(Decorator2);
        }
    }
}
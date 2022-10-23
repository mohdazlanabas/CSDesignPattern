using System;

namespace CSDesignPattern
{
    public interface ITarget
    {
        string GetRequest();

    }
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }
    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;
        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }
        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }
    internal class Program
        { 
        static void Main(string[] args)
        {
        Console.WriteLine("Hello, World!");
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);
        Console.WriteLine("Adaptee interface is imcompatible withd the client.");
        Console.WriteLine("But with adapter client can call its merthod.");
        Console.WriteLine(target.GetRequest());
        }
    }
}
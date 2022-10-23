﻿using System;

namespace CSDesignPattern
{
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }
        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }
    public class IdInfo
    {
        public int IdNumber;
        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);

            Person p2 = p1.ShallowCopy();
            Person p3 = p1.DeepCopy();

            Console.WriteLine("Original values of p1, p2, p3: ");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1980-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7070;

            Console.WriteLine("\nValues of p1, p2, p3 after changes to p1:  ");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (chaged):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (same):");
            DisplayValues(p3);

        }
        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                 p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}
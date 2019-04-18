using System;
using System.Text;

namespace lr1
{
    public class Node
    {
        public int Coefficient { get; set; }
        public int Power { get; set; }
        public Node NextNode { get; set; }

        public Node()
        {
        }

        public Node(int coefficient, int power)
        {
            this.Coefficient = coefficient;
            this.Power = power;
        }
    }

    public class Polynomial
    {
        public Node Start { get; set; }
        public Node End { get; set; }

        public Polynomial()
        {
            this.End = new Node(0, int.MinValue);
            this.Start = new Node(0, int.MaxValue);
            this.Start.NextNode = this.End;
        }

        public Polynomial Read()
        {
            while (true)
            {
                Console.Write("a=");
                var a = Convert.ToInt32(Console.ReadLine());
                if (a == 0)
                {
                    break;
                }
                Console.Write("n=");
                var n = Convert.ToInt32(Console.ReadLine());

                var pt = this.Start;
                while (pt.NextNode != this.End && n < pt.NextNode.Power)
                {
                    pt = pt.NextNode;
                }

                if (pt.NextNode.Power == n)
                {
                    pt.NextNode.Coefficient += a;
                }
                else if (n > pt.NextNode.Power)
                {
                    var newNode = new Node(a, n);
                    newNode.NextNode = pt.NextNode;
                    pt.NextNode = newNode;
                }
            }
            return this;
        }

        public bool EqualsTo(Polynomial q)
        {
            return this.Meaning(2).Equals(q.Meaning(2));
        }

        public double Meaning(int x)
        {
            var pt = this.Start.NextNode;
            var result = 0.0;
            while (pt != this.End)
            {
                result += pt.Coefficient * Math.Pow(x, pt.Power);
                pt = pt.NextNode;
            }
            return result;
        }

        public string Print()
        {
            var pt = this.Start;
            var result = "";
            while (pt.NextNode != this.End)
            {
                result += $"{pt.NextNode.Coefficient}x^{pt.NextNode.Power} ";
                pt = pt.NextNode;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.WriteLine($"1. Equality\n2. Meaning\n3.Add\n0. Exit");
                var op = Console.ReadLine();

                var p = new Polynomial();
                var q = new Polynomial();

                switch (op) {
                    case "1":
                        Console.WriteLine("Enter P:");
                        p = new Polynomial().Read();
                        Console.WriteLine("Enter Q:");
                        q = new Polynomial().Read();
                        Console.WriteLine(p.Print());
                        Console.WriteLine(q.Print());
                        if (p.EqualsTo(q))
                            Console.WriteLine("Yes");
                        else
                            Console.WriteLine("No");
                        break;
                    case "2":
                        Console.WriteLine("Enter P:");
                        p = new Polynomial().Read();
                        Console.WriteLine(p.Print());
                        Console.WriteLine("Enter x = ");
                        var x = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Meaning of p = {p.Meaning(x)}");
                        break;
                    case "3":
                        break;
                }

                if (op == "0")
                {
                    break;
                }
            }
        }
    }
}

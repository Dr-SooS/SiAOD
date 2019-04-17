using System;

namespace lr2
{
    class Node
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Node NextNode { get; set; }

        public Node()
        {

        }

        public Node(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    class Dictionary
    {
        public Node Start { get; set; }
        public Node End { get; set; }

        public Dictionary()
        {
            this.End = new Node();
            this.Start = new Node();
            this.Start.NextNode = this.End;
        }

        public Dictionary Add(string key, string value)
        {
            var pt = this.Start;
            while (pt.NextNode != this.End && key.CompareTo(pt.NextNode.Key) > 0)
            {
                pt = pt.NextNode;
            }
            var newNode = new Node(key, value);
            newNode.NextNode = pt.NextNode;
            pt.NextNode = newNode;

            return this;
        }

        public string PrintDictionary()
        {
            var pt = this.Start.NextNode;
            var result = "";
            while (pt != this.End)
            {
                result += $"key = {pt.Key}, value = {pt.Value}\n";
                pt = pt.NextNode;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary();
            while(true)
            {
                Console.WriteLine("1. Add\n2. Show");
                var op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        var key = Console.ReadLine();
                        var value = Console.ReadLine();
                        dictionary.Add(key, value);
                        break;
                    case "2":
                        var dictStr = dictionary.PrintDictionary();
                        Console.WriteLine(dictStr);
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

using System;
using System.Collections.Generic;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }

    public class FA1
    {
        public static State a = new State()
        {
            Name = "a",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State b = new State()
        {
            Name = "b",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State c = new State()
        {
            Name = "c",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State d = new State()
        {
            Name = "d",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true
        };

        public static State e = new State()
        {
            Name = "e",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        State InitialState = a;

        public FA1()
        {
            a.Transitions.Add('0', c);
            a.Transitions.Add('1', b);
            b.Transitions.Add('0',d);
            b.Transitions.Add('1',b);
            c.Transitions.Add('0',e);
            c.Transitions.Add('1', d);
            d.Transitions.Add('0',e);
            d.Transitions.Add('1',d);
            e.Transitions.Add('0',e);
            e.Transitions.Add('1',e);
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        public static State a = new State()
        {
            Name = "a",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State b = new State()
        {
            Name = "b",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State c = new State()
        {
            Name = "c",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State d = new State()
        {
            Name = "d",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true
        };

        State InitialState = a;

        public FA2()
        {
            a.Transitions.Add('0',b);
            a.Transitions.Add('1',c);
            b.Transitions.Add('0', a);
            b.Transitions.Add('1', d);
            c.Transitions.Add('0', d);
            c.Transitions.Add('1', a);
            d.Transitions.Add('0', c);
            d.Transitions.Add('1', b);
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public static State a = new State()
        {
            Name = "a",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State b = new State()
        {
            Name = "b",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State c = new State()
        {
            Name = "c",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true
        };

        State InitialState = a;

        public FA3()
        {
            a.Transitions.Add('0', a);
            a.Transitions.Add('1', b);
            b.Transitions.Add('0', a);
            b.Transitions.Add('1', c);
            c.Transitions.Add('0', c);
            c.Transitions.Add('1', c);
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "010111";
            FA1 fa1 = new();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}

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
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA1()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = a;
            b.Transitions['0'] = c;
            b.Transitions['1'] = b;
            c.Transitions['0'] = c;
            c.Transitions['1'] = c;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }



    public class FA2
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State c = new State()
        {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State d = new State()
        {
            Name = "d",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        static State InitialState = a;

        public FA2()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = a;
            b.Transitions['0'] = a;
            b.Transitions['1'] = c;
            c.Transitions['0'] = d;
            c.Transitions['1'] = b;
            d.Transitions['0'] = c;
            d.Transitions['1'] = d;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            int onesCount = 0, zerosCount = 0;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
                if (c == '1') onesCount++;
                else zerosCount++;
            }
            return current.IsAcceptState && onesCount % 2 == 1 && zerosCount % 2 == 1;
        }
    }


    //FA3
    public class FA3
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State c = new State()
        {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State d = new State()
        {
            Name = "d",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        State InitialState = a;

        public FA3()
        {
            a.Transitions['0'] = a;
            a.Transitions['1'] = b;
            b.Transitions['0'] = c;
            b.Transitions['1'] = b;
            c.Transitions['0'] = d;
            c.Transitions['1'] = b;
            d.Transitions['0'] = d;
            d.Transitions['1'] = d;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            int count = 0;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
                if (current == b && count == 1)
                {
                    count++;
                    continue;
                }
                if (current == d)
                    count++;
            }
            return current.IsAcceptState && count > 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "0111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine($"FA1: {result1}");

            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine($"FA2: {result2}");

            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine($"FA3: {result3}");
        }
    }
}

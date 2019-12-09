using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace _10laba
{
 
    class Program
    {
        interface Inventory
        {
            string Cost(int cost); // стоимость

            string Lifetime(int life_time); // срок службы

        }
        class Description : Inventory       //описание объектов 
        {
            public Description(string Name, int Mass)
            {
                name = Name;
                mass = Mass;
            }
            public string Cost(int cost)
            {

                return $"Стоимость {name} = {cost}";
            }

            public virtual string Lifetime(int life_time)
            {
                return $"Срок службы {name} = {life_time} лет";
            }

            public string name { get; set; }

            public int mass { get; set; }


        }
        class Polz <T> where T : Description
        {
            public List<T> first = new List<T>();
            public Stack<T> second = new Stack<T>();
            public void AddToList(T elem)
            {
                first.Add(elem);
            }
            public void AddToStack(T elem)
            {
                second.Push(elem);
            }
            public void WriteList()
            {
                Console.WriteLine("Выводим первую коллекцию");
                foreach (Description o in first)
                    Console.WriteLine(o.name);
            }
            public void WriteStack()
            {
                Console.WriteLine("Выводим Вторую коллекцию");
                foreach (Description o in second)
                    Console.WriteLine(o.name);
                   
            }
            public void DeleteList(int a, int b)
            {
                first.RemoveRange(a, b);
            }
            public void poiskSteck(T elem)
            {
                if (second.Contains(elem) == true)
                    Console.WriteLine("Присутствует:" + elem.name);
                else
                    Console.WriteLine("Отсутствует: " + elem.name);
            }

        }
        class Student
        {
            
            public string name;
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

        }
    class Collect <T> where T: struct
        {
            public List<T> first = new List<T>();
            public Stack<T> second = new Stack<T>();
            public void AddToList(T elem)
            {
                first.Add(elem);
            }
            public void AddToStack(T elem)
            {
                second.Push(elem);
            }
            public void WriteList()
            {
                Console.WriteLine("Выводим первую коллекцию");
                foreach (object o in first)
                    Console.WriteLine(o);
            }
            public void WriteStack()
            {
                Console.WriteLine("Выводим Вторую коллекцию");
                foreach (object o in second)
                    Console.WriteLine(o);
            }
            public void DeleteList(int a, int b)
            {
                first.RemoveRange(a, b);
            }
            public void poiskSteck(T elem)
            {
                if (second.Contains(elem) == true)
                    Console.WriteLine("Присутствует:" + elem);
               else
                    Console.WriteLine("Отсутствует: " + elem);
            }

        }
        public static void Data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Коллекция изменена!");
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add :
                    Console.WriteLine("Добавлен новый объект");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Удален объект");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Student student = new Student();
            student.Name = "Ilya";

            ArrayList list = new ArrayList() { 1,2,3,4,5};
            list.Add("string");
            
            list.Add(student.name);
            list.RemoveAt(0);
            foreach(object o in list)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("Колличество элементов: " + list.Count);
            if (list.Contains("string") == true)
                Console.WriteLine("Присутствует Индекс: " + list.IndexOf("string"));
            ///////////////////////////////////////////////////////////////////////////

            Collect<float> collect = new Collect<float>();
            collect.AddToList(1.32f);
            collect.AddToList(2.23f);
            collect.AddToList(3.33f);
            collect.WriteList();
            for (int i = 0; i < collect.first.Count; i++)
            {
                collect.AddToStack(collect.first[i]);
            }
            collect.DeleteList(0, 1);
            collect.WriteList();
            collect.WriteStack();
            collect.poiskSteck(2.23f);
            /////////////////////////////////////////////////////////////////////////////
            Polz<Description> polz = new Polz<Description>();
            Description one = new Description("Ball",2);
            Description two = new Description("Crossovki", 1);


            polz.AddToList(one);
            polz.AddToList(two);
            polz.WriteList();
            for (int i = 0; i < polz.first.Count; i++)
            {
                polz.AddToStack(polz.first[i]);
            }
            polz.DeleteList(0, 1);
            polz.WriteList();
            polz.WriteStack();
            polz.poiskSteck(two);
            
            //////////////////////////////////////////////////////////////////////////////
            var data = new ObservableCollection<Description>();
            data.CollectionChanged += Data_CollectionChanged;
            data.Add(one);
            data.Add(two);
            data.Remove(one);
            Console.ReadLine();
        }
    }
}

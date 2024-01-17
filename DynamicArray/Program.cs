using System;
using System.Collections.Generic;

class DynamicArray<T>
{
    private List<T> items;
    private Random random;

    public DynamicArray()
    {
        items = new List<T>(10);
        random = new Random();
    }

    public void Add(T item)
    {
        items.Add(item);
    }


    public void AddRandom()
    {
        if (typeof(T) == typeof(int))
        {
            dynamic randomValue = random.Next(1, 101);

            if (items.Count < 10)
            {
                items.Add((T)randomValue);
            }
            else
            {
                throw new InvalidOperationException("Лист уже содержит 10 элементов.");
            }
        }
        else
        {
            throw new NotSupportedException($"Тип {typeof(T)} не поддерживается для генерации случайных значений.");
        }
    }

    public void RemoveRandom()
    {
        if (items.Count > 0)
        {
            int indexToRemove = random.Next(0, items.Count);
            items.RemoveAt(indexToRemove);
        }
    }

    public bool Contains(T item)
    {
        return items.Contains(item);
    }

    public int Count
    {
        get { return items.Count; }
    }

    public void Print()
    {
        foreach (var item in items)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        DynamicArray<int> dynamicArray = new DynamicArray<int>();

        dynamicArray.AddRandom();
        dynamicArray.AddRandom();
        dynamicArray.AddRandom();

        Console.WriteLine("Лист:");
        dynamicArray.Print();

        dynamicArray.RemoveRandom();

        Console.WriteLine("Лист после удаления элемента:");
        dynamicArray.Print();

        Console.WriteLine("Лист содержит элемент '3': " + dynamicArray.Contains(3));
        Console.WriteLine("Количество элементов в листе: " + dynamicArray.Count);
    }
}


using System;
using System.Collections;
using System.Collections.Generic;

interface IMovable
{
    double GeDistance(int speed);
}

abstract class Vehicle : IMovable
{
    public string Name { get; set; }
    public int Speed { get; set; }

    public Vehicle(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public abstract double GeDistance(int time); 
    public abstract void ShowInfo();            
}

class Car : Vehicle
{
    public Car(string name, int speed) : base(name, speed) { }

    public override double GeDistance(int time) => Speed * time;

    public override void ShowInfo()
    {
        Console.WriteLine($"Авто: {Name}, Швидкість: {Speed} км/год");
    }
}

class Plane : Vehicle
{
    public Plane(string name, int speed) : base(name, speed) { }

    public override double GeDistance(int time) => Speed * time;

    public override void ShowInfo()
    {
        Console.WriteLine($"Літак: {Name}, Швидкість: {Speed} км/год");
    }
}

class Train : Vehicle
{
    public Train(string name, int speed) : base(name, speed) { }

    public override double GeDistance(int time) => Speed * time;

    public override void ShowInfo()
    {
        Console.WriteLine($"Потяг: {Name}, Швидкість: {Speed} км/год");
    }
}

class Worker : IComparable<Worker>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }

    public Worker(string name, int age, double salary)
    {
        Name = name;
        Age = age;
        Salary = salary;
    }

    public int CompareTo(Worker other)
    {
        return this.Age.CompareTo(other.Age);
    }

    public override string ToString()
    {
        return $"Працівник: {Name}, Вік: {Age}, Зарплата: {Salary}";
    }
}

class WorkerComparer : IComparer<Worker>
{
    public int Compare(Worker x, Worker y)
    {
        return x.Salary.CompareTo(y.Salary); 
    }
}

class WorkerList : IEnumerable<Worker>
{
    private List<Worker> workers = new List<Worker>();

    public void Add(Worker worker)
    {
        workers.Add(worker);
    }

    public IEnumerator<Worker> GetEnumerator()
    {
        return workers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
      
        Console.WriteLine("Завдання 1: Транспортні засоби");
        Vehicle[] vehicles = new Vehicle[]
        {
            new Car("Toyota", 100),
            new Plane("Boeing 747", 900),
            new Train("Intercity", 200)
        };

        int time = 2;
        foreach (var v in vehicles)
        {
            v.ShowInfo();
            Console.WriteLine($"Подолана відстань за {time} год: {v.GeDistance(time)} км\n");
        }

        Console.WriteLine("\n-----------------------------\n");

        
        Console.WriteLine("Завдання 2: Список працівників");

        WorkerList workerList = new WorkerList();
        workerList.Add(new Worker("Іван", 25, 5000));
        workerList.Add(new Worker("Марія", 30, 7000));
        workerList.Add(new Worker("Петро", 22, 4500));
        workerList.Add(new Worker("Ольга", 35, 8000));

        
        List<Worker> workersByAge = new List<Worker>(workerList);
        workersByAge.Sort();
        Console.WriteLine("Сортування за віком:");
        foreach (var worker in workersByAge)
        {
            Console.WriteLine(worker);
        }

        Console.WriteLine("\n-----------------------------\n");

        
        List<Worker> workersBySalary = new List<Worker>(workerList);
        workersBySalary.Sort(new WorkerComparer());
        Console.WriteLine("Сортування за зарплатою:");
        foreach (var worker in workersBySalary)
        {
            Console.WriteLine(worker);
        }

        Console.WriteLine("\n-----------------------------\n");

        
        Console.WriteLine("Перегляд всіх працівників:");
        foreach (var worker in workerList)
        {
            Console.WriteLine(worker);
        }
    }
}

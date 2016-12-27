using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upravlenie_zadachami
{
    class Customer
    {
        public string ContactEmail { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhone { get; set; }

        public string Name { get; set; }
    }

    class Position
    {
        public int BaseHourlyRate { get; set; }

        public ulong Code { get; set; }

        public string Name { get; set; }

    }

    class Employee : Position
    {
        public string FullName { get; set; }

        public int Number { get; set; }

        public int Rating { get; set; }
    }

    class Project
    {
        internal Customer cust;

        public int Key { get; set; }

        public decimal InitialCost { get; set; }

        public string Title { get; set; }
    }

    class Task
    {
        internal Employee empl;

        public bool Billable { get; set; }

        public DateTime CloseDate { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int HourseSpent { get; set; }

        public int Number { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer[] custs = new Customer[2];
            custs[0] = new Customer()
            {
                ContactEmail = "customer1@gmail.com",
                ContactPerson = "Иванов И. И.",
                ContactPhone = "81111111111",
                Name = "Покупатель1"

            };
            custs[1] = new Customer()
            {
                ContactEmail = "customer2@gmail.com",
                ContactPerson = "Петров П. П.",
                ContactPhone = "82222222222",
                Name = "Покупатель2"
            };

            Employee[] empls = new Employee[7];
            empls[0] = new Employee() { FullName = "Сотрудник1", Number = 201, Rating = 2, BaseHourlyRate = 300, Code = 1111, Name = "1 лвл" };
            empls[1] = new Employee() { FullName = "Сотрудник2", Number = 302, Rating = 3, BaseHourlyRate = 1000, Code = 3333, Name = "3 лвл" };
            empls[2] = new Employee() { FullName = "Сотрудник3", Number = 403, Rating = 4, BaseHourlyRate = 1000, Code = 3333, Name = "3 лвл" };
            empls[3] = new Employee() { FullName = "Сотрудник4", Number = 104, Rating = 1, BaseHourlyRate = 1000, Code = 3333, Name = "3 лвл" };
            empls[4] = new Employee() { FullName = "Сотрудник5", Number = 205, Rating = 2, BaseHourlyRate = 300, Code = 1111, Name = "1 лвл" };
            empls[5] = new Employee() { FullName = "Сотрудник6", Number = 506, Rating = 5, BaseHourlyRate = 500, Code = 2222, Name = "2 лвл" };
            empls[6] = new Employee() { FullName = "Сотрудник7", Number = 507, Rating = 5, BaseHourlyRate = 500, Code = 2222, Name = "2 лвл" };

            Project p = new Project();
            Console.WriteLine("Ключ проекта:");
            p.Key = int.Parse(Console.ReadLine());
            Console.WriteLine("Бюджет проекта:");
            p.InitialCost = int.Parse(Console.ReadLine());
            Console.WriteLine("Название проекта:");
            p.Title = Console.ReadLine();
            Console.WriteLine("Выберите клиента:");
            int i = int.Parse(Console.ReadLine());
            p.cust = custs[i];

            Task t = new Task();
            Console.WriteLine("Введите номер задачи:");
            t.Number = int.Parse(Console.ReadLine());
            Console.WriteLine("Описание:");
            t.Description = (Console.ReadLine());
            Console.WriteLine("Срок исполнения:");
            t.DueDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Дата завершения работ:");
            t.CloseDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Затраченное время:");
            t.HourseSpent = int.Parse(Console.ReadLine());
            Console.WriteLine("Отдельно полачивается заказчиком?");
            t.Billable = bool.Parse(Console.ReadLine());
            Console.WriteLine("Выберите сотрудника:");
            int j = int.Parse(Console.ReadLine());
            p.cust = custs[j];
            t.empl = empls[j];
            if (t.Billable)
            {
                Console.WriteLine($"Стоимость{ empls[j].BaseHourlyRate * t.HourseSpent}");
            }
            else
            {
                Console.WriteLine($"Стоимость{ empls[j].BaseHourlyRate * t.HourseSpent * (1 + (empls.[j].Rating - 1) * 0.05) }");
            }
        }
    }
}

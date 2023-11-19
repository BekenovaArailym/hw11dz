using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLib;

namespace DZ11HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager manager = new EmployeeManager();

            Console.Write("Написать массив: ");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($" {i + 1} покажите инфу");
                Console.Write("имя: ");
                string fn = Console.ReadLine();
                Console.Write("фамилия: ");
                string ln = Console.ReadLine();
                Console.Write("Покажите дату когда его приняли на работу(хх.хх.хххх):");
                string d = Console.ReadLine();
                DateTime dob;
                while (!DateTime.TryParseExact(d, "хх.хх.хххх", null, DateTimeStyles.None, out dob)) ;
                Console.Write("Должность которую занимает: ");
                string p = Console.ReadLine();
                Console.Write("Гендер(жен/муж): ");
                char g = Convert.ToChar(Console.ReadLine());
                Console.Write("Покажите ЗП: ");
                int s = Convert.ToInt32(Console.ReadLine());
                manager.AddEmployee(new Employee { FName = fn, LName = ln, HireDate = dob, Position = p, Gender = g, Salary = s });
                Console.WriteLine();
            }

            // Выполнение задач
            Console.WriteLine("Показать данные всех работников;)");
            manager.AllEmployees();
            Console.WriteLine();
            Console.WriteLine("Все про должности");
            manager.EmployeesByPosition("Программист");
            Console.WriteLine();
            Console.WriteLine("найти в массиве всех менеджеров, чья зарплата превышает среднюю зарплату всех офисных работников, вывести подробную информацию о таких менеджерах по фамилии.");
            manager.ManagersAboveAvgClerkSalary();
            Console.WriteLine();
            Console.WriteLine("вывести информацию обо всех сотрудниках, принятых на работу после определенной даты (дата задается пользователем), отсортированную в алфавитном порядке по фамилии сотрудника.");
            manager.EmployeesHiredAfterDate(new DateTime(2023, 11, 19));
            Console.WriteLine();
            Console.WriteLine("Извлеките всю мужскую и женскую информацию в зависимости от того, что предоставляет пользователь. Рассмотрим случай, когда пользователь не выбирает конкретный пол, т.е. хочет информацию обо всем.");
            manager.EmployeesByGender('М');
        }
    }
}
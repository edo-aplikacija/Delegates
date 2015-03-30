using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID = 1, Name = "Mary", Salary = 5000, Experiance = 5 });
            empList.Add(new Employee() { ID = 2, Name = "John", Salary = 6000, Experiance = 6 });
            empList.Add(new Employee() { ID = 3, Name = "Mike", Salary = 4000, Experiance = 4 });
            empList.Add(new Employee() { ID = 4, Name = "Todd", Salary = 3000, Experiance = 3 });

            IsPromotable isPromotable = new IsPromotable(CheckPromoted);
            Employee.PromoteEmployes(empList, isPromotable);

            //Employee.PromoteEmployes(empList, emp => emp.Experiance >= 5);

        }

        public static bool CheckPromoted(Employee emp)
        {
            if (emp.Experiance >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public delegate bool IsPromotable(Employee emp);

    class Employee 
    {
        public int ID { get; set; }
        public string Name { get; set;}
        public int Salary { get; set; }
        public int Experiance { get; set; }

        public static void PromoteEmployes(List<Employee> empList, IsPromotable isPromotable)
        {
            foreach (Employee emp in empList)
            {
                if (isPromotable(emp))
                {
                    Console.WriteLine(emp.Name + " is promoted!!!");
                }
            }
        }
    }
}

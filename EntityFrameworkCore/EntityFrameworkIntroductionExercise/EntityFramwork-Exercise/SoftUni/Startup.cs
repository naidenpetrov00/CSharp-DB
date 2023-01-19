namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Linq;
    using System.Text;
    using System.Xml.XPath;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var db = new SoftUniContext();

            //var result = GetEmployeesFullInformation(db);
            //var result = GetEmployeesWithSalaryOver50000(db);
            var result = GetEmployeesFromResearchAndDevelopment(db);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext db)
        {
            var sb = new StringBuilder();

            var employees = db.Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    Name = String.Join("", e.FirstName, e.LastName, e.MiddleName),
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.Id)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Name} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext db)
        {
            var sb = new StringBuilder();

            var employees = db.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }


            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext db)
        {
            var sb = new StringBuilder();

            var employees = db.Employees
                .Where(e => e.Department.Name.Equals("Research and Development"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName}from Research and Development - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
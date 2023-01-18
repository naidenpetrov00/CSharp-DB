using SoftUni.Data;
using System.Text;
using System.Xml.XPath;

namespace SoftUni
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var db = new SoftUniContext();

            var result = GetEmployeesFullInformation(db);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext db)
        {
            var sb = new StringBuilder();

            var result = db.Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    Name = String.Join("", e.FirstName, e.LastName, e.MiddleName),
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.Id)
                .ToList();

            foreach (var employee in result)
            {
                sb.AppendLine($"{employee.Name} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
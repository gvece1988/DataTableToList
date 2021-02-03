using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableToList
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dt1 = new DataTable();
            dt1.Columns.AddRange(new[] { new DataColumn { ColumnName = "Id" },
            new DataColumn { ColumnName = "Name" },
            new DataColumn { ColumnName = "Experience" }});

            var dt2 = new DataTable();
            dt2.Columns.AddRange(new[] { new DataColumn { ColumnName = "Id" },
            new DataColumn { ColumnName = "Name" },
            new DataColumn { ColumnName = "Experience" }});

            dt1.Rows.Add(1, "Test1", 10);
            dt1.Rows.Add(2, "Test2", 5);

            dt2.Rows.Add(3, "Test3", 3);
            dt2.Rows.Add(4, "Test4", 4);

            var list = dt1.AsEnumerable().Concat(dt2.AsEnumerable()).Select(row => new Employee
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"].ToString(),
                Experience = Convert.ToInt32(row["Experience"]),
            }).ToList();

            var dict = dt1.AsEnumerable().Concat(dt2.AsEnumerable()).Select(row => new Employee
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"].ToString(),
                Experience = Convert.ToInt32(row["Experience"]),
            }).ToDictionary(emp => emp.Id);
        }
    }
}

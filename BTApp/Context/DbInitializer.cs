using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace BTApp.Models
{
    internal class DbInitializer
    {
        public static void Initialize(BusinessTripContext context)
        {
            int i = 0;
            if (context.EmployeeBase.Any())
            {
                return;
            }

            var employees = new EmployeeBase[]
            {
                new EmployeeBase {Name = "Carson Alexander", Code = CodeCounter(i).ToString()},
                new EmployeeBase {Name = "Meredith Alonso", Code = CodeCounter(i).ToString()},
                new EmployeeBase {Name = "Arturo Anand", Code = CodeCounter(i).ToString()},
                new EmployeeBase {Name = "Gytis Barzdukas", Code = CodeCounter(i).ToString()},
                new EmployeeBase {Name = "Yan Lil", Code = CodeCounter(i).ToString()},
                new EmployeeBase {Name = "Peggy Justice", Code = CodeCounter(i).ToString()},
                new EmployeeBase {Name = "Laura Norman", Code = CodeCounter(i).ToString()},
                new EmployeeBase {Name = "Nino Olivetto", Code = CodeCounter(i).ToString()}
            };
            foreach (EmployeeBase e in employees)
            {
                context.EmployeeBase.Add(e);
            }
            context.SaveChanges();

            var projects = new Project[]
            {
                new Project { Name = "Project 1", Manager = employees.Single(s => s.Name == "Carson Alexander")},
                new Project { Name = "Project 2", Manager = employees.Single(s => s.Name == "Meredith Alonso")},
                new Project { Name = "Project 3", Manager = employees.Single(s => s.Name == "Arturo Anand")},
                new Project { Name = "Project 4", Manager = employees.Single(s => s.Name == "Nino Olivetto")},
                new Project { Name = "Project 5", Manager = employees.Single(s => s.Name == "Carson Alexander")},

            };
            foreach (Project p in projects)
            {
                context.Project.Add(p);
            }
            context.SaveChanges();

            var subProjects = new Subproject[]
            {
                new Subproject { Name = "Subproject 1", Project=projects[1]},
                new Subproject { Name = "Subproject 2", Project=projects[1]},
                new Subproject { Name = "Subproject 3", Project=projects[1]},
                new Subproject { Name = "Subproject 4", Project=projects[2]},
                new Subproject { Name = "Subproject 5", Project=projects[3]},
                new Subproject { Name = "Subproject 6", Project=projects[3]}
            };
            foreach (Subproject p in subProjects)
            {
                context.Subproject.Add(p);
            }
            context.SaveChanges();

            int CodeCounter(int x)
            {
                int code = 100;
                code += x;
                i++;
                return code;
            }
        }
    }
}

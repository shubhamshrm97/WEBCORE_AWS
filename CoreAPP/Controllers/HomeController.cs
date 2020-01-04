using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreAPP.Models;

namespace CoreAPP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //GetMirrorNumberCounts(3, new string[] {"1","2","1" });
            Checkgeneric(3.5f);
            AngularWebAppContext angularWebAppContext = new AngularWebAppContext();
            IEnumerable<Department> DBDepartment = angularWebAppContext.Department.ToList().Where(p=>p.DepartmentName != null);
            IEnumerable<Department> LinqDept = from aa in angularWebAppContext.Department
                                               join bb in angularWebAppContext.Employee
                                               on aa.Id equals bb.DepartmentId
                                               select aa;
            IEnumerable<Employee> OuterLinqEmployee = from aa in angularWebAppContext.Department
                                               join bb in angularWebAppContext.Employee
                                               on aa.Id equals bb.DepartmentId
                                               into ps
                                               from p in ps.DefaultIfEmpty()
                                               select p;
           // int Sple = (int)Sample.C;

            return View(LinqDept);
        }

        public enum Sample
            {
            A = -8,
            B,
            C = 0
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void Checkgeneric<T>(T obj)
        {

        }

        private int GetMirrorNumberCounts(int Len, string[] NumArray)
        {
            string StrNumber = string.Empty;
            int NumberVal = 0;
            int MirrorNumberCount = 0;

            for (int i = 0; i < Len; i++)
            {
                StrNumber += NumArray[i].Trim();
            }

            if(!string.IsNullOrEmpty(StrNumber))
                NumberVal = Convert.ToInt32(StrNumber);

            for (int j = 1; j < NumberVal; j++)
            {
                string CurrentNumber = Convert.ToString(j);
                string ReverseNumber = string.Empty;
                for (int z= (CurrentNumber.Length-1); z>=0; z--)
                {
                    ReverseNumber += CurrentNumber[z];
                }

                if (!string.IsNullOrEmpty(CurrentNumber) && !string.IsNullOrEmpty(ReverseNumber) && (Convert.ToInt32(CurrentNumber.Trim()) + Convert.ToInt32(ReverseNumber.Trim())) == NumberVal)
                    MirrorNumberCount++;
            }

            return MirrorNumberCount;
        }
    }
}

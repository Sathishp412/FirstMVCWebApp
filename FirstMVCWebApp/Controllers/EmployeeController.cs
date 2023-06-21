using FirstMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        static List<EmpModel> EmployeesList = new List<EmpModel>() 
        {
        new EmpModel{Empid=1,EmpName="Sunita",Age=23 },
        new EmpModel{Empid=2,EmpName="Prajakta",Age=20 },
        new EmpModel { Empid=3,EmpName="Mayur",Age=20},
        new EmpModel{ Empid=4,EmpName="Pankaj",Age=22},
        new EmpModel{Empid=5,EmpName="Sima",Age=21 }
              
        };
        public IActionResult Index()
        {
            //list of Employees
            return View(EmployeesList);
        }

        //GET
        //[HttpGet]
        public IActionResult AddEmployee() {


            return View();
        }

        //POST---giving the data to the server
        [HttpPost]
        public IActionResult AddEmployee(EmpModel empmodel)
        {
            //Write Logic to Add employee to the list/db
            EmployeesList.Add(empmodel);


            //return content---string
            return RedirectToAction("Index");
        }




        public IActionResult EditEmployee(int id)
        {
            //Find the employee by id and show it
            EmpModel emp=EmployeesList.Find(e=>e.Empid==id);

            return View(emp);
        }

        [HttpPost]
        public IActionResult EditEmployee(EmpModel model) 
        {
            //Will save the changes
            EmpModel emp = EmployeesList.Find(e => e.Empid == model.Empid);
            emp.EmpName=model.EmpName;
            emp.Age=model.Age;
            return RedirectToAction("Index");
        }




        public IActionResult DeleteEmployee(int id)
        {
            EmpModel emp=EmployeesList.Find(e => e.Empid == id);
            return View(emp); 
        
        }

        [HttpPost]
        public IActionResult DeleteEmployee(int id,EmpModel emp) 
        {
            EmpModel EmpToDelete = EmployeesList.Find(e => e.Empid == id);
            EmployeesList.Remove(EmpToDelete); 
            return RedirectToAction("Index");


        }

        public IActionResult Details(int id)
        {
            EmpModel EmpDetails = EmployeesList.Find(e => e.Empid == id);
            return View(EmpDetails);

        }


    }
}

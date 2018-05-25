using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;

namespace MVCAlplicacionAndres.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<Employee> GetAllEmployee()
        {
            using (DBModel db = new DBModel())
            {
                return db.Employees.ToList<Employee>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Employee emp = new Employee();
            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    emp = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>();
                }
            }
            return View(emp);
        }

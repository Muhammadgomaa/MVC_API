using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC1.Models;

namespace MVC1.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult CheckDep(string Dep_Name , int? Dep_ID)
        {
            //Create Case

            if(Dep_ID == null)
            {
                HttpResponseMessage message = MainAPI.WebAPIcLinet.GetAsync("api/department").Result;

                if (message.IsSuccessStatusCode)
                {
                    List<Department> departments = message.Content.ReadAsAsync<List<Department>>().Result;
                    Department department = departments.Where(n => n.Dep_Name.Trim().ToUpper() == Dep_Name.Trim().ToUpper()).SingleOrDefault();

                    //Create Case
                    if (department == null)
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                HttpResponseMessage message = MainAPI.WebAPIcLinet.GetAsync("api/department").Result;

                if (message.IsSuccessStatusCode)
                {
                    List<Department> departments = message.Content.ReadAsAsync<List<Department>>().Result;
                    Department department = departments.Where(n => n.Dep_Name == Dep_Name && n.Dep_ID != Dep_ID).SingleOrDefault();

                    //Create Case
                    if (department == null)
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Departments()
        {
            HttpResponseMessage message = MainAPI.WebAPIcLinet.GetAsync("api/department").Result;

            if (message.IsSuccessStatusCode)
            {
                List<Department> departments = message.Content.ReadAsAsync<List<Department>>().Result;
                return View(departments);
            }
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Department department)
        {

            HttpResponseMessage message = MainAPI.WebAPIcLinet.PostAsJsonAsync("api/department", department).Result;

            if (message.IsSuccessStatusCode)
            {

                return RedirectToAction("Departments");

            }
            return RedirectToAction("Departments");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage message = MainAPI.WebAPIcLinet.DeleteAsync($"api/department/{id}").Result;

            if (message.IsSuccessStatusCode)
            {

                return RedirectToAction("Departments");

            }

            return RedirectToAction("Departments");
        }

        public ActionResult Details (int id)
        {
            HttpResponseMessage message = MainAPI.WebAPIcLinet.GetAsync("api/department").Result;

            if (message.IsSuccessStatusCode)
            {
                List<Department> departments = message.Content.ReadAsAsync<List<Department>>().Result;
                Department department = departments.Where(n => n.Dep_ID == id).SingleOrDefault();
                return View(department);
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            HttpResponseMessage message = MainAPI.WebAPIcLinet.GetAsync("api/department").Result;

            if (message.IsSuccessStatusCode)
            {
                List<Department> departments = message.Content.ReadAsAsync<List<Department>>().Result;
                Department department = departments.Where(n => n.Dep_ID == id).SingleOrDefault();
                return View(department);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            HttpResponseMessage message = MainAPI.WebAPIcLinet.PutAsJsonAsync($"api/department/{department.Dep_ID}", department).Result;

            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("Departments");
            }
            return RedirectToAction("Departments");
        }
    }
}
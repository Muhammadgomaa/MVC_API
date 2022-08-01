using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC1.Models;


namespace MVC1.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult CheckStud(string Stud_Name, int? Stud_ID)
        {
            //Create Case

            if (Stud_ID == null)
            {
                HttpResponseMessage message = MainAPI.WebAPIcLinet.GetAsync("api/student").Result;

                if (message.IsSuccessStatusCode)
                {
                    List<Student> students = message.Content.ReadAsAsync<List<Student>>().Result;
                    Student student = students.Where(n => n.Stud_Name.Trim().ToUpper() == Stud_Name.Trim().ToUpper()).SingleOrDefault();

                    //Create Case
                    if (student == null)
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
                HttpResponseMessage message = MainAPI.WebAPIcLinet.GetAsync("api/student").Result;

                if (message.IsSuccessStatusCode)
                {
                    List<Student> students = message.Content.ReadAsAsync<List<Student>>().Result;
                    Student student = students.Where(n => n.Stud_Name.Trim().ToUpper() == Stud_Name.Trim().ToUpper() && n.Stud_ID != Stud_ID).SingleOrDefault();

                    //Create Case
                    if (student == null)
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

        public ActionResult Students()
        {
            HttpResponseMessage message = MainAPI.WebAPIcLinet.GetAsync("api/student").Result;

            if (message.IsSuccessStatusCode)
            {
                List<Student> students = message.Content.ReadAsAsync<List<Student>>().Result;
                return View(students);
            }
            return View();
        }

        public ActionResult Insert()
        {
            HttpResponseMessage message = MainAPI.WebAPIcLinet.GetAsync("api/department").Result;

            if (message.IsSuccessStatusCode)
            {
                List<Department> departments = message.Content.ReadAsAsync<List<Department>>().Result;
                ViewBag.Dep = new SelectList(departments, "Dep_ID", "Dep_Name");
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Student student)
        {

            HttpResponseMessage message = MainAPI.WebAPIcLinet.PostAsJsonAsync("api/student", student).Result;

            if (message.IsSuccessStatusCode)
            {

                return RedirectToAction("Students");

            }
            return RedirectToAction("Students");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage message = MainAPI.WebAPIcLinet.DeleteAsync($"api/student/{id}").Result;

            if (message.IsSuccessStatusCode)
            {

                return RedirectToAction("Students");

            }

            return RedirectToAction("Students");
        }

        public ActionResult Details(int id)
        {
            HttpResponseMessage message = MainAPI.WebAPIcLinet.GetAsync("api/student").Result;

            if (message.IsSuccessStatusCode)
            {
                List<Student> students  = message.Content.ReadAsAsync<List<Student>>().Result;
                Student student = students.Where(n => n.Stud_ID == id).SingleOrDefault();
                return View(student);
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            HttpResponseMessage message = MainAPI.WebAPIcLinet.GetAsync("api/student").Result;

            if (message.IsSuccessStatusCode)
            {
                List<Student> students = message.Content.ReadAsAsync<List<Student>>().Result;
                Student student = students.Where(n => n.Stud_ID == id).SingleOrDefault();

                HttpResponseMessage message1 = MainAPI.WebAPIcLinet.GetAsync("api/department").Result;

                if (message1.IsSuccessStatusCode)
                {
                    List<Department> departments = message1.Content.ReadAsAsync<List<Department>>().Result;
                    Department department = departments.Where(n => n.Dep_ID == id).SingleOrDefault();
                    ViewBag.Dep = new SelectList(departments, "Dep_ID", "Dep_Name");
                    return View(student);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            HttpResponseMessage message = MainAPI.WebAPIcLinet.PutAsJsonAsync($"api/student/{student.Stud_ID}", student).Result;

            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("Students");
            }
            return RedirectToAction("Students");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolLoginSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolLoginSystem.Controllers
{
    public class TeacherController : Controller
    {
        ContextForStudent c = new ContextForStudent();
        [Authorize]
        public IActionResult Index()
        {
            var degerler = c.studentModels.ToList();
            return View(degerler);
        }
        [Authorize]
        public IActionResult OgrenciSayfasi()
        {
            return View();
        }
        private readonly ContextForStudent _context;
        public string getString(string KEY)
        {
            return HttpContext.Session.GetString(KEY);
        }
        public TeacherController(ContextForStudent context)
        {
            _context = context;
        }
        public IActionResult Indext()
        {
            string logSituation = getString("Login");

            if (logSituation == "true")
            {
                ViewBag.Session = getString("Status");
                var list = _context.studentModels.ToList();
                return View(list);
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }

        }
        public IActionResult OgrenciEkle() { return View(); }
        public IActionResult Student(string username)
        {
            ModelForStudent table;
            if (username == null)
            {
                table = new ModelForStudent();
            }
            else
            {
                table = _context.studentModels.Find(username);
            }
            return View(table);
        }
        public async Task<IActionResult> Create(ModelForStudent table)
        {
            if (table.Name != null)
            {
                await _context.AddAsync(table);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            using (var table = new ContextForStudent())
            {
                var userList = table.studentModels
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                table.studentModels.Remove(userList);
                table.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult OgrenciGetir(int id)
        {
            var depart = c.studentModels.Find(id);
            return View("OgrenciGetir", depart);
        }


        public IActionResult Update(int id)
        {
            var std = c.studentModels.Where(x => x.Id == id).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(ModelForStudent l)
        {
            var updtStudent = c.studentModels.SingleOrDefault(x => x.Id == l.Id);
            updtStudent.Update(l.Name, l.Username, l.Password, l.Id, l.Math_point, l.Physics_point, l.Chemistry_point, l.Email);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
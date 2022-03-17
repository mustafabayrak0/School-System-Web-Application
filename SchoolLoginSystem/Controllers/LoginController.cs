using Microsoft.AspNetCore.Mvc;
using SchoolLoginSystem.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Http;
namespace SchoolLoginSystem.Controllers
{
    public class LoginController : Controller
    {
        ContextForStudent c = new ContextForStudent();
        [HttpGet]
        public IActionResult OgrenciGirisi() { return View(); }
        public async Task<IActionResult> OgrenciGirisi(ModelForStudent p)
        {
            var bilgiler = c.studentModels.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (bilgiler != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, p.Username) };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return View("~/Views/Teacher/OgrenciSayfasi.cshtml",bilgiler);//burayı düzenleyeceğim
            }
            return View();
        }
        [HttpGet]
        public IActionResult OgretmenGirisi() { return View(); }
        public async Task<IActionResult> OgretmenGirisi(ModelForTeacher k)
        {
            var bilgiler = c.teacherModels.FirstOrDefault(x => x.TeacherName == k.TeacherName && x.TeacherPassword == k.TeacherPassword);
            if (bilgiler != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, k.TeacherName) };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Teacher");
                await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return View();
        }
    }
}
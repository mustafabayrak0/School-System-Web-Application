//using Microsoft.AspNetCore.Mvc;
//using SchoolLoginSystem.Models;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;

//namespace SchoolLoginSystem.Controllers
//{
//    public class StudentController : Controller
//    {
//        private readonly ContextForStudent _context;
//        public string getString(string KEY)
//        {
//            return HttpContext.Session.GetString(KEY);
//        }
//        public StudentController(ContextForStudent context)
//        {
//            _context = context;
//        }
//        public IActionResult Index()
//        {
//            string logSituation = getString("Login");

//            if (logSituation == "true")
//            {
//                ViewBag.Session = getString("Status");
//                var list = _context.studentModels.ToList();
//                return View(list);
//            }
//            else
//            {
//                return View("~/Views/Shared/Error.cshtml");
//            }

//        }
//        public IActionResult YeniOgrenci() { return View(); }
//        public IActionResult GuncelleOgrenci() { return View(); }
//        public IActionResult Student(string username)
//        {
//            ModelForStudent table;
//            if (username == null)
//            {
//                table = new ModelForStudent();
//            }
//            else
//            {
//                table = _context.studentModels.Find(username);
//            }
//            return View(table);
//        }
//        public async Task<IActionResult> Create(ModelForStudent table)
//        {
//            if (table.Name != null)
//            {
//                await _context.AddAsync(table);
//            }
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        public IActionResult Delete(string username)
//        {
//            using (var table = new ContextForStudent())
//            {
//                var userList = table.studentModels
//                    .Where(x => x.Username == username)
//                    .FirstOrDefault();
//                table.studentModels.Remove(userList);
//                table.SaveChanges();
//            }
//            return RedirectToAction(nameof(Index));
//        }

//        public IActionResult Update(ModelForStudent table)
//        {
//            using (var newTable = new ContextForStudent())
//            {
//                var userList = newTable.studentModels
//                    .Where(x => x.Username == table.Username)
//                    .FirstOrDefault();

//                userList.Password = table.Password;
//                userList.Name = table.Name;
//                newTable.SaveChanges();
//            }
//            return RedirectToAction(nameof(Index));

//        }
//    }
//}

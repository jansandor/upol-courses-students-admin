using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cv8_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace cv8_mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Students = _context.Students.OrderBy(s => s.LastName).ToList();
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var student = _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);
            if (await student == null)
            {
                return NotFound();
            }
            var studentCourses = _context.StudentCourses.Where(sc => sc.StudentId == id)
                                                        .Include(sc => sc.Course)
                                                        .Include(sc => sc.CourseStatute)
                                                        .Include(sc => sc.StudentGrade)
                                                        .ToListAsync();
            ViewBag.StudentCourses = await studentCourses;
            return View(await student); // predani do view takto, misto ViewBag, pristup pres @model v sablone
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PersonalNumber,FirstName,LastName,UserName,StudyProgramName,Faculty,StudyProgramCode,StudyForm,YearOfStudy,Specialization,Email,CardNumber,Gender")] Student student)
        {
            if(ModelState.IsValid){
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), nameof(Student));
            }
            return View(student);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                ViewBag.Msg = "Changes saved.";
            }
            return View(student);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int StudentId)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == StudentId);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), nameof(Student));
        }
    }
}

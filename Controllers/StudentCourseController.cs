using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cv8_mvc;
using cv8_mvc.Models;
using cv8_mvc.ViewModels;


namespace cv8_mvc.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly AppDbContext _context;
        public StudentCourseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StudentCourse
        public IActionResult Index()
        {
            ViewBag.Enrollments = _context.StudentCourses.Include(sc => sc.Course)
                                                     .Include(sc => sc.CourseStatute)
                                                     .Include(sc => sc.Student)
                                                     .Include(sc => sc.StudentGrade)
                                                     .AsEnumerable()
                                                     .GroupBy(sc => sc.CourseId)
                                                     .ToList();
            return View();
        }

        // GET: StudentCourse/Create
        public IActionResult Create(int? id) // studentId
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            var courses = _context.Courses.ToList();
            var statutes = _context.CourseStatutes.ToList();

            // zjisteni, jestli ma student zapsane nejake kurzy
            // a jejich vyrazeni ze seznamu kurzu k zapsani

            ////// mozna by slo resit sikovnym LINQ dotazem pri ziskavani studenta
            var studentCourses = _context.StudentCourses.Where(sc => sc.StudentId == id).ToList();
            if (studentCourses.Count != 0)
            {
                foreach (var enrollment in studentCourses)
                {
                    courses.Remove(enrollment.Course);
                }
            }
            // chci, aby bylo pridani predmetu jen pro konkretniho studenta
            // ale ViewModel mam ready i na list, proto predam konstruktoru list s jedinym studentem
            // tak znemoznim vybrat jineho, nez ze ktereho jsem se k zapisu dostal (pres details)

            List<Student> studentAsList = new List<Student>();
            studentAsList.Add(student);
            var viewModel = new StudentCourseEnrollmentVM(studentAsList, courses, statutes);
            ViewBag.Student = student;
            return View(viewModel);
        }

        // POST: StudentCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCourseEnrollmentVM enrollmentData)
        {
            Student student;
            if (ModelState.IsValid)
            {
                var course = _context.Courses.FirstOrDefaultAsync(c => c.CourseId == enrollmentData.CourseId);
                var courseStatute = _context.CourseStatutes.FirstOrDefaultAsync(cs => cs.CourseStatuteId == enrollmentData.CourseStatuteId);
                var grade = _context.Grades.FirstOrDefault(g => g.Value == Grade.NoGradeYetValue);
                student = _context.Students.FirstOrDefault(s => s.StudentId == enrollmentData.StudentId);

                StudentCourse enrollment = new StudentCourse();
                enrollment.StudentId = enrollmentData.StudentId;
                enrollment.CourseId = enrollmentData.CourseId;
                enrollment.CourseStatuteId = enrollmentData.CourseStatuteId;
                // nastavi se Grade "-" jako defaultni, kdyz jeste student nedostal znamku pri zapisu do kurzu
                enrollment.GradeId = grade.GradeId;
                enrollment.StudentGrade = grade;

                enrollment.Student = student;
                enrollment.Course = await course;
                enrollment.CourseStatute = await courseStatute;

                _context.StudentCourses.Add(enrollment);
                await _context.SaveChangesAsync();

                // redirect na Student/Details/id
                return RedirectToAction(nameof(StudentController.Details), nameof(Student), new { id = student.StudentId });
            }
            // vraceni se na create formular, kde jsou prednastavene hodnoty pred pokusem o POST
            // nastavene hodnoty pred odeslanim formulare se nastavi sami
            // ale je potreba znovu naplnit seznamy SelectList ViewModelu daty z DB podobne jako v Create GET

            //////
            var statutes = _context.CourseStatutes.ToListAsync();
            var courses = _context.Courses.ToList();
            student = _context.Students.FirstOrDefault(s => s.StudentId == enrollmentData.StudentId);

            var studentCourses = _context.StudentCourses.Where(sc => sc.StudentId == enrollmentData.StudentId).ToList();
            if (studentCourses.Count != 0)
            {
                foreach (var enrollment in studentCourses)
                {
                    courses.Remove(enrollment.Course);
                }
            }
            List<Student> studentAsList = new List<Student>();
            studentAsList.Add(student);
            var viewModel = new StudentCourseEnrollmentVM(studentAsList, courses, await statutes);
            ViewBag.Student = student;
            //////

            enrollmentData.Students = viewModel.Students;
            enrollmentData.Courses = viewModel.Courses;
            enrollmentData.CourseStatutes = viewModel.CourseStatutes;

            return View(enrollmentData);
        }

        public async Task<IActionResult> EditCourseGrades(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var enrollment = await _context.StudentCourses.Where(sc => sc.CourseId == id)
                                                          .Include(sc => sc.Course)
                                                          .Include(sc => sc.Student)
                                                          .Include(sc => sc.CourseStatute)
                                                          .Include(sc => sc.StudentGrade)
                                                          .ToListAsync();
            if (enrollment == null)
            {
                return NotFound();
            }
            var grades = _context.Grades.OrderBy(g => g.Value).ToList();
            var gradeSelectListVM = new GradeSelectListVM(grades, "Grade List");

            List<EditCourseGradesVM> enrollmentViewModels = new List<EditCourseGradesVM>();
            foreach (var e in enrollment)
            {
                enrollmentViewModels.Add(new EditCourseGradesVM(e));
            }
            foreach (var item in enrollmentViewModels)
            {
                item.Grades = gradeSelectListVM.Grades;
            }
            ViewBag.Course = enrollment.FirstOrDefault().Course;
            return View(enrollmentViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCourseGrades(int? StudentId, int? CourseId, int? GradeId)
        {
            if (StudentId == null || CourseId == null || GradeId == null)
            {
                return NotFound();
            }
            var enrollment = _context.StudentCourses.Where(sc => sc.CourseId == CourseId && sc.StudentId == StudentId)
                                                    .Include(sc => sc.StudentGrade)
                                                    .FirstOrDefault();
            if (enrollment == null)
            {
                return NotFound();
            }
            var newGrade = _context.Grades.FirstOrDefault(g => g.GradeId == GradeId);
            if (newGrade == null)
            {
                return NotFound();
            }
            enrollment.GradeId = newGrade.GradeId;
            enrollment.StudentGrade = newGrade;
            _context.StudentCourses.Update(enrollment);
            _context.SaveChanges();

            return RedirectToAction(nameof(EditCourseGrades), nameof(StudentCourse), new { id = CourseId });
        }

        public IActionResult RemoveEnrollment(int? sid, int? cid)
        {
            if (sid == null || cid == null)
            {
                return NotFound();
            }
            var enrollment = _context.StudentCourses.Where(sc => sc.StudentId == sid && sc.CourseId == cid)
                                                    .Include(sc => sc.Course)
                                                    .FirstOrDefault();
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        public IActionResult RemoveEnrollmentConfirmed(int sid, int cid)
        {
            var enrollment = _context.StudentCourses.FirstOrDefault(sc => sc.StudentId == sid && sc.CourseId == cid);
            _context.StudentCourses.Remove(enrollment);
            _context.SaveChanges();
            return RedirectToAction(nameof(StudentController.Details), nameof(Student), new { id = sid });
        }

        // GET: StudentCourse/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var studentCourse = await _context.StudentCourses
        //         .Include(s => s.Course)
        //         .Include(s => s.CourseStatute)
        //         .Include(s => s.Student)
        //         .Include(s => s.StudentGrade)
        //         .FirstOrDefaultAsync(m => m.StudentId == id);
        //     if (studentCourse == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(studentCourse);
        // }

        // GET: StudentCourse/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var studentCourse = await _context.StudentCourses.FindAsync(id);
        //     if (studentCourse == null)
        //     {
        //         return NotFound();
        //     }
        //     ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", studentCourse.CourseId);
        //     ViewData["CourseStatuteId"] = new SelectList(_context.CourseStatutes, "CourseStatuteId", "CourseStatuteId", studentCourse.CourseStatuteId);
        //     ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentCourse.StudentId);
        //     ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", studentCourse.GradeId);
        //     return View(studentCourse);
        // }

        // POST: StudentCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("StudentId,CourseId,GradeId,CourseStatuteId")] StudentCourse studentCourse)
        // {
        //     if (id != studentCourse.StudentId)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(studentCourse);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!StudentCourseExists(studentCourse.StudentId))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", studentCourse.CourseId);
        //     ViewData["CourseStatuteId"] = new SelectList(_context.CourseStatutes, "CourseStatuteId", "CourseStatuteId", studentCourse.CourseStatuteId);
        //     ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentCourse.StudentId);
        //     ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", studentCourse.GradeId);
        //     return View(studentCourse);
        // }

        // GET: StudentCourse/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var studentCourse = await _context.StudentCourses
        //         .Include(s => s.Course)
        //         .Include(s => s.CourseStatute)
        //         .Include(s => s.Student)
        //         .Include(s => s.StudentGrade)
        //         .FirstOrDefaultAsync(m => m.StudentId == id);
        //     if (studentCourse == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(studentCourse);
        // }

        // // POST: StudentCourse/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var studentCourse = await _context.StudentCourses.FindAsync(id);
        //     _context.StudentCourses.Remove(studentCourse);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool StudentCourseExists(int id)
        // {
        //     return _context.StudentCourses.Any(e => e.StudentId == id);
        // }
    }
}

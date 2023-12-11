using Microsoft.AspNetCore.Mvc;
using Online_Exam1._0.Data;
//using Online_Exam.Models;
using Online_Exam1._0.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
public class ExamController : Controller
{
    private readonly AppDbContext _context;

    public ExamController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        Exam exam = new Exam();
        return View(exam);
    }

    [HttpPost]
    public IActionResult Create(Exam exam)
    {
        string adminEmail = HttpContext.Session.GetString("U_Email");
        exam.Adminstration_Email = adminEmail;
        _context.Exams.Add(exam);
        _context.SaveChanges();
        HttpContext.Session.SetInt32("Exam_id", exam.Exam_id);
        // Pass Exam_id as a route parameter when redirecting to QuestionsController
        return RedirectToAction("Create", "Questions");
    }

    public IActionResult Index()
    {
        string adminEmail = HttpContext.Session.GetString("U_Email");
        var exams = _context.Exams
            .Where(e => e.Adminstration_Email == adminEmail)
            .ToList();

        return View(exams);
    }
}
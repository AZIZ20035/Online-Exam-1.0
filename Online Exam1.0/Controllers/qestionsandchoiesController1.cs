using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Exam1._0.Data;
using Online_Exam1._0.Models;
using System.Linq;

public class QuestionsController : Controller
{
    private readonly AppDbContext _context;

    public QuestionsController(AppDbContext context)
    {
        _context = context;
    }

    // Index action to display all questions
    public IActionResult Index()
    {
        // Assuming you have Exam_id stored in session
        int examId = HttpContext.Session.GetInt32("Exam_id") ?? 0;

        var questions = _context.Questions
            .Where(q => q.Exam_id == examId)
            .ToList();

        return View(questions);
    }

    // Create action to add a new question
    public IActionResult Create()
    {
        // Assuming you have Exam_id stored in session
        int examId = HttpContext.Session.GetInt32("Exam_id") ?? 0;

        var newQuestion = new Questions
        {
            Exam_id = examId
        };

        return View(newQuestion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Questions question)
    {
        if (ModelState.IsValid)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(question);
    }

    // Add other CRUD actions (Edit, Details, Delete) here

    // Add Choices action to display and add choices for a specific question
    public IActionResult Choices(int questionId)
    {
        // Assuming you have Exam_id stored in session
        int examId = HttpContext.Session.GetInt32("Exam_id") ?? 0;

        var question = _context.Questions
            .Include(q => q.Choices)
            .FirstOrDefault(q => q.Exam_id == examId && q.Question_id == questionId);

        if (question == null)
        {
            return NotFound();
        }

        return View(question);
    }

    // Create Choices action to add a new choice for a specific question
    public IActionResult CreateChoice(int questionId)
    {
        // Assuming you have Exam_id stored in session
        int examId = HttpContext.Session.GetInt32("Exam_id") ?? 0;

        var newChoice = new Choices
        {
            Exam_id = examId,
            Question_id = questionId
        };

        return View(newChoice);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateChoice(Choices choice)
    {
        if (ModelState.IsValid)
        {
            _context.Choices.Add(choice);
            _context.SaveChanges();
            return RedirectToAction(nameof(Choices), new { questionId = choice.Question_id });
        }
        return View(choice);
    }
}

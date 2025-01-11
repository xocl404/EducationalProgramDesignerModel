using Itmo.ObjectOrientedProgramming.Lab2.Labworks;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class ExamSubjectsBuilder
{
    private string? _name;

    private int _examPoints = -1;

    private User? _author;

    private Dictionary<int, Labwork> _labworks = new();

    private Dictionary<int, Lecture> _lectures = new();

    public ExamSubjectsBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ExamSubjectsBuilder SetExamPoints(int examPoints)
    {
        if (examPoints < 0)
        {
            throw new ArgumentException("Exam points must be more or equal to 0");
        }

        _examPoints = examPoints;
        return this;
    }

    public ExamSubjectsBuilder SetAuthor(User user)
    {
        _author = user;
        return this;
    }

    public ExamSubjectsBuilder SetLabworks(Dictionary<int, Labwork> labworks)
    {
        _labworks = labworks;
        return this;
    }

    public ExamSubjectsBuilder SetLectures(Dictionary<int, Lecture> lectures)
    {
        _lectures = lectures;
        return this;
    }

    public ExamSubject GetResult()
    {
        if (_name == null || _examPoints == -1 || _author == null)
        {
            throw new InvalidOperationException("Exam subject's builder has insufficient data");
        }

        return new ExamSubject(_name, _examPoints, _author, _labworks, _lectures);
    }
}
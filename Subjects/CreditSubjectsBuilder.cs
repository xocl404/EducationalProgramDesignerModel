using Itmo.ObjectOrientedProgramming.Lab2.Labworks;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class CreditSubjectsBuilder
{
    private string? _name;

    private int _minPoints = -1;

    private User? _author;

    private Dictionary<int, Labwork> _labworks = new();

    private Dictionary<int, Lecture> _lectures = new();

    public CreditSubjectsBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public CreditSubjectsBuilder SetMinPoints(int minPoints)
    {
        if (minPoints < 0)
        {
            throw new ArgumentException("Min points must be more or equal to 0");
        }

        _minPoints = minPoints;
        return this;
    }

    public CreditSubjectsBuilder SetAuthor(User user)
    {
        _author = user;
        return this;
    }

    public CreditSubjectsBuilder SetLabworks(Dictionary<int, Labwork> labworks)
    {
        _labworks = labworks;
        return this;
    }

    public CreditSubjectsBuilder SetLectures(Dictionary<int, Lecture> lectures)
    {
        _lectures = lectures;
        return this;
    }

    public CreditSubject GetResult()
    {
        if (_name == null || _minPoints == -1 || _author == null)
        {
            throw new InvalidOperationException("Exam subject's builder has insufficient data");
        }

        return new CreditSubject(_name, _minPoints, _author, _labworks, _lectures);
    }
}
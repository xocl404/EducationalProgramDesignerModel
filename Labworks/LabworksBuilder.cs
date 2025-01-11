using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labworks;

public class LabworksBuilder
{
    private string? _name;

    private string? _description;

    private string? _evaluationCriteria;

    private int _points = -1;

    private User? _author;

    public LabworksBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LabworksBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public LabworksBuilder SetEvaluationCriteria(string evaluationCriteria)
    {
        _evaluationCriteria = evaluationCriteria;
        return this;
    }

    public LabworksBuilder SetPoints(int points)
    {
        if (points < 0)
        {
            throw new ArgumentException("Points must be more or equal to 0");
        }

        _points = points;
        return this;
    }

    public LabworksBuilder SetAuthor(User user)
    {
        _author = user;
        return this;
    }

    public Labwork GetResult()
    {
        if (_name == null || _description == null || _evaluationCriteria == null || _points == -1 || _author == null)
        {
            throw new InvalidOperationException("Labwork's builder has insufficient data");
        }

        return new Labwork(_name, _description, _evaluationCriteria, _points, _author);
    }
}
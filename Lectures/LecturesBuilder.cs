using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lectures;

public class LecturesBuilder
{
    private string? _name;

    private string? _shortDescription;

    private string? _content;

    private User? _author;

    public LecturesBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LecturesBuilder SetShortDescription(string shortDescription)
    {
        _shortDescription = shortDescription;
        return this;
    }

    public LecturesBuilder SetContent(string content)
    {
        _content = content;
        return this;
    }

    public LecturesBuilder SetAuthor(User user)
    {
        _author = user;
        return this;
    }

    public Lecture GetResult()
    {
        if (_name == null || _shortDescription == null || _content == null || _author == null)
        {
            throw new InvalidOperationException("Lecture's builder has insufficient data");
        }

        return new Lecture(_name, _shortDescription, _content, _author);
    }
}
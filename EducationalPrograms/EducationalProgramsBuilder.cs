using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public class EducationalProgramsBuilder
{
    private string? _name;

    private User? _manager;

    private Dictionary<int, Dictionary<int, ISubject>> _subjects = new();

    public EducationalProgramsBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public EducationalProgramsBuilder SetManager(User manager)
    {
        _manager = manager;
        return this;
    }

    public EducationalProgramsBuilder SetSubjects(Dictionary<int, Dictionary<int, ISubject>> subjects)
    {
        _subjects = subjects;
        return this;
    }

    public EducationalProgram GetResult()
    {
        if (_name == null || _manager == null)
        {
            throw new InvalidOperationException("Educational program's builder has insufficient data");
        }

        return new EducationalProgram(_name, _manager, _subjects);
    }
}
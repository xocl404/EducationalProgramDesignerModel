using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public class EducationalProgram : IEntity
{
    public Identificator Id { get; }

    public string Name { get; private set; }

    public User Manager { get; private set; }

    private readonly Dictionary<int, Dictionary<int, ISubject>> _subjects;

    public EducationalProgram(string name, User manager, Dictionary<int, Dictionary<int, ISubject>> subjects)
    {
        Id = new Identificator();
        Name = name;
        Manager = manager;
        _subjects = subjects;
    }

    public void AddSubject(int semester, ISubject subject, User user)
    {
        if (user != Manager)
        {
            throw new ArgumentException("This user can't change this educational program");
        }

        if (_subjects.ContainsKey(semester))
        {
            _subjects[semester].Add(subject.Id.Id, subject);
            return;
        }

        _subjects.Add(semester, new Dictionary<int, ISubject>());
        _subjects[semester].Add(subject.Id.Id, subject);
    }

    public void RemoveSubject(int semester, ISubject subject, User user)
    {
        if (Manager != user)
        {
            throw new ArgumentException("This user can't change this educational program");
        }

        if (!_subjects.ContainsKey(semester))
        {
            throw new KeyNotFoundException("Semester not found");
        }

        if (_subjects[semester].ContainsKey(subject.Id.Id))
        {
            throw new KeyNotFoundException("Subject not found");
        }

        _subjects[semester].Remove(subject.Id.Id);
    }
}
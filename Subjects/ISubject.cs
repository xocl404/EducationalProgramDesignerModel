using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public interface ISubject : IEntity
{
    Dictionary<int, Lecture> Lectures { get; }

    User Author { get; }

    int MaxPoints { get; }

    void ChangeName(string newName, User user);

    Lecture GetLecture(int id, User user);

    void AddLecture(Lecture lecture);

    void RemoveLecture(int id);
}
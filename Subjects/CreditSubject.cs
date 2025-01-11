using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Labworks;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class CreditSubject : ISubject, IClone<CreditSubject>
{
    public Identificator Id { get; }

    public string Name { get; private set; }

    public int MinPoints { get; }

    public int MaxPoints { get; } = 100;

    public User Author { get; }

    private readonly Dictionary<int, Labwork> _labworks;

    public Dictionary<int, Lecture> Lectures { get; }

    public CreditSubject(string name, int minPoints, User author, Dictionary<int, Labwork> labworks, Dictionary<int, Lecture> lectures)
    {
        Id = new Identificator();
        Name = name;
        MinPoints = minPoints;
        Author = author;
        int sumPoints = 0;
        foreach (KeyValuePair<int, Labwork> labwork in labworks)
        {
            sumPoints += labwork.Value.Points;
        }

        if (sumPoints > MaxPoints)
        {
            throw new ArgumentException("Max points exceeded");
        }

        if (sumPoints < MinPoints)
        {
            throw new ArgumentException("Min points isn't scored");
        }

        _labworks = labworks;
        Lectures = lectures;
    }

    private CreditSubject(Identificator id, string name, int minPoints, User author, Dictionary<int, Labwork> labworks, Dictionary<int, Lecture> lectures)
    {
        Id = new Identificator(id);
        Name = name;
        MinPoints = minPoints;
        Author = author;
        int sumPoints = 0;
        foreach (KeyValuePair<int, Labwork> labwork in labworks)
        {
            sumPoints += labwork.Value.Points;
        }

        if (sumPoints > MaxPoints)
        {
            throw new ArgumentException("Max points exceeded");
        }

        if (sumPoints < MinPoints)
        {
            throw new ArgumentException("Min points isn't scored");
        }

        _labworks = labworks;
        Lectures = lectures;
    }

    public CreditSubject Clone()
    {
        return new CreditSubject(Id, Name, MinPoints, Author, _labworks, Lectures);
    }

    public void ChangeName(string newName, User user)
    {
        if (user != Author)
        {
            throw new ArgumentException("This user can't change the name of this subject");
        }

        Name = newName;
    }

    public Lecture GetLecture(int id, User user)
    {
        if (user != Author)
        {
            throw new ArgumentException("This user can't get the lecture of this subject");
        }

        if (!Lectures.ContainsKey(id))
        {
            throw new ArgumentException("This lecture can't be found");
        }

        return Lectures[id];
    }

    public void AddLecture(Lecture lecture)
    {
        Lectures.TryAdd(lecture.Id.Id, lecture);
    }

    public void RemoveLecture(int id)
    {
        if (!Lectures.ContainsKey(id))
        {
            throw new ArgumentException("This lecture isn't added to this subject");
        }

        Lectures.Remove(id);
    }
}

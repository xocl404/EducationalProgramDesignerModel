using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labworks;

public class Labwork : IEntity, IClone<Labwork>
{
    public Identificator Id { get; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string EvaluationCriteria { get; }

    public int Points { get;  }

    public User Author { get; }

    public Labwork(string name, string description, string evaluationCriteria, int points, User author)
    {
        Id = new Identificator();
        Name = name;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        Points = points;
        Author = author;
    }

    private Labwork(Identificator id, string name, string description, string evaluationCriteria, int points, User author)
    {
        Id = new Identificator(id);
        Name = name;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        Points = points;
        Author = author;
    }

    public Labwork Clone()
    {
        return new Labwork(Id, Name, Description, EvaluationCriteria, Points, Author);
    }

    public void ChangeName(string newName, User user)
    {
        if (user != Author)
        {
            throw new ArgumentException("This user can't change the name of this labwork");
        }

        Name = newName;
    }

    public void ChangeDescription(string newDescription, User user)
    {
        if (user != Author)
        {
            throw new ArgumentException("This user can't change the description of this labwork");
        }

        Description = newDescription;
    }
}
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lectures;

public class Lecture : IEntity, IClone<Lecture>
{
    public Identificator Id { get; }

    public string Name { get; private set; }

    public string ShortDescription { get; private set; }

    public string Content { get; private set; }

    public User Author { get; }

    public Lecture(string name, string shortDescription, string content, User author)
    {
        Id = new Identificator();
        Name = name;
        ShortDescription = shortDescription;
        Content = content;
        Author = author;
    }

    private Lecture(Identificator id, string name, string shortDescription, string content, User author)
    {
        Id = new Identificator(id);
        Name = name;
        ShortDescription = shortDescription;
        Content = content;
        Author = author;
    }

    public Lecture Clone()
    {
        return new Lecture(Id, Name, ShortDescription, Content, Author);
    }

    public void ChangeName(string newName, User user)
    {
        if (user != Author)
        {
            throw new ArgumentException("This user can't change the name of this lecture");
        }

        Name = newName;
    }

    public void ChangeShortDescription(string newShortDescription, User user)
    {
        if (user != Author)
        {
            throw new ArgumentException("This user can't change the short description of this lecture");
        }

        ShortDescription = newShortDescription;
    }

    public void ChangeContent(string newContent, User user)
    {
        if (user != Author)
        {
            throw new ArgumentException("This user can't change the content of this lecture");
        }

        Content = newContent;
    }
}
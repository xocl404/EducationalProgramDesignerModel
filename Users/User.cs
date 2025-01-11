using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User : IEntity
{
    public Identificator Id { get; }

    public string Name { get; }

    public User(string name)
    {
        Id = new Identificator();
        Name = name;
    }
}
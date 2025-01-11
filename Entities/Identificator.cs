namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Identificator
{
    public static int CurrentId { get; private set; }

    public int Id { get; }

    public Identificator()
    {
        Id = ++CurrentId;
    }

    public Identificator(Identificator iden)
    {
        Id = iden.Id;
    }
}
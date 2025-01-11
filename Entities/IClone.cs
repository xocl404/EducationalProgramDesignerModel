namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IClone<TEntity>
{
    TEntity Clone();
}
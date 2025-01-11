using Itmo.ObjectOrientedProgramming.Lab2.Labworks;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Lab2.Tests;

public class Test2
{
    [Fact]
    public void CheckCloneIdentificator()
    {
        // Arrange
        var user = new User("Vladimir");
        Labwork labwork = new LabworksBuilder()
            .SetName("Algo")
            .SetAuthor(user)
            .SetDescription("Sort")
            .SetEvaluationCriteria("Normal")
            .SetPoints(10)
            .GetResult();
        Labwork cloneLbawork = labwork.Clone();

        // Act

        // Assert
        Assert.Equal(labwork.Id.Id, cloneLbawork.Id.Id);
    }
}
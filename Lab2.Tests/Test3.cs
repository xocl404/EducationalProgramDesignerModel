using Itmo.ObjectOrientedProgramming.Lab2.Labworks;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Lab2.Tests;

public class Test3
{
    [Fact]
    public void CheckSubjectMoreThan100Points()
    {
        // Arrange
        var user = new User("Vladimir");
        Labwork labwork = new LabworksBuilder()
            .SetName("Algo")
            .SetAuthor(user)
            .SetDescription("Sort")
            .SetEvaluationCriteria("Normal")
            .SetPoints(90)
            .GetResult();
        var labworks = new Dictionary<int, Labwork>();
        labworks.Add(labwork.Id.Id, labwork);

        // Act
        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            new ExamSubjectsBuilder()
                .SetName("Algo")
                .SetAuthor(user)
                .SetExamPoints(11)
                .SetLabworks(labworks)
                .GetResult());

        // Assert
        Assert.Equal("Max points exceeded", exception.Message);
    }
}
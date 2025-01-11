using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Lab2.Tests;

public class Test1
{
    [Fact]
    public void CheckChangeEntity()
    {
        // Arrange
        var user = new User("Vladimir");
        var otherUser = new User("Egor");
        Lecture lecture = new LecturesBuilder()
            .SetName("Algo")
            .SetAuthor(user)
            .SetContent("merge sort")
            .SetShortDescription("sort")
            .GetResult();

        // Act
        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            lecture.ChangeName("DM", otherUser));

        // Assert
        Assert.Equal("This user can't change the name of this lecture", exception.Message);
    }
}
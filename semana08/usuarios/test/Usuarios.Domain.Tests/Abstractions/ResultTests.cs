using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Tests.Abstractions;

public class ResultTests
{
    [Fact]
    public void Success_ShouldReturnIsSuccessTrueAndNoError()
    {
        //Arrange
        var result = Result.Success();

        //Act

        //Assert 
        Assert.True(result.IsSuccess);
        Assert.Equal(Error.None, result.Error);

    }

    [Fact]
    public void Failure_ShouldReturnIsSuccessFalseAndSpecifiedError()
    {
        //Arrange
        var error = Error.NullValue;

        //Act
        var result = Result.Failure(error);

        //Assert 
        Assert.False(result.IsSuccess);
        Assert.Equal(error, result.Error);

    }

}
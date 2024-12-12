using Docentes.Domain.Abstractions;

namespace Docentes.Domain.Test;

public class ResultTest
{
    [Fact]
    public void Success_Should_Return_SuccessResult()
    {
        var result = Result.Success();

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(result.Error,Error.None);
    }

    [Fact]
    public void Failure_Should_Return_FailureResult(){
        var error = new Error("Test","this is a test error");
        var result = Result.Failure(error);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(error,result.Error);
    }

    [Fact]
    public void SuccessTValue_Should_Return_SuccessResultWithValue()
    {
        // Given
        var value = "TestValue";
     
        // When
         var result = Result.Success(value);

        // Then
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(value,result.Value);
        Assert.Equal(Error.None,result.Error);
    }

}
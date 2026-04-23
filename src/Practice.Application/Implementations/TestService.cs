using Practice.Application.Interfaces;

namespace Practice.Application.Implementations;

public class TestService : ITestService
{
    public string GetResponse()
    {
        return "Hello";
    }
}
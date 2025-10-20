namespace CodeJetpack.Business;

public class JfMyService
{
    public string GetGreeting(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return "Hello from JfMyService!";

        return $"Hello, {name}! (from JfMyService)";
    }
}

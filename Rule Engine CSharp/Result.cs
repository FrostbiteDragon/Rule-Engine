namespace RuleEngine
{
    public abstract record Result { }
    public sealed record Pass : Result { }
    public sealed record Fail : Result
    {
        public string ErrorMessage { get; init; }

        public Fail(string errorMessage) => ErrorMessage = errorMessage;
    }
}
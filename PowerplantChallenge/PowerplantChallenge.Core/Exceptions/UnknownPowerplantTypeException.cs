namespace PowerplantChallenge.Core.Exceptions;

public class UnknownPowerplantTypeException : Exception
{
    private const string MESSAGE = "Unknwon powerplant type: {0}";

    public UnknownPowerplantTypeException(string powerplantType) : base(string.Format(MESSAGE, powerplantType)) { }
}

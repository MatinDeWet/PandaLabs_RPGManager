namespace Application.Common.Exceptions
{
    public class LocationHolderOutOfRangeException : ArgumentOutOfRangeException
    {
        public LocationHolderOutOfRangeException(string parameterName, object? value) : base(parameterName, value, "Invalid location holder")
        {
        }
    }
}

namespace Application.Common.Exceptions
{
    public class NoteHolderOutOfRangeException : ArgumentOutOfRangeException
    {
        public NoteHolderOutOfRangeException(string parameterName, object? value) : base(parameterName, value, "Invalid note holder")
        {
        }
    }
}

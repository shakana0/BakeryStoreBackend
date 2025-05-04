namespace Application.Exceptions
{
	public class NotFoundException : Exception
	{
		// Constructor with a message and additional context (second string argument)
		public NotFoundException(string message, string additionalContext)
			: base($"{message} - {additionalContext}") { }
	}
}
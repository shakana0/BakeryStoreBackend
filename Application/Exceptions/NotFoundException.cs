using System.Runtime.Serialization;

namespace Application.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string name, string key) : base($"Entity \"{name}\" ({key}) was not found.")
		{
		}

		protected NotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}

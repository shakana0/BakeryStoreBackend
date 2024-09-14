namespace Domain.Common
{
	public class CategoryDto
	{
		public int Id { get; private set; }
		public string Name { get; set; }

		// Constructor to set the Id
		public CategoryDto(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}

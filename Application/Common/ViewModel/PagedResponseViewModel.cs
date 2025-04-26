namespace Application.Common.ViewModel
{
	public class PagedResponseViewModel<T> : PagedResultBase where T : class
	{
		public List<T> Results { get; set; }

		public PagedResponseViewModel()
		{
			Results = new List<T>();
		}
		public PagedResponseViewModel(int totalRecords, int pageNumer, int pageSize, List<T> results)
		{
			Results = results ?? new List<T>();
			PageSize = pageSize;
			TotalItems = totalRecords;
			TotalPages = GetTotalPages();
			CurrentPage = pageNumer > TotalPages ? TotalPages : pageNumer;
		}
		private int GetTotalPages()
		{
			var totalPages = Convert.ToInt32(Math.Ceiling((double)TotalItems / (double)PageSize));
			return totalPages == 0 ? 1 : totalPages;

		}
	}
}

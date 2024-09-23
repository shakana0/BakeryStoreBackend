namespace Application.Common.ViewModel
{
	public abstract class PagedResultBase
	{
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public int TotalItems { get; set; }
		public int TotalPages { get; set; }

		public int FirstItemOnCurrentPage
		{
			get { return (CurrentPage - 1) * PageSize + (TotalItems == 0 ? 0 : 1); }
		}

		public int LastItemOnCurrentPage
		{
			get { return Math.Min(CurrentPage * PageSize, TotalItems); }
		}
	}
}

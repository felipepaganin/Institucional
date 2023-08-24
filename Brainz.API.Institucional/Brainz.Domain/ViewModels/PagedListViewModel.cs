using System.Collections.Generic;

namespace Brainz.Domain.ViewModels
{
    public class PagedListViewModel<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int RecordsOnPage { get; set; }

        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public List<T> Items { get; set; }
    }
}

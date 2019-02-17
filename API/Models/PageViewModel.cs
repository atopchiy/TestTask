using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCRUD.Models
{
    public class PageViewModel<T>
    {
        public int PageNumber { get;set; }
        public int TotalPages { get;set; }
        public List<T> Items { get; set; }
        public string Search { get; set; }
        public PageViewModel(int totalPages, int pageNumber, List<T> items, string search)
        {
            PageNumber = pageNumber;
            TotalPages = totalPages;
            Items = items;
            Search = search;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
    }
}

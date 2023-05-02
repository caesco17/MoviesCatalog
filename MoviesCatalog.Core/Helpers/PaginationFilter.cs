using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.Core.Helpers
{
    public class PaginationFilter
    {

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public OrderBy OrderBy { get; set; } = OrderBy.Name;
        public string? Category { get; set; } = "";
        public int? ReleaseYear { get; set; } = 0;
        public string? Name { get; set; } = "";
        public string? Synapsis { get; set; } = "";
        public PaginationFilter() { }
    }

    public enum OrderBy
    {
        ReleaseYear = 1,
        Name = 2,
        CreatedDate=3,
        Rating=4

    }

}

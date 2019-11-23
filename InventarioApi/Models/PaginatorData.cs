using System.Collections.Generic;

namespace InventarioApi.Models
{
    public class PaginatorData<T>
    {
        public List<T> Content { get; set; }
        public int Number { get; set; }
        public bool First { get; set; }
        public bool Last { get; set; }
        public int TotalPages { get; set; }
        public bool Empty { get; set; }
    }
}
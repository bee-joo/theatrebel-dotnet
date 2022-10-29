using System.ComponentModel;

namespace theatrebel.Data.Parameters
{
    public class Pagination 
    {
        [DefaultValue(1)]
        public int Page { get; set; } = 1;
        
        [DefaultValue(20)]
        public int Count { get; set; } = 20;
    }
}

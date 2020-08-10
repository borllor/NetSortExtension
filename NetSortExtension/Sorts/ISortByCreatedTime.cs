using System;

namespace NetSortExtension.Sorts
{
    public interface ISortByCreatedTime : ISort
    {
        DateTime CreatedTime { get; set; }
    }
}

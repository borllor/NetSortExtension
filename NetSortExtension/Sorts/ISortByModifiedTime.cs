using System;

namespace NetSortExtension.Sorts
{
    public interface ISortByModifiedTime : ISort
    {
        DateTime ModifiedTime { get; set; }
    }
}

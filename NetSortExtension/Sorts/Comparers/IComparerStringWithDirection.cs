using System;

namespace NetSortExtension.Sorts.Comparers
{
    public interface IComparerStringWithDirection : IComparerWithDirection
    {
        int Compare(object x, object y, SortDirectionEnum direction, StringComparison stringComparison);
    }
}
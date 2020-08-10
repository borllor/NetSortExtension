using System.Collections;

namespace NetSortExtension.Sorts.Comparers
{
    public interface IComparerWithDirection : IComparer
    {
        int Compare(object x, object y, SortDirectionEnum direction);
    }
}
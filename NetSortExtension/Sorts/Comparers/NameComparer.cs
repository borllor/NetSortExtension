using System;

namespace NetSortExtension.Sorts.Comparers
{
    public class NameComparer : IComparerStringWithDirection
    {
        private SortDirectionEnum _direction;
        private StringComparison _stringComparison;

        public NameComparer(SortDirectionEnum direction, StringComparison stringComparison)
        {
            _direction = direction;
            _stringComparison = stringComparison;
        }

        public int Compare(object x, object y)
        {
            return Compare(x, y, _direction);
        }

        public int Compare(object x, object y, SortDirectionEnum direction)
        {
            return Compare(x, y, _direction, _stringComparison);
        }

        public int Compare(object x, object y, SortDirectionEnum direction, StringComparison stringComparison)
        {
            int directionValue = direction == SortDirectionEnum.ASC ? 1 : -1;
            if (x == null && y == null) return 0;
            if (x == null) return -1 * directionValue;
            if (y == null) return 1 * directionValue;
            if (!(x is ISortByName) && !(y is ISortByName)) return 0;
            if (!(x is ISortByName)) return -1 * directionValue;
            if (!(y is ISortByName)) return 1 * directionValue;
            return directionValue * string.Compare(((ISortByName) x).Name, ((ISortByName) y).Name,
                stringComparison);
        }
    }
}
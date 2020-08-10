using System;

namespace NetSortExtension.Sorts.Comparers
{
    public class CreatedTimeComparer : IComparerWithDirection
    {
        private SortDirectionEnum _direction;

        public CreatedTimeComparer(SortDirectionEnum direction)
        {
            _direction = direction;
        }

        public int Compare(object x, object y)
        {
            return Compare(x, y, _direction);
        }

        public int Compare(object x, object y, SortDirectionEnum direction)
        {
            int directionValue = direction == SortDirectionEnum.ASC ? 1 : -1;
            if (x == null && y == null) return 0;
            if (x == null) return -1 * directionValue;
            if (y == null) return 1 * directionValue;
            if (!(x is ISortByCreatedTime) && !(y is ISortByCreatedTime)) return 0;
            if (!(x is ISortByCreatedTime)) return -1 * directionValue;
            if (!(y is ISortByCreatedTime)) return 1 * directionValue;
            return directionValue *
                   DateTime.Compare(((ISortByCreatedTime) x).CreatedTime, ((ISortByCreatedTime) y).CreatedTime);
        }
    }
}
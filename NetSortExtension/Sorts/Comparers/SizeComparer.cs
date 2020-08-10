namespace NetSortExtension.Sorts.Comparers
{
    public class SizeComparer : IComparerWithDirection
    {
        private SortDirectionEnum _direction;

        public SizeComparer(SortDirectionEnum direction)
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
            if (!(x is ISortByFileSize) && !(y is ISortByFileSize)) return 0;
            if (!(x is ISortByFileSize)) return -1 * directionValue;
            if (!(y is ISortByFileSize)) return 1 * directionValue;
            return directionValue * (int) (((ISortByFileSize) x).Size - ((ISortByFileSize) y).Size);
        }
    }
}
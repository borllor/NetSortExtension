namespace NetSortExtension.Sorts.Comparers
{
    public class DisplayOrderComparer : IComparerWithDirection
    {
        private SortDirectionEnum _direction;

        public DisplayOrderComparer(SortDirectionEnum direction)
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
            if (!(x is ISortByDisplayOrder) && !(y is ISortByDisplayOrder)) return 0;
            if (!(x is ISortByDisplayOrder)) return -1 * directionValue;
            if (!(y is ISortByDisplayOrder)) return 1 * directionValue;
            return directionValue * (((ISortByDisplayOrder) x).DisplayOrder - ((ISortByDisplayOrder) y).DisplayOrder);
        }
    }
}
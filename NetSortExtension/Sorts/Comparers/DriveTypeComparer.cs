namespace NetSortExtension.Sorts.Comparers
{
    public class DriveTypeComparer : IComparerWithDirection
    {
        private SortDirectionEnum _direction;

        public DriveTypeComparer(SortDirectionEnum direction)
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
            if (!(x is ISortByDriveType) && !(y is ISortByDriveType)) return 0;
            if (!(x is ISortByDriveType)) return -1 * directionValue;
            if (!(y is ISortByDriveType)) return 1 * directionValue;
            return directionValue * (((ISortByDriveType) x).DriveType - ((ISortByDriveType) y).DriveType);
        }
    }
}
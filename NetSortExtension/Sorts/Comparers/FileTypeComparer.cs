namespace NetSortExtension.Sorts.Comparers
{
    public class FileTypeComparer : IComparerWithDirection
    {
        private SortDirectionEnum _direction;

        public FileTypeComparer(SortDirectionEnum direction)
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
            if (!(x is ISortByFileType) && !(y is ISortByFileType)) return 0;
            if (!(x is ISortByFileType)) return -1 * directionValue;
            if (!(y is ISortByFileType)) return 1 * directionValue;
            return directionValue * (((ISortByFileType) x).FileType - ((ISortByFileType) y).FileType);
        }
    }
}
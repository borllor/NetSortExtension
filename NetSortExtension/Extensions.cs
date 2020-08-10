using NetSortExtension.Sorts;
using NetSortExtension.Sorts.Comparers;
using System;
using System.Collections.Generic;

namespace NetSortExtension
{
    public static class Extensions
    {
        private static readonly CreatedTimeComparer _createdTimeComparer =
        new CreatedTimeComparer(SortDirectionEnum.ASC);

        private static readonly DisplayOrderComparer _displayOrderComparer =
            new DisplayOrderComparer(SortDirectionEnum.ASC);

        private static readonly DriveTypeComparer _driveTypeComparer =
            new DriveTypeComparer(SortDirectionEnum.ASC);

        private static readonly FileExtensionComparer _fileExtensionComparer =
            new FileExtensionComparer(SortDirectionEnum.ASC, StringComparison.Ordinal);

        private static readonly FileTypeComparer _fileTypeComparer =
            new FileTypeComparer(SortDirectionEnum.ASC);

        private static readonly ModifiedTimeComparer _modifiedTimeComparer =
            new ModifiedTimeComparer(SortDirectionEnum.ASC);

        private static readonly NameComparer _nameComparer =
            new NameComparer(SortDirectionEnum.ASC, StringComparison.Ordinal);

        private static readonly SizeComparer _sizeComparer =
            new SizeComparer(SortDirectionEnum.ASC);

        public static void SortBy<T>(this List<T> list, SortDirectionEnum sortDirection,
            params SortByEnum[] sortByList)
        {
            SortBy(list, sortDirection, StringComparison.Ordinal, sortByList);
        }

        public static void SortBy<T>(this List<T> list, SortDirectionEnum sortDirection, StringComparison stringComparison,
            params SortByEnum[] sortByList)
        {
            if (sortByList == null || sortByList.Length == 0) return;
            int directionValue = sortDirection == SortDirectionEnum.ASC ? 1 : -1;
            list.Sort((x, y) =>
            {
                int comparedValue = 0;
                foreach (SortByEnum sortByEnum in sortByList)
                {
                    switch (sortByEnum)
                    {
                        case SortByEnum.Default:
                        case SortByEnum.Name:
                            comparedValue = _nameComparer.Compare(x, y, sortDirection, stringComparison);
                            if (comparedValue != 0) return comparedValue;
                            break;
                        case SortByEnum.Size:
                            comparedValue = _sizeComparer.Compare(x, y, sortDirection);
                            if (comparedValue != 0) return comparedValue;
                            break;
                        case SortByEnum.FileType:
                            comparedValue = _fileTypeComparer.Compare(x, y, sortDirection);
                            if (comparedValue != 0) return comparedValue;
                            break;
                        case SortByEnum.Extension:
                            comparedValue = _fileExtensionComparer.Compare(x, y, sortDirection, stringComparison);
                            if (comparedValue != 0) return comparedValue;
                            break;
                        case SortByEnum.ModifiedTime:
                            comparedValue = _modifiedTimeComparer.Compare(x, y, sortDirection);
                            if (comparedValue != 0) return comparedValue;
                            break;
                        case SortByEnum.CreatedTime:
                            comparedValue = _createdTimeComparer.Compare(x, y, sortDirection);
                            if (comparedValue != 0) return comparedValue;
                            break;
                        case SortByEnum.DisplayOrder:
                            comparedValue = _displayOrderComparer.Compare(x, y, sortDirection);
                            if (comparedValue != 0) return comparedValue;
                            break;
                        case SortByEnum.DriveType:
                            comparedValue = _driveTypeComparer.Compare(x, y, sortDirection);
                            if (comparedValue != 0) return comparedValue;
                            break;
                    }
                }

                return comparedValue;
            });
        }
    }
}

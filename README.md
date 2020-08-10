# SortExtension can make you sort by more than one field/property/column, multiple fields, properties or columns.

## Background/Requirements
1. Sort files by Drive(C:\, D:\), Folder/File, Filename and then Extension.
2. Sort by more than one field or property just like the syntax in SQL Server.
3. Yes, Ling(list.OrderBy(n => ).ThenBy().ThenBy()) is a way as well, but tradition is my favorite.

```SQL
SELECT * FROM [TableName] ORDER BY CreatedTime, FileType, FileSize DESC;
```

##  Support language
* .Net Framework.
* .Net Core

## How to use

```C#
    List<T> fileList = new List<T>(); // T should implement the sort interfaces.
    fileList.SortBy(SortDirectionEnum.DESC, StringComparison.CurrentCultureIgnoreCase, SortByEnum.DriveType, SortByEnum.FileType, SortByEnum.Name);
```

## Points of multi-sorting

```C#
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
```
## Practice in our projects

```C#
    private void SortList(List<BaseFileInfo> fileList, ColumnHeader columnSorted)
    {
        TagData tagData = columnSorted.Tag as TagData;
        SortByEnum sortBy = tagData.GetFirstData<SortByEnum>();
        SortDirectionEnum sortDirection = tagData.GetSecondData<SortDirectionEnum>();
        switch (sortBy)
        {
            case SortByEnum.Default:
            case SortByEnum.Name:
                fileList.SortBy(sortDirection, SortByEnum.DriveType, SortByEnum.FileType, SortByEnum.Name);
                break;
            case SortByEnum.Size:
                fileList.SortBy(sortDirection, SortByEnum.Size);
                break;
            case SortByEnum.FileType:
                fileList.SortBy(sortDirection, SortByEnum.FileType);
                break;
            case SortByEnum.CreatedTime:
                fileList.SortBy(sortDirection, SortByEnum.CreatedTime);
                break;
            case SortByEnum.ModifiedTime:
                fileList.SortBy(sortDirection, SortByEnum.ModifiedTime);
                break;
        }
    }
```






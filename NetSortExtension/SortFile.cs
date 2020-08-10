using NetSortExtension.Sorts;
using System;

namespace NetSortExtension
{
    public class SortFile : ISort, ISortByName, ISortByFileSize, ISortByCreatedTime,
        ISortByFileType, ISortByModifiedTime, ISortByExtension
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string ExtensionWithDot { get; set; }
        public string FullPath { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string SizeText { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public virtual FileTypeEnum FileType { get; set; }
    }
}

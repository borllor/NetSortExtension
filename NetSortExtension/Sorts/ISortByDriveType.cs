using System.IO;

namespace NetSortExtension.Sorts
{
    public interface ISortByDriveType : ISort
    {
        DriveType DriveType { get; set; }
    }
}
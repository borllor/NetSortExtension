namespace NetSortExtension.Sorts
{
    public interface ISortByFileSize : ISort
    {
        long Size { get; set; }
    }
}

namespace NetSortExtension.Sorts
{
    public interface ISortByDisplayOrder : ISort
    {
        int DisplayOrder { get; }
    }
}
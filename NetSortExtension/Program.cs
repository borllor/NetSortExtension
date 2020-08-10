using NetSortExtension.Sorts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetSortExtension
{
    class Program
    {
        static void Main()
        {
            List<SortFile> fileList = new List<SortFile>();
            fileList.SortBy(SortDirectionEnum.Default, StringComparison.CurrentCultureIgnoreCase, SortByEnum.DriveType, SortByEnum.FileType, SortByEnum.Name);
            Console.ReadKey();
        }
    }
}

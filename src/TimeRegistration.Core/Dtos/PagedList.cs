using System;
using System.Collections.Generic;

namespace TimeRegistration.Core.Dtos
{
    public class PagedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that contains the already divided subset and information about the size of the superset and the subset's position within it.
        /// </summary>
        /// <param name="subset">The single subset this collection should represent.</param>
        /// <param name="pageNumber">The one-based index of the subset of objects contained by this instance.</param>
        /// <param name="pageSize">The maximum size of any individual subset.</param>
        /// <param name="totalItemCount">The size of the superset.</param>
        /// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
        public PagedList(IEnumerable<T> subset, int pageNumber, int pageSize, int totalItemCount)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be below 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");
            }

            List = subset;
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
            PageCount = TotalItemCount > 0
                ? (int) Math.Ceiling(TotalItemCount / (double) PageSize)
                : 0;
        }

        public IEnumerable<T> List { get; set; }

        public int PageCount { get; private set; }

        public int TotalItemCount { get; private set; }

        public int PageNumber { get; private set; }

        public int PageSize { get; private set; }
    }
}
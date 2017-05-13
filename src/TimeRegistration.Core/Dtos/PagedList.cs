using System;
using System.Collections.Generic;

namespace TimeRegistration.Core.Dtos
{
    public class PagedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that contains the already divided subset and total amount of items in the set.
        /// </summary>
        /// <param name="subset">The single subset this collection should represent.</param>
        /// <param name="totalItemCount">The size of the superset.</param>
        public PagedList(IEnumerable<T> subset, int totalItemCount)
        {
            List = subset;
            TotalItemCount = totalItemCount;
        }

        public IEnumerable<T> List { get; set; }
        
        public int TotalItemCount { get; private set; }
    }
}
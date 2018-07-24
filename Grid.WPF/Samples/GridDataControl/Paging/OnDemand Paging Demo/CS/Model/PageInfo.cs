using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnDemandPagingDemo
{
    public class PageInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageInfo"/> class.
        /// </summary>
        /// <param name="PagedRows">The paged rows.</param>
        /// <param name="MaximumRows">The maximum rows.</param>
        public PageInfo(int PagedRows, int MaximumRows)
        {
            this.StartIndex = PagedRows;
            this.EndIndex = PagedRows + MaximumRows;
        }

        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }
}

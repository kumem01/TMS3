using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMS3.Library.Repositories
{
    public class RepositoryResultList<T> : RepositoryResult
    {
        private int? _totalItemsCount = null;

        public IEnumerable<T> Entities { get; set; }

        public bool ListIsNullOrEmpty
        {
            get
            {
                if (Entities == null || Entities.Count() == 0)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Total number of items in the superset
        /// </summary>
        public int TotalItemCount 
        { 
            get
            {
                if (_totalItemsCount == null && Entities != null)
                {
                    _totalItemsCount = Entities.Count();
                }

                return _totalItemsCount ?? 0;
            }
            set
            {
                _totalItemsCount = value;
            }
        }
    }
}

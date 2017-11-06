using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMS3.Library.Repositories
{
    public class RepositoryResultSingle<T> : RepositoryResult
    {
        public RepositoryResultSingle()
        {

        }
        public RepositoryResultSingle(RepositoryResult repositoryResult)
        {
            this.Message = repositoryResult.Message;
            this.NoErrors = repositoryResult.NoErrors;
        }

        public T Entity { get; set; }

        public bool HasValue
        {
            get
            {
                if (Entity == null)
                    return false;

                return true;
            }
        }
    }
}

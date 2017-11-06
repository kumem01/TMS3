using System;
using System.Collections.Generic;
using System.Text;

namespace TMS3.Library.Entities
{
     public abstract class _BaseEntity
    {
        public DateTime JrnCreatedDate { get; set; } 
        public string  JrnCreatedBy { get; set; }
        public DateTime JrnModifiedDate { get; set; } 
        public string JrnModifiedBy { get; set; }
    }
}

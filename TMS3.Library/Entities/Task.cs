using System;
using System.Collections.Generic;
using System.Text;

namespace TMS3.Library.Entities
{
    public partial class Task: _BaseEntity
    {

        public int TaskID { get; set; }
        public int TaskNumber { get; set; }
        public string  TaskName { get; set; }
        public string DescText { get; set; }
        public string CommentText { get; set; }
        public int TaskStatusRefrenceTypeID { get; set; }
        public int? ElementCodeID { get; set; }
        public bool IsOverhead { get; set; }
        public bool IsAllocable { get; set; }
        public bool IsUpdateREquired { get; set; }

        public ICollection<TaskContact> TaskContacts { get; set; }
        public ICollection<TaskDate> TaskDAtes { get; set; }
        public ICollection<TaskCost> TaskCosts { get; set; }
    }
}

using System;

namespace TMS3.Library.Entities
{
    public partial class TaskDate:_BaseEntity

    {

        public int TaskDateID { get; set; }
        public Task Task { get; set; }
        public int TaskDateReferenceTypeID { get; set; }
        public DateTime ActionDate { get; set; }
        public Person Person { get; set; }
        public string CommentText { get; set; }



    }
}
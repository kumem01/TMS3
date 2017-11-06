namespace TMS3.Library.Entities
{
    public partial class TaskContact:_BaseEntity
    {
        public int TaskContactID { get; set; }
        public Task Task { get; set; }
        public Person Person { get; set; }
        public int ContactTypeID { get; set; }
    }
}
namespace TMS3.Library.Entities
{
    public partial class TaskCost:_BaseEntity
    {
        public int TaskCostID { get; set; }
        public Task Task { get; set; }
        public bool IsEstimate { get; set; }
        public int? ParentTaskCostID { get; set; }
        public int ExpenseTypeReferenceTypeID { get; set; }
        public string CostTitle { get; set; }
        public string DescText { get; set; }
        public decimal Amount { get; set; }
        public int? PaymentMehtodreferenceTypeID { get; set; }
        public int? VendorTypeReferenceTypeID { get; set; }
        public string PONumber { get; set; }
        public string CommentText { get; set; }


    }
}
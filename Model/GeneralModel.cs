namespace Invoice.Model
{
    public class GeneralModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public long RecordId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}

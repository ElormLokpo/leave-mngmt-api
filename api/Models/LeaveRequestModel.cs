namespace api.Models
{
    public class LeaveRequestModel
    {
        public Guid? Id { get; set; }
       
        public bool? IsRejected { get; set; }
        public bool? IsPending { get; set; }

        public bool? IsApproved { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Duration { get; set; }
        public DateTime? EndDate { get; set; }

        public EmployeeModel? Employee { get; set; }
        public ManagerModel? Manager { get; set; }
    }
}

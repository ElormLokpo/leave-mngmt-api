

namespace api.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string? StaffNumber { get; set; }
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Othernames { get; set; }
        public string? Department { get; set; }
        public ManagerModel? Manager { get; set; }
        public int? LeaveDaysLeft { get; set; }
        public ICollection<LeaveRequestModel>? LeaveRequests { get; set; }

    }
}
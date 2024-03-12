using api.Models;

namespace api.Entities
{
    public class EmployeeEntity
    {

    }

    public class AddEmployeeRequest {
        public EmployeeModel Employee { get; set; }
    
    }

    public class MessageResponse
    {
        public string Message { get; set; }

    }

    public class EmployeeIdRequest {
        public Guid EmployeeId { get; set; }
     }

    public class EmployeeStaffNumberRequest
    {
        public string StaffNumber { get; set; }
    }

    public class EmployeeByFullnameRequest
    {
        public string Fullname { get; set; }
    }


    public class EmployeeArrResponse {
        public string Message { get; set; } 

        public ICollection<EmployeeModel> EmployeesArr { get; set; }
        
    }

    public class EmployeeExistResponse {
        public bool Exists { get; set; }
    }

    public class EmployeeResponse { 
    
        public string Message { get; set; }
        public EmployeeModel Employee { get; set; }
    }
    
}

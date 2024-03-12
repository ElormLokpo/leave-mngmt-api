using api.Entities;

namespace api.Interfaces
{
    public interface IEmployeeInterface
    {

        public MessageResponse AddEmployee(AddEmployeeRequest request);

        public EmployeeArrResponse GetAllEmployees();

        public EmployeeResponse GetEmployeeById(EmployeeIdRequest request);
        public EmployeeResponse GetEmployeeByStaffNumber(EmployeeStaffNumberRequest request);

        public EmployeeExistResponse EmployeeExists(EmployeeIdRequest request);

        public EmployeeResponse EmployeeByFullname(EmployeeByFullnameRequest request);


    }
}

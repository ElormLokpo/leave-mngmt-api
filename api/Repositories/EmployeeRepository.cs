using api.Entities;
using api.Interfaces;
using api.Models;
using api.Data;
using Azure.Core;

namespace api.Repositories
{
    public class EmployeeRepository : IEmployeeInterface
    {
        public LeaveDataContext _context;

        public EmployeeRepository(LeaveDataContext context)
        {
            _context = context;
        }

        public MessageResponse AddEmployee(AddEmployeeRequest request)
        {
            MessageResponse response = new MessageResponse();

            request.Employee.Id = Guid.NewGuid();

            _context.Employees.Add(request.Employee);

            _context.SaveChanges();
            

            return response;
        }

        public EmployeeArrResponse GetAllEmployees()
        {

            var employeeList = _context.Employees.ToList();

            EmployeeArrResponse response = new EmployeeArrResponse();
            response.Message = "Success";
            response.EmployeesArr = employeeList;

            return response;
        }

        public EmployeeResponse GetEmployeeById(EmployeeIdRequest request)
        {
            EmployeeResponse response = new EmployeeResponse();


            bool employee_exists = _context.Employees.Any(dd => dd.Id == request.EmployeeId);
            if (!employee_exists)
            {
                response.Message = "Employee does not exist";
                return response;
            }


            var found_employee = _context.Employees.Where(aa => aa.Id == request.EmployeeId).FirstOrDefault();

            response.Message = "Success";
            response.Employee = found_employee;

            

            return response;
        }

        public EmployeeResponse GetEmployeeByStaffNumber(EmployeeStaffNumberRequest request)
        {
            EmployeeResponse response = new EmployeeResponse();

            bool employee_exists = _context.Employees.Any(dd => dd.StaffNumber == request.StaffNumber);
            if (!employee_exists)
            {
                response.Message = "Employee does not exist";
                return response;
            }


            var found_employee = _context.Employees.Where(aa => aa.StaffNumber == request.StaffNumber).FirstOrDefault();

            response.Message = "Success";
            response.Employee = found_employee;


            return response;
        }

        public EmployeeExistResponse EmployeeExists(EmployeeIdRequest request)
        {
            EmployeeExistResponse response = new EmployeeExistResponse();


            bool employee_exists = _context.Employees.Any(dd => dd.Id == request.EmployeeId);
            if (!employee_exists)
            {
                response.Exists = false;
                return response;
            }


            return response;
        }

        public EmployeeResponse EmployeeByFullname(EmployeeByFullnameRequest request)
        {

            EmployeeResponse response = new EmployeeResponse();

            string[] namesArr = request.Fullname.Split(new char[] { ' ', ',','?','!'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string name in namesArr)
            {
                var firstnameExists = _context.Employees.Where(aa => aa.Firstname == name).FirstOrDefault();
                
                if (firstnameExists != null)
                {
                    response.Message = "User found";
                    response.Employee = firstnameExists;
                    return response;
                }

                var surnameExists = _context.Employees.Where(aa => aa.Surname == name).FirstOrDefault();

                if (surnameExists != null)
                {
                    response.Message = "User found";
                    response.Employee = surnameExists;
                    return response;
                }

                var othernamesExists = _context.Employees.Where(aa => aa.Othernames == name).FirstOrDefault();

                if (othernamesExists != null)
                {
                    response.Message = "User found";
                    response.Employee = othernamesExists;
                    return response;
                }
            }


            return response;
        }
    }
}

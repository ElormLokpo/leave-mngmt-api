using api.Data;
using api.Entities;
using api.Interfaces;

namespace api.Repositories
{
    public class ManagerRepository : IManagerInterface
    {
        public LeaveDataContext _context;

        public ManagerRepository(LeaveDataContext context)
        {
            _context = context;
        }

        public ManagerArrResponse GetAllManagers()
        {

            var employeeList = _context.Managers.ToList();

            ManagerArrResponse response = new ManagerArrResponse();
            response.Message = "Success";
            response.ManagersArr = employeeList;

            return response;
        }

        public ManagerResponse GetManagerById(ManagerIdRequest request)
        {
            ManagerResponse response = new ManagerResponse();


            bool employee_exists = _context.Managers.Any(dd => dd.Id == request.ManagerId);
            if (!employee_exists)
            {
                response.Message = "Manager does not exist";
                return response;
            }


            var found_employee = _context.Managers.Where(aa => aa.Id == request.ManagerId).FirstOrDefault();

            response.Message = "Success";
            response.Manager = found_employee;



            return response;
        }

        public ManagerResponse GetManagerByStaffNumber(ManagerStaffNumberRequest request)
        {
            ManagerResponse response = new ManagerResponse();

            bool employee_exists = _context.Managers.Any(dd => dd.StaffNumber == request.StaffNumber);
            if (!employee_exists)
            {
                response.Message = "Manager does not exist";
                return response;
            }


            var found_employee = _context.Managers.Where(aa => aa.StaffNumber == request.StaffNumber).FirstOrDefault();

            response.Message = "Success";
            response.Manager = found_employee;


            return response;
        }

        public ManagerExistResponse ManagerExists(ManagerIdRequest request)
        {
            ManagerExistResponse response = new ManagerExistResponse();


            bool employee_exists = _context.Managers.Any(dd => dd.Id == request.ManagerId);
            if (!employee_exists)
            {
                response.Exists = false;
                return response;
            }


            return response;
        }

        public ManagerResponse ManagerByFullname(ManagerByFullnameRequest request)
        {

            ManagerResponse response = new ManagerResponse();

            string[] namesArr = request.Fullname.Split(new char[] { ' ', ',', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string name in namesArr)
            {
                var firstnameExists = _context.Managers.Where(aa => aa.Firstname == name).FirstOrDefault();

                if (firstnameExists != null)
                {
                    response.Message = "User found";
                    response.Manager = firstnameExists;
                    return response;
                }

                var surnameExists = _context.Managers.Where(aa => aa.Surname == name).FirstOrDefault();

                if (surnameExists != null)
                {
                    response.Message = "User found";
                    response.Manager = surnameExists;
                    return response;
                }

                var othernamesExists = _context.Managers.Where(aa => aa.Othernames == name).FirstOrDefault();

                if (othernamesExists != null)
                {
                    response.Message = "User found";
                    response.Manager = othernamesExists;
                    return response;
                }
            }


            return response;
        }
    }
}

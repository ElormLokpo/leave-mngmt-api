using api.Models;

namespace api.Entities
{
    public class ManagerEntity
    {
    }


    public class AddManagerRequest
    {
        public ManagerModel Manager { get; set; }

    }

    public class ManagerIdRequest
    {
        public Guid ManagerId { get; set; }
    }

    public class ManagerStaffNumberRequest
    {
        public string StaffNumber { get; set; }
    }

    public class ManagerByFullnameRequest
    {
        public string Fullname { get; set; }
    }


    public class ManagerArrResponse
    {
        public string Message { get; set; }

        public ICollection<ManagerModel> ManagersArr { get; set; }

    }

    public class ManagerExistResponse
    {
        public bool Exists { get; set; }
    }

    public class ManagerResponse
    {

        public string Message { get; set; }
        public ManagerModel Manager { get; set; }
    }
}

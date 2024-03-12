using api.Entities;

namespace api.Interfaces
{
    public interface IManagerInterface
    {
        public ManagerArrResponse GetAllManagers();

        public ManagerResponse GetManagerById(ManagerIdRequest request);
        public ManagerResponse GetManagerByStaffNumber(ManagerStaffNumberRequest request);

        public ManagerExistResponse ManagerExists(ManagerIdRequest request);

        public ManagerResponse ManagerByFullname(ManagerByFullnameRequest request);
    }
}

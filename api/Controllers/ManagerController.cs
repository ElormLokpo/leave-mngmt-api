using api.Entities;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        public IManagerInterface _iemployeeinterface;
        public ManagerController(IManagerInterface iemployeeinterface)
        {
            _iemployeeinterface = iemployeeinterface;
        }

        [HttpGet("all")]
        public ActionResult GetAllManagersController()
        {
            var employeeArray = _iemployeeinterface.GetAllManagers();

            return Ok(employeeArray);
        }

        [HttpGet("id")]
        public ActionResult GetManagersByIdController([FromBody] ManagerIdRequest request)
        {

            var employee = _iemployeeinterface.GetManagerById(request);

            return Ok(employee);

        }

        [HttpGet("staffnumber")]
        public ActionResult GetManagerByStaffNumberController([FromBody] ManagerStaffNumberRequest request)
        {

            var employee = _iemployeeinterface.GetManagerByStaffNumber(request);
            return Ok(employee);
        }

        [HttpGet("fullname")]
        public ActionResult GetManagerByFullnameController([FromBody] ManagerByFullnameRequest request)
        {
            var employee = _iemployeeinterface.ManagerByFullname(request);

            return Ok(employee);
        }


        [HttpGet("exists")]
        public ActionResult ManagerExistsController([FromBody] ManagerIdRequest request)
        {
            var employee = _iemployeeinterface.ManagerExists(request);

            return Ok(employee);
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;


using api.Models;


namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController:ControllerBase
    {
        public IEmployeeInterface _iemployeeinterface;
        private readonly IConfiguration _configuration;


        public EmployeeController(IEmployeeInterface iemployeeinterface, IConfiguration configuration)
        {
            _iemployeeinterface = iemployeeinterface;
            _configuration = configuration;
        }

        [HttpPost("add")]
        public ActionResult AddEmployeeController([FromBody] AddEmployeeRequest request)
        {
            var response = _iemployeeinterface.AddEmployee(request);

            return Ok(response);
        }



        [HttpGet("all")]
        public ActionResult GetAllEmployeesController()
        {
            var employeeArray = _iemployeeinterface.GetAllEmployees();

            return Ok(employeeArray);
        }

        [HttpGet("id")]
        public ActionResult GetEmployeesByIdController([FromBody] EmployeeIdRequest request)
        {

            var employee = _iemployeeinterface.GetEmployeeById(request);

            return Ok(employee);

        }

        [HttpGet("staffnumber")]
        public ActionResult GetEmployeeByStaffNumberController([FromBody] EmployeeStaffNumberRequest request)
        {

            var employee = _iemployeeinterface.GetEmployeeByStaffNumber(request);
            return Ok(employee);
        }

        [HttpGet("fullname")]
        public ActionResult GetEmployeeByFullnameController([FromBody] EmployeeByFullnameRequest request)
        {
            var employee = _iemployeeinterface.EmployeeByFullname(request);

            return Ok(employee);
        }


        [HttpGet("exists")]
        public ActionResult EmployeeExistsController([FromBody] EmployeeIdRequest request)
        {
            var employee = _iemployeeinterface.EmployeeExists(request);

            return Ok(employee);
        }


        [HttpPost("token")]
        public ActionResult TokenController()
        {
            AdminModel admin = new AdminModel();
            admin.Fullname = "Osei Kwesi";
            admin.Email = "smaple email";
            admin.Password = "sample password";
            admin.Username = "sample username";
            admin.Id = Guid.NewGuid();

            var token = CreateToken(admin);

            return Ok(token);
        }




        private string CreateToken(AdminModel user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}

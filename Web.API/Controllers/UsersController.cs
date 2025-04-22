using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reopsitre.IReopsitre;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly IUserReopsitre _userReopsitre;
        private readonly IJobDescriptionReopsitre _jobDescriptionReopsitre;
        private readonly IErrorLogReopsitre _errorLogReopsitre; 
        public UsersController(IUserReopsitre userReopsitre, IJobDescriptionReopsitre jobDescriptionReopsitre, IErrorLogReopsitre errorLogReopsitre)
        {
            _userReopsitre = userReopsitre;
            _jobDescriptionReopsitre = jobDescriptionReopsitre;
            _errorLogReopsitre = errorLogReopsitre; 
        }

        public IActionResult GetAllUsers()
        {
            List<Infrastructure.DTO.UserDTO> lis = new List<Infrastructure.DTO.UserDTO>();


            lis = (from obj in _userReopsitre.Find(x => x.UserId != 0, x => x.JobDescription)
                   select new Infrastructure.DTO.UserDTO
                   {
                       UserId = obj.UserId,
                       GenderDisplayName = obj.Gender == true ? "Male" : "Female",
                       FirstName = obj.FirstName,
                       LastName = obj.LastName,
                       Email = obj.Email,
                       Address = obj.Address,
                       DateOfBirth = obj.DateOfBirth,
                       JoinDate = obj.JoinDate,
                       MobileNumber = obj.MobileNumber,
                       Salary = obj.Salary,
                       shifttypeName = obj.ShiftType == false ? "Shaft A" : "Shaft B",
                       JobDiscrptionName = obj.JobDescription.Name,
                       IsActive = obj.IsActive,

                   }).ToList();
            String jsonstring = JsonConvert.SerializeObject(lis, Formatting.None, new JsonSerializerSettings

            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
                );
            return Ok(jsonstring);

        }
        public IActionResult Addnewuser(Infrastructure.DTO.UserDTO userDTO)
        {

            try
            {
                EntintyComponent.DBEntities.User obj = new EntintyComponent.DBEntities.User();
                obj.Address = userDTO.Address;
                obj.Email = userDTO.Email;
                obj.FirstName = userDTO.FirstName;
                obj.LastName = userDTO.LastName;
                obj.DateOfBirth = userDTO.DateOfBirth;
                obj.Gender = userDTO.Gender;
                obj.MobileNumber = userDTO.MobileNumber;
                obj.ShiftType = userDTO.ShiftType;
                obj.Salary = userDTO.Salary;
                obj.IsActive = true;
                obj.JobDescriptionId = userDTO.JobDescriptionId;
                obj.JoinDate = userDTO.JoinDate;
                // obj.UserId = userDTO.UserId;
                _userReopsitre.Add(obj);
                return Ok("Success");
            }
            catch (Exception)
            {

                return Ok("Fill");
            }


        }


        public IActionResult UpdateUser(Infrastructure.DTO.UserDTO userDTO)

        {
            try
            {
                EntintyComponent.DBEntities.User obj = new EntintyComponent.DBEntities.User();
                obj = _userReopsitre.Find(x => x.UserId == userDTO.UserId).FirstOrDefault();

                if (obj == null)
                    return NotFound("User not found");

                obj.Address = userDTO.Address;
                obj.Email = userDTO.Email;
                obj.FirstName = userDTO.FirstName;
                obj.LastName = userDTO.LastName;
                obj.DateOfBirth = userDTO.DateOfBirth;
                obj.Gender = userDTO.Gender;
                obj.MobileNumber = userDTO.MobileNumber;
                obj.ShiftType = userDTO.ShiftType;
                obj.Salary = userDTO.Salary;
                obj.IsActive = true;
                obj.JobDescriptionId = userDTO.JobDescriptionId;
                obj.JoinDate = userDTO.JoinDate;

                _userReopsitre.Update(obj);

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest("Update Failed: " + ex.Message);
            }
        }



        public IActionResult GetAllIJobDescription()
        {
            try { 
          
            List<Infrastructure.DTO.JobeDescriptionDTO> lst = new List<Infrastructure.DTO.JobeDescriptionDTO>();

            lst = (from obj in _jobDescriptionReopsitre.GetAll()
                   select new Infrastructure.DTO.JobeDescriptionDTO

                   {
                       Id = obj.JobDescriptionId,
                       Name = obj.Name,
                   }).ToList();
            string jsonstring = JsonConvert.SerializeObject(lst, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(jsonstring);
        }
            catch (Exception ex) {
                return Ok(ex.Message);
            }

        }
        public async Task<IActionResult> Delete(int UserId)
        {
            EntintyComponent.DBEntities.User obj = new EntintyComponent.DBEntities.User();
            obj = _userReopsitre.Find(x => x.UserId == UserId).FirstOrDefault();


            _userReopsitre.Remove(obj);
            return Ok("Sucsses");
        }
        public async Task<IActionResult> GetUserByid(int UserId)
        {
            Infrastructure.DTO.UserDTO user = new Infrastructure.DTO.UserDTO();

            user = (from obj in _userReopsitre.Find(x => x.UserId == UserId)
                    select new Infrastructure.DTO.UserDTO
                    {
                        FirstName = obj.FirstName,
                        LastName = obj.LastName,
                        Email = obj.Email,
                        Address = obj.Address,                        
                        DateOfBirth = obj.DateOfBirth,
                        JoinDate = obj.JoinDate,
                        MobileNumber = obj.MobileNumber,
                        Salary = obj.Salary,
                        Gender = obj.Gender,
                        ShiftType = obj.ShiftType,
                        JobDescriptionId = obj.JobDescriptionId,
                        UserId = obj.UserId,
                    }).FirstOrDefault();
            user.Description = new List<Infrastructure.DTO.JobeDescriptionDTO>();

            user.Description = (from obj in _jobDescriptionReopsitre.GetAll()
                                select new Infrastructure.DTO.JobeDescriptionDTO

                                {
                                    Id = obj.JobDescriptionId,
                                    Name = obj.Name,
                                }).ToList();

            return Ok(user); // ✅ ترجع JSON جاهز

        }
        }

    }

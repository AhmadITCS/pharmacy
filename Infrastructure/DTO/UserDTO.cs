using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Infrastructure.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DateOnly DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public bool Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public bool ShiftType { get; set; }

        public decimal Salary { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DateOnly JoinDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int JobDescriptionId { get; set; }

        // خصائص للعرض فقط (مش مطلوبة أثناء التعديل أو الإرسال من الـ UI)

       
        public string GenderDisplayName { get; set; }

    
        public string shifttypeName { get; set; }

        
        public string JobDiscrptionName { get; set; }

        public bool IsActive { get; set; }
        public List<JobeDescriptionDTO> Description { get; set; }
    }
}


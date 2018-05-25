
namespace MVCRegLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please Provide a Name", AllowEmptyStrings = false)]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please provide a Email.", AllowEmptyStrings = false)]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage = "Please provide valid email address")]
        public string EmailID { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage ="Please Provide Username", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Provide password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 8 char long")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password does not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string LoginErrorMessage { get; set; }

    }
}

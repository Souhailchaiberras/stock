using System.ComponentModel.DataAnnotations;

namespace API2.Dtos.Account
{
    public class loginDto
    {
        [Required]
        
        public string UserName { get; set; }
        [Required] 

        public string Password { get; set; }
    }
}

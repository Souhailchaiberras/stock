using System.ComponentModel.DataAnnotations;

namespace API2.Dtos.Account
{
    public class NewUserDto
    {
        
        public String Email { get; set; }
        public String UserName { get; set; }
        public String Token { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.DTOs.User
{
    public class UserDto
    {
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string? Name { get; set; } = String.Empty;
        public string? Email { get; set; } = string.Empty;
    }
}

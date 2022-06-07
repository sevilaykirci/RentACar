using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Entities.DTOs
{
    public class LoginDto : IDTo
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

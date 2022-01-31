using System;

namespace API.DTOs
{
    public class MemberDTO
    {
        public int Id { get; set; }
        
        public string Username { get ; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set;}
        public string Introduction { get; set; }
        public string City { get; set;}
        public string KnownAs { get; set;}
    }
}
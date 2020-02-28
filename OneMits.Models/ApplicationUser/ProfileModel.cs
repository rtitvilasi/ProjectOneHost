using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.ApplicationUser
{
    public class ProfileModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int UserRating { get; set; }
        public string ProfileImageUrl { get; set; }
        public string EnrollmentNumber  { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime MemberSince { get; set; }
        public bool IsActive { get; set; }

        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }
    }
}


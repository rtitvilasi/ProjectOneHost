using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneMits.Data.Models
{
    public class OtpTable
    {
        [Key]
        public string EnrollmentNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NDL_2023.Server.Data.Tables
{
    [Table("user")]
    public class User
    {
        public Guid id { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public double score { get; set; }
    }
}

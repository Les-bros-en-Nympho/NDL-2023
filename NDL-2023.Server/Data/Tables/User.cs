using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NDL_2023.Server.Data.Tables
{
    [Table("user")]
    public class User
    {
        public Guid id { get; set; }
        
        [EmailAddress]
        [JsonIgnore]
        public string email { get; set; }

        [JsonIgnore]
        public string password { get; set; }

        public string username { get; set; }

        public double score { get; set; }
    }
}

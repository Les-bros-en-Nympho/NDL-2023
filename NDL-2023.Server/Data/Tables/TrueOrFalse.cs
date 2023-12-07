using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NDL_2023.Server.Data.Tables
{
    [Table("true_or_false")]
    public class TrueOrFalse
    {
        public Guid id { get; set; }
        public string statement { get; set; }
        public string additional_explanation { get; set; }
        public bool true_or_false { get; set; }
        public int difficulty { get; set; }
    }
}

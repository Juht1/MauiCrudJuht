using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MauiCrudJuht
{

    [Table("customer")]
    public class Customer
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
    }
}

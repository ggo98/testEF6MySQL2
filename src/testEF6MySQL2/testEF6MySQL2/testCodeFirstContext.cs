using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testEF6MySQL2
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class testCodeFirstContext : DbContext
    {
        public DbSet<salesman> salesman { get; set; }
        public DbSet<sales> sales { get; set; }

        public testCodeFirstContext()
          : base()
        {

        }

        public testCodeFirstContext(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }
    }

    [Table("salesman")]
    public class salesman
    {
        [Key]
        public int sal { get; set; }

        public string salname { get; set; }
        public string mail { get; set; }
        public string area { get; set; }
    }

    [Table("sales")]
    public class sales
    {
        [Key]
        [StringLength(5)]
        public string no { get; set; }

        public int cust { get; set; }

        [ForeignKey("salesman")]
        public int sal { get; set; }

        public DateTime? date { get; set; }

        public decimal datenum { get; set; }

        public double total { get; set; }

        public virtual salesman salesman { get; set; }
    }
}
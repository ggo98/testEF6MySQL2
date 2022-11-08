using DsnPlus.Core.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testEF6MySQL2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=testCodeFirst;uid=root;password=admin"))
                {
                    conn.Open();

                    using (var ctx = new testCodeFirstContext(conn, false))
                    {
                        var query = (from data in ctx.sales
                                     select data).ToList();
                        var firstSalesman = query.First().salesman;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetMessage());
            }
        }
    }
}
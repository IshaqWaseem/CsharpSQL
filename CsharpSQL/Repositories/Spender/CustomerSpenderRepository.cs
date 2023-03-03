using CsharpSQL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSQL.Repositories.Spender
{
    public class CustomerSpenderRepository : ICustomerSpenderRepository
    {
        public List<CustomerSpender> GetHighestspenders()
        {
            List<CustomerSpender> SpenderList = new List<CustomerSpender>();
            string sql = "select TOP(10) Customer.FirstName, Invoice.Total FROM Invoice INNER JOIN Customer ON Invoice.CustomerId=Customer.CustomerId ORDER BY Invoice.Total DESC;";
            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                CustomerSpender temp = new CustomerSpender();
                                temp.FirstName = reader.GetString(0);
                                temp.total = reader.GetDecimal(1);
                                SpenderList.Add(temp);
                            }
                        }
                    }



                }
            }
            catch (SqlException ex)
            {
                // Log error
            }
            return SpenderList;
        }
    }
}

using CsharpSQL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSQL.Repositories.Country
{
    public class CountryRepository : ICountryRepository
    {
        public List<CustomerCountry> SortAllCountries()
        {
            List<CustomerCountry> CountryList = new List<CustomerCountry>();
            string sql = "SELECT Country, COUNT(Country) AS 'Count' FROM Customer GROUP BY Country ORDER BY COUNT(Country)DESC;";
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
                                CustomerCountry temp = new CustomerCountry();
                                temp.Country = reader.GetString(0);
                                temp.Count = reader.GetInt32(1);
                                CountryList.Add(temp);
                            }
                        }
                    }



                }
            }
            catch (SqlException ex)
            {
                // Log error
            }
            return CountryList;
        }
    }
}

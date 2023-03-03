using Azure;
using CsharpSQL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSQL.Repositories.CustoRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> CustomerList = new List<Customer>();
            string sql = "SELECT  CustomerId,  FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE PostalCode IS NOT NULL AND Phone IS NOT NULL;";
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
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                CustomerList.Add(temp);
                            }
                        }
                    }



                }
            }
            catch (SqlException ex)
            {
                // Log error
            }
            return CustomerList;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT  CustomerId,  FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" + " WHERE CustomerId = @CustomerId";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = reader.GetString(4);
                                customer.Phone = reader.GetString(5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }



                }
            }
            catch (SqlException ex) { }
            return customer;
        }
        public Customer GetCustomerByName(string name)
        {
            Customer customer = new Customer();
            string sql = "SELECT  CustomerId,  FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" + " WHERE FirstName LIKE @CustomerName";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", "%" + name + "%");
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = reader.GetString(4);
                                customer.Phone = reader.GetString(5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }



                }
            }
            catch (SqlException ex) { }

            return customer;
        }
        public List<Customer> GetCustomerByIndex(int limit, int offset)
        {
            List<Customer> CustomerList = new List<Customer>();
            string sql = "SELECT  CustomerId,  FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" + " ORDER BY CustomerId OFFSET @LimitInt ROWS FETCH NEXT @OffsetInt ROWS ONLY";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@LimitInt", limit);
                        cmd.Parameters.AddWithValue("@OffsetInt", offset);
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                CustomerList.Add(temp);
                            }
                        }
                    }



                }
            }
            catch (SqlException ex) { }

            return CustomerList;
        }
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email)"
            + " VALUES(@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;


                    }

                }
            }
            catch (SqlException ex) { }
            return success;
        }





        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer SET FirstName= @Name WHERE CustomerId=@Id";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@Name", customer.FirstName);
                        cmd.Parameters.AddWithValue("@Id", customer.CustomerId);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;


                    }

                }
            }
            catch (SqlException ex) { }
            return success;
        }
    }
}

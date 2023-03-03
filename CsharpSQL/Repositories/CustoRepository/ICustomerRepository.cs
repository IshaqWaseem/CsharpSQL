using CsharpSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSQL.Repositories.CustoRepository
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerById(int id);
        public Customer GetCustomerByName(string name);
        public List<Customer> GetCustomerByIndex(int limit, int offset);
        public List<Customer> GetAllCustomers();
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);

    }
}

using CsharpSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSQL.Repositories.Spender
{
    public interface ICustomerSpenderRepository
    {
        public List<CustomerSpender> GetHighestspenders();
    }
}

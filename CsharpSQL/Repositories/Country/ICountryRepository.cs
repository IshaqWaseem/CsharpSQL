using CsharpSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSQL.Repositories.Country
{
    public interface ICountryRepository
    {
        public List<CustomerCountry> SortAllCountries();
    }
}

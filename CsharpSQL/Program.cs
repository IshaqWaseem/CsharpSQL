using CsharpSQL.Models;
using CsharpSQL.Repositories.Country;
using CsharpSQL.Repositories.CustoRepository;
using CsharpSQL.Repositories.Spender;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        ICustomerRepository repository= new CustomerRepository();
        ICountryRepository CountryRepo = new CountryRepository();
        ICustomerSpenderRepository spenderRepository = new CustomerSpenderRepository();
        //TestSelectAll(repository);
        //TestSelect(repository);
        //TestSelectName(repository);
        //TestSelectIndex(repository);
        //TestInsert(repository);
        //TestUpdate(repository);
        //TestCountry(CountryRepo);
        TestSpender(spenderRepository);

    }
    static void TestSelectAll(ICustomerRepository repository)
    {
        
        PrintCustomers(repository.GetAllCustomers());
    }
    static void TestSelect(ICustomerRepository repository)
    {
        PrintCustomer(repository.GetCustomerById(1));
    }
    static void TestSelectName(ICustomerRepository repository)
    {
        PrintCustomer(repository.GetCustomerByName("b"));
    }
    static void TestSelectIndex(ICustomerRepository repository)
    {
        PrintCustomers(repository.GetCustomerByIndex(5,10));
    }
    static void TestInsert(ICustomerRepository repository) {
        Customer test = new Customer()
        {
            FirstName = "Noroff",
            LastName = "Dewald",
            Country = "USA",
            Phone = "+45 50505050",
            PostalCode= "12345",
            Email = "fakemail@fake.com"
        };
        if (repository.AddNewCustomer(test))
        {
            Console.WriteLine("yay");
        }
        else { Console.WriteLine("boo"); };
    }
    static void TestUpdate(ICustomerRepository repository)
    {
        Customer test = new Customer()
        {
            FirstName = "Luis",
            CustomerId= 1
        };
        if (repository.UpdateCustomer(test))
        {
            Console.WriteLine("yay");
        }
        else { Console.WriteLine("boo"); };
    }
    
    static void PrintCustomers(IEnumerable<Customer> customers)
    {
        foreach (Customer customer in customers)
        {  
            PrintCustomer(customer);
        }
    }
    static void PrintCustomer(Customer customer)
    {
        Console.WriteLine($"---{customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.Phone}{customer.PostalCode} {customer.Email} ---");
    }

    static void TestCountry(ICountryRepository country)
    {
        PrintCountries(country.SortAllCountries());

    }
    static void PrintCountries(IEnumerable<CustomerCountry> countries)
    {
        foreach (CustomerCountry country in countries)
        {
            PrintCountry(country);
        }
    }
    static void PrintCountry(CustomerCountry country)
    {
        Console.WriteLine($"---{country.Country} {country.Count} ---");
    }

    static void TestSpender(ICustomerSpenderRepository spenders)
    {
        PrintSpenders(spenders.GetHighestspenders());

    }
    static void PrintSpenders(IEnumerable<CustomerSpender> spenders)
    {
        foreach (CustomerSpender spender in spenders)
        {
            PrintSpender(spender);
        }
    }
    static void PrintSpender(CustomerSpender spender)
    {
        Console.WriteLine($"---{spender.FirstName} {spender.total} ---");
    }
}
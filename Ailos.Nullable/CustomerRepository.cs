using System.Collections.Generic;
using System.Linq;

namespace Ailos.Nullable
{
    public class CustomerRepository
    {
        private readonly ICollection<CustomerViewModel> _customers = new List<CustomerViewModel>
        {
            new() { FirstName = "Diego", LastName = "Alles" },
            new() { FirstName = "Odair", LastName = "Fritz" }
        };

        public CustomerViewModel? FindFirst(string firstName, string lastName, string? middleName = null) 
        {
            if (middleName is null)
            {
                return _customers.FirstOrDefault(x => x.FirstName == firstName&& x.LastName == lastName);
            }

            return _customers.FirstOrDefault(x => x.FirstName == firstName && x.MiddleName == middleName && x.LastName == lastName);
        }

        public ICollection<CustomerViewModel>? GetAll() => _customers;
    }
}

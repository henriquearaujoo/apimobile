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

        public CustomerViewModel? FindFirst(string fullName) => 
            _customers.FirstOrDefault(x => x.FullName == fullName);

        public ICollection<CustomerViewModel>? GetAll() => _customers;
    }
}

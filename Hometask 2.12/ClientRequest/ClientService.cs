using Hometask_2._7;
using Hometask_2._7.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_2._12.ClientRequest
{
    public class ClientService
    {
        private ScheduleDbContext _context;

        public ClientService(ScheduleDbContext context)
        {
            _context = context;
        }

        public IList<Client> GetClients(ClientRequest req)
        {
            IQueryable<Client> clients = _context.Clients;

            if (req.MaxAge.HasValue)
            {
                clients = clients.Where(x => x.Age < req.MaxAge);
            }

            if (req.NameLength > 0)
            {
                clients = clients.Where(x => x.FullName.Length > 0);
            }
            Console.WriteLine(clients);
            return clients.OrderBy(x => x.Age).Skip(req.PageIndex * req.PageSize).Take(req.PageSize).ToList();

        }
    }
}

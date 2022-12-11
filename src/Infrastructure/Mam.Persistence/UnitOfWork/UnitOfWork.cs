using Mam.Application.Interfaces.IUnitOfWork;
using Mam.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mam.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelDbContext _context;

        public UnitOfWork(HotelDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

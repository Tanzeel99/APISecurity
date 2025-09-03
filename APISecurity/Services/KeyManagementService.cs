using APISecurity.Data;
using APISecurity.Models;
using Microsoft.EntityFrameworkCore;

namespace APISecurity.Services
{
    public class KeyManagementService
    {
        private readonly AppDBContext _context;
        public KeyManagementService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<ClientKeyIV?> GetKeyAndIVAsync(string clientId)
        {
            // Retrieve the ClientKeyIV record matching the provided clientId, case-insensitive.
            return await _context.ClientKeyIVs
                .FirstOrDefaultAsync(c => c.ClientId.ToLower() == clientId.ToLower());
        }
    }
}
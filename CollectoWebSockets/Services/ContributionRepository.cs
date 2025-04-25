using CollectoWebSockets.Context;
using CollectoWebSockets.DTO;
using CollectoWebSockets.Models;

namespace CollectoWebSockets.Services
{
    public class ContributionRepository
    {

        private readonly CollectoContext _context;
        public ContributionRepository(CollectoContext context)
        {
            _context = context;
        }

        public async Task AddContributionAsync(AddContributionDTO newContribution)
        {
            if (newContribution == null)
            {
                throw new ArgumentNullException(nameof(newContribution));
            }

            if (string.IsNullOrWhiteSpace(newContribution.UserName))
            {
                throw new ArgumentException("UserName cannot be null or empty", nameof(newContribution.UserName));
            }

            if (newContribution.Balance <= 0)
            {
                throw new ArgumentException("Balance must be greater than zero", nameof(newContribution.Balance));
            }

            var contribution = new Contribution
            {
                Id = Guid.NewGuid(),
                UserName = newContribution.UserName,
                Balance = newContribution.Balance,
                CreatedAt = DateTime.UtcNow
            };
            await _context.Contributions.AddAsync(contribution);
            await _context.SaveChangesAsync();
        }

    }
}

using api.data.template.Context;
using api.data.template.Repository;
using api.domain.template.Entities;
using api.domain.template.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.data.template.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;
        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }
        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}

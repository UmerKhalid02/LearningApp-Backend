using LearningApp.Data.IRepositories.IAuthenticationRepository;

namespace LearningApp.Data.Repositories.AuthenticationRepository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly EFDataContext _context;

        public AuthenticationRepository(EFDataContext context)
        {
            _context = context;
        }




    }
}

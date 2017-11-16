using System.Linq;
using CryptoHelper;
using JobsCart.DAL;
using JobsCart.Models;

namespace JobsCart.Services
{
    public interface ILoginService
    {
        Customer Authenticate(string username, string password);
    }

    public class LoginService : ILoginService
    {
        private JobsDbContext _context;

        public LoginService(JobsDbContext context)
        {
            _context = context;
        }

        public Customer Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Customers.SingleOrDefault(x => x.UserName == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!Crypto.VerifyHashedPassword(user.PasswordHash, password))
                return null;

            // authentication successful
            return user;
        }
    }

}
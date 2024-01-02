using MachineTestRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MachineTestRestApi.Repository
{
    public class LoginRepository : ILoginRepository
    {


        private readonly Sale_dbContext _dbcontext;

        public LoginRepository(Sale_dbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }




        public TblLogin ValidationUser(string username, string password)
        {
            if (_dbcontext != null)
            {
                TblLogin user = _dbcontext.TblLogin.FirstOrDefault(us => us.Username == username && us.Password == password);
                if (user != null)
                {
                    return user;
                }

            }
            return null;
        }

    }
}

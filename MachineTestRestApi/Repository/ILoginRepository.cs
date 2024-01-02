using MachineTestRestApi.Models;

namespace MachineTestRestApi.Repository
{
    public interface ILoginRepository
    {

        public TblLogin ValidationUser(string username, string password);


    }
}

using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Interfaces
{
    public interface ICountrySearch
    {
        Task<bool> SearchByName(string name);
    }
}
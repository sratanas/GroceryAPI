using System.Threading.Tasks;

namespace GroceryAPI.Repositories
{
    public interface IGroceryRepository
    {
        Task<string> GetAllItems();
    }
}

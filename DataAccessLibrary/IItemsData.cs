using DataAccessLibrary.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IItemsData
    {
        Task<List<ItemModel>> GetItems();
        Task InsertItem(ItemModel item);
    }
}
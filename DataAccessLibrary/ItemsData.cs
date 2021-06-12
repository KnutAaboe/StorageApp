using DataAccessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class ItemsData : IItemsData
    {
        private readonly ISQLDataAccess _db;

        public ItemsData(ISQLDataAccess db)
        {
            _db = db;
        }

        public Task<List<ItemModel>> GetItems()
        {
            string sql = "select * from dbo.Items";

            return _db.LoadData<ItemModel, dynamic>(sql, new { });
        }

        public Task InsertItem(ItemModel item)
        {
            string sql = @"insert into dbo.Items (Id, Name, Amount, Location)
                            values (@Id, @Name, @Amount, @Location);";

            return _db.SaveData(sql, item);
        }
    }
}

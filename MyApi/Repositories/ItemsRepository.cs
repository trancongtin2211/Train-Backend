
using System;
using System.Collections.Generic;
using Train.Models;

namespace Train.Repositories
{
    public partial interface ItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        public void CreateItem(Item item);
        public void UpdateItem(Item item);
        public void DeleteItem(Guid id);
    }
}
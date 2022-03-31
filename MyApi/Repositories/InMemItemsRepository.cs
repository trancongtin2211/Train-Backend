using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Train.Models;

namespace Train.Repositories
{

    public class InMemItemsRepository : ItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "RTX 3050", Price = 5, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "RTX3060TI", Price = 17, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "RTX3070TI", Price = 22, CreatedDate = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(p => p.Id == id).SingleOrDefault();
            //Where truy vấn tìm
            //SingleOrDefault xuất dữ liệu tìm được có hoặc không
        }

        public void CreateItem(Item item)
        {
            items.Add(item);//ADD để thêm
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(e => e.Id == item.Id );//FindIndex tìm một phần tử trong mảng
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(e => e.Id == id );//FindIndex tìm một phần tử trong mảng
            items.RemoveAt(index);//RemoveAt xoá phần tử
        }
    }
}
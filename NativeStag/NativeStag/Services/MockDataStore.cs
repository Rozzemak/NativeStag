using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NativeStag.Models;
using Newtonsoft.Json;

namespace NativeStag.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is a todo description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is a todo description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is a todo description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);
            SavePersistItemsAsync();
            return Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.FirstOrDefault(arg => arg.Id == item.Id);
            items.Remove(oldItem);
            items.Add(item);
            await SavePersistItemsAsync().ConfigureAwait(false);
            return await Task.FromResult(true).ConfigureAwait(false);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.FirstOrDefault(arg => arg.Id == id);
            items.Remove(oldItem);
            await SavePersistItemsAsync().ConfigureAwait(false);
            return await Task.FromResult(true).ConfigureAwait(false);
        }

        public Task<Item> GetItemAsync(string id)
        {
            return Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await LoadPersistItemsAsync().ConfigureAwait(false);
            return await Task.FromResult(items).ConfigureAwait(false);
        }

        public Task<bool> SavePersistItemsAsync()
        {
            App.Current.Properties["PersistentTodos"] = JsonConvert.SerializeObject(items);
            return Task.FromResult<bool>(true);
        }

        public Task<bool> LoadPersistItemsAsync()
        {
            items.Clear();
            var itms = JsonConvert.DeserializeObject<List<Item>>(App.Current.Properties["PersistentTodos"].ToString());
            foreach (var item in itms)
            {
                items.Add(item);
            }
            return Task.FromResult<bool>(true);
        }
    }
}
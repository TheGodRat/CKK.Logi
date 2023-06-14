using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CKK.Logic.Models
{
    public class Store : Entity
    {
        private List<StoreItem> Items = new();
   
        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if(quantity > 0)
            {
                if (FindStoreItemById(prod.Id) != null)
                {
                    FindStoreItemById(prod.Id).Quantity += quantity;
                    return FindStoreItemById(prod.Id);

                }
                else
                {
                    StoreItem storeItem = new StoreItem(prod, quantity);
                    Items.Add(storeItem);
                    return storeItem;
                }
            }
            else
            {
                return null;
            }
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (FindStoreItemById(id) != null)
            {
                if(FindStoreItemById(id).Quantity - quantity <= 0)
                {
                    FindStoreItemById(id).Quantity = 0;
                    return FindStoreItemById(id);
                }
                else
                {
                    FindStoreItemById(id).Quantity -= quantity;
                    return FindStoreItemById(id);
                }
            }
            else
            {
                return null;
            }
            

        }
    
        public StoreItem FindStoreItemById(int id)
        {
            foreach(var item in Items)
            {
                if(item.Product.Id == id)
                {
                    return item;
                }
            }
            return null; 
        }

        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }

    }
}

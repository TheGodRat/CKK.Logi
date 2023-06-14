using System;
using System.Collections.Generic;
using System.Linq;

namespace CKK.Logic.Models
{
    public class Store
    {
        private int _id;
        private string _name;
        private List<StoreItem> Items = new();

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }
   
        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if(quantity > 0)
            {
                if (FindStoreItemById(prod.GetId()) != null)
                {
                    FindStoreItemById(prod.GetId()).SetQuantity(FindStoreItemById(prod.GetId()).GetQuantity() + quantity);
                    return FindStoreItemById(prod.GetId());

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
                if(FindStoreItemById(id).GetQuantity() - quantity <= 0)
                {
                    FindStoreItemById(id).SetQuantity(0);
                    return FindStoreItemById(id);
                }
                else
                {
                    FindStoreItemById(id).SetQuantity(FindStoreItemById(id).GetQuantity() - quantity);
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
                if(item.GetProduct().GetId() == id)
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

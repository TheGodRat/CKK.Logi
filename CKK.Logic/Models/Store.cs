using System;

namespace CKK.Logic.Models
{
    public class Store
    {
        private int _id;
        private string _name;
        private Product _product1;
        private Product _product2;
        private Product _product3;

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
        /*AddStoreItem - add item
         * adds product to next available product - product1,product2,product3
         * if there is no available product it will not add the product
         * if there is an item in spot 2 but not 1 or 3 it should add to 1(the next available spot)
         * 
         * if product 1 is null
         *      product 1 = product
        */
        public void AddStoreItem(Product prod)
        {
            if (_product1 == null)
            {
                _product1 = prod;
            }
            else if (_product2 == null)
            {
                _product2 = prod;
            }
            else if (_product3 == null)
            {
                _product3 = prod;
            }
        }
        /*RemoveStoreItem - remove item
         * Removes product from desired spot
         * if there are no products does nothing 
         * if product is out of range does nothing 
         * it should not shift items up in the list when things are removed
         */
        public void RemoveStoreItem(int productNum)
        {
            if (productNum == 1 && _product1 != null)
            {
                _product1 = null;
            }
            if (productNum == 2 && _product2 != null)
            {
                _product2 = null;
            }
            if (productNum == 3 && _product3 != null)
            {
                _product3 = null;
            }

        }
        /*GetStoreItem - gets item 
         * This method gets the product by it's position(product1,product2,product3)
         * should return correct product
         * if it is an invalid product number return null
         * if there is not an item in the desired spot return nulls
         * 
         * if product number == 1 and product 1 is != null
         *  return product 1
         * else 
         *  return null
         */
        public Product GetStoreItem(int productNum)
        {
            if (productNum == 1 && _product1 != null)
            {
                return _product1;
            }
            else if (productNum == 2 && _product2 != null)
            {
                return _product2;
            }
            else if (productNum == 3 && _product3 != null)
            {
                return _product3;
            }
            else
            {
                return null;
            }
        }
        /*FindStoreItemById - gets from ids
         * This will return the product that has the same id(if there is one)
         * if there are no items with that id then return null
         * if there is more than one item with that id return the first
         * 
         * if id == product1.id
         */
        public Product FindStoreItemById(int id)
        {
            if (id == _product1.GetId())
            {
                return _product1;
            }
            else if (id == _product2.GetId())
            {
                return _product2;
            }
            else if (id == _product3.GetId())
            {
                return _product3;
            }
            else
            {
                return null;
            }
        }
    }
}

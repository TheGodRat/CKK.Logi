using System;
using System.Collections.Generic;
using System.Linq;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer _customer;
        private List<ShoppingCartItem> Products = new();

        public ShoppingCart(Customer cust)
        {
            _customer = cust;
        }

        public int GetCustomerId()
        {
            return _customer.GetId();
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
           if(GetProductById(prod.GetId()) != null && quantity > 0)
            {
                GetProductById(prod.GetId()).SetQuantity(GetProductById(prod.GetId()).GetQuantity() + quantity);
                return GetProductById(prod.GetId());
            }
            else
            {
                if(quantity > 0)
                {
                    
                    return new(prod, quantity);
                }
                else
                {
                    return null;
                }
            }
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);
        }

        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
           if (GetProductById(id) != null)
            {
                if(GetProductById(id).GetQuantity() - quantity < 0)
                {
                    Products.Remove(GetProductById(id));
                    return null;
                }
                else
                {
                    GetProductById(id).SetQuantity(GetProductById(id).GetQuantity() - quantity);
                    return GetProductById(id);
                }
            }
            else
            {
                return null;
            }
        }

        public ShoppingCartItem GetProductById(int id)
        {
            foreach (var cartItem in Products)
            {
                if (cartItem.GetProduct().GetId() == id)
                {
                    return cartItem;
                }
            }
            return null;
        }

        public decimal GetTotal()
        {
            decimal total = 0;

            foreach (ShoppingCartItem cartItem in Products)
            {
                total += cartItem.GetTotal();
            }
            return total;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        public Customer Customer { get; set; }
        public List<ShoppingCartItem> Products { get; set; }
        

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
        }

        public int GetCustomerId()
        {
            return Customer.Id;
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if(quantity > 0)
            {
                if(GetProductById(prod.Id) != null)
                {
                    GetProductById(prod.Id).Quantity += quantity;
                    return GetProductById(prod.Id);
                }
                else
                {
                    ShoppingCartItem shoppingCartItem = new ShoppingCartItem(prod, quantity);
                    Products.Add(shoppingCartItem);
                    return shoppingCartItem;
                }
            }
            else
            {
                return null;
            }
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);
        }

        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (GetProductById(id) != null && quantity > 0)
            {
                if (GetProductById(id).Quantity - quantity <= 0)
                {
                    GetProductById(id).Quantity = 0;
                    Products.Remove(GetProductById(id));
                    ShoppingCartItem shoppingCartItem = new(null, 0);
                    return shoppingCartItem;
                }
                else
                {
                    GetProductById(id).Quantity -= quantity;
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
                if (cartItem.Product.Id == id)
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

using CKK.Logic.Interfaces;
using System;

namespace CKK.Logic.Models
{
    public class ShoppingCartItem : InventoryItem
    {
        public ShoppingCartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal GetTotal()
        {
            return Quantity * Product.Price;
        }
    }
}

using System;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer _customer;
        private ShoppingCartItem _product1;
        private ShoppingCartItem _product2;
        private ShoppingCartItem _product3;

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
            if (quantity < 1)
            {
                return null;
            }
            else if (prod == _product1.GetProduct())
            {
                _product1.SetQuantity(_product1.GetQuantity() + quantity);
                return _product1;
            }
            else if (prod == _product2.GetProduct())
            {
                _product2.SetQuantity(_product2.GetQuantity() + quantity);
                return _product2;
            }
            else if (prod == _product3.GetProduct())
            {
                _product3.SetQuantity(_product3.GetQuantity() + quantity);
                return _product3;
            }
            else if (_product1.GetProduct() == null)
            {
                _product1.SetProduct(prod);
                _product1.SetQuantity(quantity);
                return _product1;
            }
            else if (_product2.GetProduct() == null)
            {
                _product2.SetProduct(prod);
                _product2.SetQuantity(quantity);
                return _product2;
            }
            else if (_product3.GetProduct() == null)
            {
                _product3.SetProduct(prod);
                _product3.SetQuantity(quantity);
                return _product3;
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

        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }
            else if (_product1.GetProduct() == prod)
            {
                _product1.SetQuantity(_product1.GetQuantity() - quantity);
                return _product1;
            }
            else if (_product2.GetProduct() == prod)
            {
                _product2.SetQuantity(_product2.GetQuantity() - quantity);
                return _product2;
            }
            else if (_product3.GetProduct() == prod)
            {
                _product3.SetQuantity(_product3.GetQuantity() - quantity);
                return _product3;
            }
            else
            {
                return null;
            }
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (_product1.GetProduct().GetId() == id)
            {
                return _product1;
            }
            else if (_product2.GetProduct().GetId() == id)
            {
                return _product2;
            }
            else if (_product3.GetProduct().GetId() == id)
            {
                return _product3;
            }
            else
            {
                return null;
            }
        }

        public decimal GetTotal()
        {
            return _product1.GetTotal() + _product2.GetTotal() + _product3.GetTotal();
        }

        public ShoppingCartItem GetProduct(int productNum)
        {
            return null;
        }

    }
}

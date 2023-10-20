using CKK.Logic.Interfaces;
using System;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class Product : Entity
    {
        private decimal price;
        public decimal Price 
        { 
            get { return price; }
            set 
            { 
                if(value > 0)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}

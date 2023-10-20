using CKK.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public abstract class Entity
    {
        private int id;
        private string name;

        public int Id
        {
            get { return id; }
            set
            {
                if(value >= 0)
                {
                    id = value;
                }
                else
                {
                    throw new InvalidIdException("Invalid ID");
                }
            }
        }
        public string Name 
        {
            get { return name; }
            set { name = value; }   
        }
    }
}

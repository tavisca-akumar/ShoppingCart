using System;

namespace AddToCart
{
    [Serializable]
    public class ItemNotFoundInCartException : Exception
    {
        public ItemNotFoundInCartException()
        {
        }

       
    }
}

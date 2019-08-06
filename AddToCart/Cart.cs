using System.Collections.Generic;

namespace AddToCart
{
    public class Cart
    {
        List<CartItem> cart;

        public Cart()
        {
            cart = new List<CartItem>();
        }
        public void AddItem(CartItem cartItem)
        {
            if (cart.Contains(cartItem))
            {
                throw new ItemIsInThecartException();
            }
            cart.Add(cartItem);
        }

        public void RemoveItem(CartItem cartItem)
        {
            if (cart.Contains(cartItem))
            {
                cart.Remove(cartItem);
            }
            else
            {
                throw new ItemNotFoundInCartException();
            }
        }

        public List<CartItem> ShowCartItem()
        {
            return cart;
        }
        public double GetTotalCost()
        {
            double TotalCost = 0;
            foreach(var cartItem in cart)
            {
                TotalCost += cartItem.GetTotalCost();
            }
            return TotalCost;
        }
        
    }
}

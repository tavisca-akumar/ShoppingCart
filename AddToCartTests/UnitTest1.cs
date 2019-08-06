using System;
using Xunit;
using AddToCart;
using System.Collections.Generic;

namespace AddToCartTests
{
    public class UnitTest1
    {
        [Fact]
        public void Cart_total_cost_0_when_cart_empty()
        {
            Cart cart = new Cart();
            double expectedvalue = 0.0;
            Assert.Equal(expectedvalue, cart.GetTotalCost());
        }
        [Fact]
        public void Total_cost_of_cart_functionality_test()
        {
            Product product = new Product("TestItem",150.0);
            int quantity = 2;

            CartItem cartItem = new CartItem(product, quantity);

            Cart cart = new Cart();
            cart.AddItem(cartItem);
            double expectedValue = 300.00;

            Assert.Equal(expectedValue, Math.Round(cart.GetTotalCost(), 2));

        }

        [Fact]
        public void Add_item_to_cart_Test()
        {
            Product product1 = new Product("TestItem", 12.0);
            Product product2 = new Product("TestItem2", 10.0);
            int quantity = 3;

            CartItem cartItem1 = new CartItem(product1, quantity);
            CartItem cartItem2 = new CartItem(product2, quantity);

            Cart cart = new Cart();
            cart.AddItem(cartItem1);
            cart.AddItem(cartItem2);
            List<CartItem> ExpectedCartValue = new List<CartItem>
            {
                cartItem1,
                cartItem2
            };
            Assert.Equal(ExpectedCartValue, cart.ShowCartItem());

        }
        [Fact]
        public void Remove_Item_from_cart_Test()
        {

            Product product1 = new Product("TestItem", 12.0);
            Product product2 = new Product("TestItem2", 10.0);
            int quantity = 3;

            CartItem cartItem1 = new CartItem(product1, quantity);
            CartItem cartItem2 = new CartItem(product2, quantity);

            Cart cart = new Cart();
            cart.AddItem(cartItem1);
            cart.AddItem(cartItem2);
            cart.RemoveItem(cartItem1);
            List<CartItem> ExpectedCartValue = new List<CartItem>
            {
                cartItem2
            };
            Assert.Equal(ExpectedCartValue, cart.ShowCartItem());
        }


        [Fact]
        public void Item_Already_Present_In_Cart_Exception()
        {
            Product product1 = new Product("TestItem", 12.0);
            int quantity = 3;

            CartItem cartItem1 = new CartItem(product1, quantity);

            Cart cart = new Cart();
            cart.AddItem(cartItem1);

            Assert.Throws<ItemIsInThecartException>(() => cart.AddItem(cartItem1));
        }

        [Fact]
        public void Item_Not_Present_In_Cart_Exception()
        {
            Product product1 = new Product("TestItem", 12.0);
            Product product2 = new Product("TestItem2", 10.0);
            int quantity = 3;

            CartItem cartItem1 = new CartItem(product1, quantity);
            CartItem cartItem2 = new CartItem(product2, quantity);

            Cart cart = new Cart();
            cart.AddItem(cartItem1);
            Assert.Throws < ItemNotFoundInCartException>(() => cart.RemoveItem(cartItem2));
        }
    }
}

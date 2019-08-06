namespace AddToCart
{
    public class CartItem
    {
        public Product Item { get; private set; }
        public double Quantity { get; private set; }
       

        public CartItem(Product product, int quantity)
        {
            Item = new Product(product.Name, product.Cost);
            this.Quantity = quantity;
        }
        public double GetTotalCost()
        {
            return Quantity * Item.Cost;
        }


    }
}

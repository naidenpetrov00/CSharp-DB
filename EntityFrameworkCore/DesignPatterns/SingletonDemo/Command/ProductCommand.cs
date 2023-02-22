namespace SingletonDemo.Command
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceAction priceAction;
        private readonly int amout;

        public ProductCommand(Product product, PriceAction priceAction, int amout)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.amout = amout;
        }

        public void Execute()
        {
            if (priceAction == PriceAction.Increase)
            {
                product.IncreasePrice(amout);
            }
            else
            {
                product.DecreasePrice(amout);
            }
        }
    }
}

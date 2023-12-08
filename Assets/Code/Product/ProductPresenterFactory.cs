namespace Code
{
    public sealed class ProductPresenterFactory
    {
        private readonly ProductBuyer _productBuyer;
        private readonly CurrencyStorage _currenStorage;

        public ProductPresenterFactory(ProductBuyer productBuyer, CurrencyStorage currenStorage)
        {
            _productBuyer = productBuyer;
            _currenStorage = currenStorage;
        }

        public IProductPresenter Create(ProductInfo productInfo)
        {
            return new ProductPresenter(productInfo, _productBuyer, _currenStorage);
        }
    }
}

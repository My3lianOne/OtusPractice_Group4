using UnityEngine;
using Zenject;

namespace Code
{
    public sealed class ProductHelper : MonoBehaviour
    {
        [SerializeField] private ProductInfo _productInfo;
        [SerializeField] private ProductPopup _productPopup;
        [SerializeField] private ProductCatalog _productCatalog;
        [SerializeField] private ShopPopup _shopPopup;
        private ProductPresenterFactory _productPresenterFactory;

        [Inject]
        private void Construct(ProductPresenterFactory productPresenterFactory)
        {
            _productPresenterFactory = productPresenterFactory;
        }
        
        public void BuyProduct()
        {
           // _productBuyer.Buy(_productInfo);
        }
        
        public void ShowPopup()
        {
            var productPresenter = _productPresenterFactory.Create(_productInfo);
            _productPopup.Show(productPresenter);
        }
        
        public void ShowShopPopup()
        {
            _shopPopup.Show(new ShopPopupPresenter(_productCatalog, _productPresenterFactory));
        }
    }
}

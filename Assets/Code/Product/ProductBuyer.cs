using UnityEngine;

namespace Code
{
    public sealed class ProductBuyer
    {
        private readonly CurrencyStorage _moneyStorage;

        public ProductBuyer(CurrencyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        public void Buy(ProductInfo product)
        {
            if (CanBuy(product))
            {
                _moneyStorage.Spend(product.MoneyPrice);
                Debug.Log($"<color=green>Product {product.Title} successfully purchased!</color>");
            }
            else
            {
                Debug.LogWarning($"<color=red>Not enough money for product {product.Title}!</color>");
            }
        }

        public bool CanBuy(ProductInfo product)
        {
            return _moneyStorage.Currency.Value >= product.MoneyPrice;
        }
    }
}

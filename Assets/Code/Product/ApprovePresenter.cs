using System;
using UniRx;
using UnityEngine;

namespace Code
{
    public class ApprovePresenter : IApprovePresenter
    {
        public event Action<bool> OnActiveChanged; 
        private readonly ProductBuyer _productBuyer;
        private ProductInfo _productInfo;
        public ApprovePresenter(ProductInfo productInfo)
        {
            Title = $"Списать {productInfo.MoneyPrice} гемов?";
            Price = productInfo.MoneyPrice.ToString();
        }
        public string Title { get; }
        public Sprite Icon { get; }
        public string Price { get; }
        public IReadOnlyReactiveProperty<bool> CanBuy { get; }
        public ReactiveCommand BuyCommand { get; }

        public ApprovePresenter(ProductBuyer productBuyer)
        {
            _productBuyer = productBuyer;
        }

        public void Show()
        {
            OnActiveChanged?.Invoke(true);
        }

        public void Hide()
        {
            OnActiveChanged?.Invoke(false);
        }

        public void Buy()
        {
            _productBuyer.Buy(_productInfo);
        }

        public void Cancel()
        {
            Hide();
        }
    }
}
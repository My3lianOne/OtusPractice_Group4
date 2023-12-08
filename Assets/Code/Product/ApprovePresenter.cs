using UniRx;
using UnityEngine;

namespace Code
{
    internal class ApprovePresenter : IApprovePresenter
    {
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
        public void Buy()
        {
            throw new System.NotImplementedException();
        }

        public void Cancel()
        {
            throw new System.NotImplementedException();
        }
    }
}
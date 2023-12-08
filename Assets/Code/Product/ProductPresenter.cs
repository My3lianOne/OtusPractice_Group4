using UnityEngine;
using UniRx;

namespace Code
{
    public sealed class ProductPresenter : IProductPresenter
    {
        private readonly ProductInfo _productInfo;
        private readonly ProductBuyer _productBuyer;
        public string Title { get; }
        public string Description { get; }
        public Sprite Icon { get; }
        public string Price { get; }
        public ReactiveCommand BuyCommand { get; }
        public IReadOnlyReactiveProperty<bool> CanBuy => _canBuy;
        private readonly CompositeDisposable _subscriptions = new ();
        private readonly ReactiveProperty<bool> _canBuy = new ();
        private IApprovePresenter _approvePresenter;
        public ProductPresenter(ProductInfo productInfo, ProductBuyer productBuyer, CurrencyStorage moneyStorage)
        {
            _productInfo = productInfo;
            _productBuyer = productBuyer;
            Title = _productInfo.Title;
            Description = _productInfo.Description;
            Icon = _productInfo.Icon;
            Price = _productInfo.MoneyPrice.ToString();
            moneyStorage.Currency.Subscribe(OnMoneyChange).AddTo(_subscriptions);
            BuyCommand = new ReactiveCommand(CanBuy);
            BuyCommand.Subscribe(OnBuyCommand).AddTo(_subscriptions);
        }

        private void OnBuyCommand(Unit _)
        {
            // заменить на BuyApprove
            // создаем презентер попапа подтверждения
            _approvePresenter = new ApprovePresenter(_productInfo);
            
            // Buy();
        }

        private void OnMoneyChange(long money)
        {
            _canBuy.Value = _productBuyer.CanBuy(_productInfo);
        }

        public void Buy()
        {
            
            _productBuyer.Buy(_productInfo);
        }
        
        ~ProductPresenter()
        {
            _subscriptions.Dispose();
        }
    }
}

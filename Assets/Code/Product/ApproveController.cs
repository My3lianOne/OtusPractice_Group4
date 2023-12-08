using System;
using Zenject;

namespace Code
{
    public class ApproveController : IInitializable, IDisposable
    {
        private readonly ProductPresenter _productPresenter;
        private readonly ApprovePresenter _approvePresenter;

        public ApproveController(ProductPresenter productPresenter, ApprovePresenter approvePresenter)
        {
            _productPresenter = productPresenter;
            _approvePresenter = approvePresenter;
        }


        public void Initialize()
        {
            _productPresenter.OnBuyRequested += BuyRequest;
        }

        public void Dispose()
        {
            _productPresenter.OnBuyRequested -= BuyRequest;
        }

        private void BuyRequest()
        {
            _approvePresenter.Show();
        }
    }
}
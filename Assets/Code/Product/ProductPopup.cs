using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public sealed class ProductPopup : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _title;

        [SerializeField]
        private TextMeshProUGUI _description;

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private BuyButton _buyButton;
        
        [SerializeField] private Button _closeButton;
        private IProductPresenter _productPresenter;
        private CompositeDisposable _disposable = new ();

        public void Show(IPresenter args)
        {
            if (args is not IProductPresenter productPresenter)
            {
                throw new Exception("Expected IProductPresenter");
            }
            _disposable = new CompositeDisposable();
            gameObject.SetActive(true);
            _productPresenter = productPresenter;
            _title.text = _productPresenter.Title;
            _description.text = _productPresenter.Description;
            _icon.sprite = _productPresenter.Icon;
            
            _buyButton.SetPrice(_productPresenter.Price);
            _productPresenter.BuyCommand.BindTo(_buyButton.Button).AddTo(_disposable);
            _closeButton.onClick.AddListener(Hide);
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            var buttonState = _productPresenter.CanBuy.Value
                ? BuyButtonState.Available
                : BuyButtonState.Locked;
            _buyButton.SetState(buttonState);
        }

        private void Hide()
        {
            gameObject.SetActive(false); 
            _closeButton.onClick.RemoveListener(Hide);
            _disposable.Dispose();
        }
    }
}

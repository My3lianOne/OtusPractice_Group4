using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    public class ApproveView : MonoBehaviour
    {
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _cancelButton;

        [SerializeField] private Text _text;
        [SerializeField] private Image _image;
        
        private ApprovePresenter _approvePresenter;
        
        [Inject]
        private void Construct(ApprovePresenter approvePresenter)
        {
            _approvePresenter = approvePresenter;

            _approvePresenter.OnActiveChanged += OnActiveChange;
            
            _buyButton.onClick.AddListener(Buy);
            _buyButton.onClick.AddListener(Cancel);
        }

        private void Cancel()
        {
            _approvePresenter.Cancel();
        }

        private void Buy()
        {
            _approvePresenter.Buy();
        }

        private void OnDestroy()
        {
            _approvePresenter.OnActiveChanged -= OnActiveChange;
        }

        private void OnActiveChange(bool value)
        {
            if (value)
            {
                _text.text = _approvePresenter.Title;
                _image.sprite = _approvePresenter.Icon;
            }
            
            gameObject.SetActive(value);
        }
    }
}
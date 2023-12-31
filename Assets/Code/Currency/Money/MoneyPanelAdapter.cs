﻿using System;
using DG.Tweening;
using UniRx;

namespace Code
{
    public sealed class MoneyPanelAdapter : IDisposable
    {
        private readonly CurrencyView _currencyView;
        private readonly IDisposable _disposable;

        public MoneyPanelAdapter(CurrencyView currencyView, CurrencyStorage moneyStorage)
        {
            _currencyView = currencyView;
            _disposable = moneyStorage.Currency.SkipLatestValueOnSubscribe().Subscribe(OnMoneyChanged);
            Setter(moneyStorage.Currency.Value);
        }
        
        private long _lastCurrency;
        private Sequence _sequence;

        private void OnMoneyChanged(long money)
        {
            _sequence?.Kill();
            var tweenerCore = DOTween.To(() => _lastCurrency, Setter, money, _currencyView.Duration);
            _sequence = DOTween.Sequence();
            _sequence.Append(_currencyView.AnimateStartText());
            _sequence.Append(tweenerCore);
            _sequence.Append(_currencyView.AnimateEndText());
        }
        
        private void Setter(long value)
        { 
            _currencyView.UpdateCurrency(value.ToString());
            _lastCurrency = value;
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}

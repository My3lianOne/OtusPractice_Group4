using System;
using UniRx;

namespace Code
{
    public sealed class CurrencyStorage
    {
        public IReadOnlyReactiveProperty<long> Currency => _currency;
        private readonly ReactiveProperty<long> _currency;

        public CurrencyStorage(long currency)
        {
            _currency = new ReactiveProperty<long>(currency);
        }
        
        public void Add(long currency)
        {
            _currency.Value += currency;
        }
        
        public void Spend(long money)
        {
            _currency.SetValueAndForceNotify(money);
        }
    }
}

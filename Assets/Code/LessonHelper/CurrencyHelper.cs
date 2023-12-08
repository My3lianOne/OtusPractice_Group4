using UnityEngine;
using Zenject;

namespace Code
{
    public sealed class CurrencyHelper : MonoBehaviour
    {
        [SerializeField] private long _current;
        private CurrencyStorage _moneyStorage;
        private CurrencyStorage _gemStorage;

        [Inject]
        private void Construct(CurrencyStorage moneyStorage, CurrencyStorage gemStorage)
        {
            _gemStorage = gemStorage;
            _moneyStorage = moneyStorage;
        }

        public void AddMoney()
        {
            _moneyStorage.Add(_current);
        }

        public void SpendMoney()
        {
            _moneyStorage.Spend(_current);
        }

        public void AddGem()
        {
            _gemStorage.Add(_current);
        }

        public void SpendGem()
        {
            _gemStorage.Spend(_current);
        }
    }
}

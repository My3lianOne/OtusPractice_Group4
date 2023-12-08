using UniRx;
using UnityEngine;

namespace Code
{
    internal interface IApprovePresenter
    {
        string Title { get; }
        Sprite Icon { get; }
        string Price { get; }
        IReadOnlyReactiveProperty<bool> CanBuy { get; }
        ReactiveCommand BuyCommand { get; }
        void Buy();
        void Cancel();
    }
}
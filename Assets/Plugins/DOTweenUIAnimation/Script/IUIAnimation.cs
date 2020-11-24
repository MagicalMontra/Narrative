using DG.Tweening;

namespace Gamespace.UI
{
    public interface IUIAnimation
    {
        float Duration { get; }
        void On();
        void Off();
        void Reset();
        void OnDestroy();
    }
}
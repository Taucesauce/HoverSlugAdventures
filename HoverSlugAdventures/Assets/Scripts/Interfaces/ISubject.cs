namespace Assets.Scripts.Interfaces
{
    public interface ISubject
    {
        void Attach(IObserver o);
        void Detatch(IObserver o);
        void Notify();
    }
}

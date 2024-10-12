namespace ServerManagement.Stores
{
    public class Observer
    {
        protected event Action _listeners;

        public void AddStateChangeListener(Action listener)
        {
            if (listener != null)
                _listeners += listener;
        }

        public void RemoveStateChangeListener(Action listener)
        {
            if(listener != null)
                _listeners -= listener;
        }

        public void BroadCastStateChange()
        {
            _listeners?.Invoke();
        }
    }
}

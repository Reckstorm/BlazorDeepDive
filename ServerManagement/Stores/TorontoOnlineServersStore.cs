namespace ServerManagement.Stores
{
    public class TorontoOnlineServersStore : Observer
    {
        private int _numServersOnline;

        public int NumServersOnline
        {
            get => _numServersOnline; 
            set 
            { 
                _numServersOnline = value;
                BroadCastStateChange();
            }
        }
    }
}

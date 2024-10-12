namespace ServerManagement.Stores
{
    public class CityStore : Observer
    {
        public string City { get; set; }

        private int _serversOnline;

		public int ServersOnline
		{
			get { return _serversOnline; }
			set 
			{
                _serversOnline = value;
				BroadCastStateChange();
			}
		}

	}
}

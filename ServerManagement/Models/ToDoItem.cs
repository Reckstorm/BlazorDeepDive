namespace ServerManagement.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        private string _body;

        public string Body
        {
            get { return _body; }
            set
            {
                _body = value;
                UpdatedAt = DateTime.UtcNow;
            }
        }


        private bool _isDone;

        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                _isDone = value;
                UpdatedAt = DateTime.UtcNow;
            }
        }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}

namespace ServerManagement.Models
{
    public static class ToDoItemsRepository
    {
        private static List<ToDoItem> _toDoItems { get; set; } =
        [
            new ToDoItem() { Id = 5, Body = "To Do item 5" },
            new ToDoItem() { Id = 4, Body = "To Do item 4" },
            new ToDoItem() { Id = 3, Body = "To Do item 3" },
            new ToDoItem() { Id = 2, Body = "To Do item 2" },
            new ToDoItem() { Id = 1, Body = "To Do item 1" },
        ];

        private static void SortItems()
        {
            _toDoItems.Sort((x, y) => y.Id.CompareTo(x.Id));
        }

        public static List<ToDoItem> GetSortedToDoItems()
        {
            return _toDoItems;
        }

        //public static void UpdateToDoItem(ToDoItem item)
        //{
        //    ToDoItem toDoItem = _toDoItems.FirstOrDefault(i => i.Id == item.Id);
        //    if (toDoItem == null) return;

        //    toDoItem.Body = item.Body;
        //    toDoItem.IsDone = item.IsDone;
        //    toDoItem.UpdatedAt = DateTime.UtcNow;
        //}

        public static void AddToDoItem()
        {
            _toDoItems.Insert(0, new ToDoItem()
            {
                Id = _toDoItems.Max(x => x.Id) + 1,
                Body = $"New Task {_toDoItems.Max(x => x.Id) + 1}"
            });
        }
    }
}

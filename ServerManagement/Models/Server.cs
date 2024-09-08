﻿namespace ServerManagement.Models
{
    public class Server
    {
        public string Name { get; set; }
        public string City { get; set; }
        public bool IsRunning { get; set; }
        public int Id { get; set; }

        public Server()
        {
            Random rand = new Random();
            IsRunning = rand.Next(0,2) == 0? false : true;
        }
    }
}

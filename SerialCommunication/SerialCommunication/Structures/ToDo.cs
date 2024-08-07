﻿

namespace SerialCommunication.Structures
{
    public class Todo
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Completed { get; set; }

        public override string ToString()
        {
            return $"{UserId} {Id} {Title} {Completed}";
        }
    }

}

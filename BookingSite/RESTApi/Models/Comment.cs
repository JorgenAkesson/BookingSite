﻿namespace MvcApplication4.RESTApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string AuthorName { get; set; }
    }
}
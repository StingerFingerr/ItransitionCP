using System;

namespace UserManagement.MVC.Models.Collections
{
    public class CommentModel
    {
        public string Id { get; set; }
        public string CommentText { get; set; }
        public string UserId { get; set; }
        public DateTime CommentDate { get; set; }
    }
}

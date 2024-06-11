﻿

namespace Topic.EntityLayer.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
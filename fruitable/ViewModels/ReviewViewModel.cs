﻿using Fruitable.Data.Models;

namespace Fruitable.ViewModels
{
    public class ReviewViewModel
    {
        public string Id { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public ApplicationUser User { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

﻿namespace Pratik_Survivor.Data
{
    public class Competitor 
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }  // İlişkiyi tanımlar
    }
}

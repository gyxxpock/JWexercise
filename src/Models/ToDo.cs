using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise.Models
{
    public class ToDo
    {
        public ToDo(string ID, string Description, Boolean IsDone)
        {
            this.ID = ID;
            this.Description = Description;
            this.IsDone = IsDone;
        }

        public string ID { get; set; }
        public string Description { get; set; }
        public Boolean IsDone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz_Zone.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] IconData { get; set; }

        public string IconMimeType { get; set; }
    }
}
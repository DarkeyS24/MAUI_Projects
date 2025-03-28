using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Models
{
    public class Component
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Type Page { get; set; }
        public bool ReplaceMainPage { get; set; } = true;
    }
}

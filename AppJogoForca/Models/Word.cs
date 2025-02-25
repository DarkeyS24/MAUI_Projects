using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJogoForca.Models
{
    internal class Word
    {
        public Word(string tips, string text) 
        {
            this.Tips = tips;
            this.Text = text;
        }
        public string Tips { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

    }
}

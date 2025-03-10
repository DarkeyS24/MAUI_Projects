using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMAUIGallery.Views.Lists.Models;

namespace AppMAUIGallery.Views.Lists.Utils
{
    class MovieTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TemplateDefaultMovie { get; set; }
        public DataTemplate TemplateLongMovie { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Movie movie = (Movie)item;
            return (movie.Duration.Hours > 1) ? TemplateLongMovie : TemplateDefaultMovie;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMAUIGallery.Models;
using AppMAUIGallery.Views.Layouts;

namespace AppMAUIGallery.Repositories
{
    internal class CategoryRepository
    {
        public CategoryRepository() { }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category { 
                Name="Layout",
                Components = new List<Component> { new Component { 
                    Name="StackLayout",
                    Description="Organização sequencial dos elementos.",
                    Page = typeof(StackLayoutPage)} }
            });
            return categories; 
        }
    }
}

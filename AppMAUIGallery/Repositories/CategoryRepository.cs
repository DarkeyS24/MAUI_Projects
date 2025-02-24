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
                Components = new List<Component> 
                { 
                     new Component 
                     { 
                        Name="StackLayout",
                        Description="Organização sequencial dos elementos.",
                        Page = typeof(StackLayoutPage)
                     },
                     new Component
                     {
                        Name="Grid",
                        Description="Organiza os elementos dentro de uma tabela.",
                        Page = typeof(GridLayoutPage)
                     },
                     new Component 
                     {
                         Name="AbsoluteLayout",
                         Description="Liberdade total para posicionar e dimensionar os elementos na tela.",
                         Page = typeof(AbsoluteLayoutPage)
                     },
                     new Component
                     {
                         Name="FlexLayout",
                         Description="Organiza os elementos de forma sequencial com muitas opções de personalização",
                         Page = typeof(FlexLayoutPage)
                     }
                }
            });
            return categories; 
        }
    }
}

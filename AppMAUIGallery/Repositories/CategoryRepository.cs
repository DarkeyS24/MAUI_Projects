using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMAUIGallery.Models;
using AppMAUIGallery.Views.Components.Mains;
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
                         Description="Organiza os elementos de forma sequencial com muitas opções de personalização.",
                         Page = typeof(FlexLayoutPage)
                     }
                }
            });
            categories.Add(new Category()
            {
                Name = "Componentes (Views)",
                Components = new List<Component>
                {
                    new Component
                    {
                        Name="BoxView",
                        Description="Um componente que cria uma caixa para ser apresentada.",
                        Page=typeof(BoxViewPage)
                    },
                    new Component
                    {
                        Name="Label",
                        Description="Apresenta um texto na tela.",
                        Page=typeof(LabelPage)
                    },
                    new Component
                    {
                        Name="Button",
                        Description = "Apresenta um botão na tela.",
                        Page=typeof(ButtonPage)
                    }
                }
            });
            return categories; 
        }
    }
}

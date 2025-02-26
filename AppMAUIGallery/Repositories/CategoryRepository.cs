﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMAUIGallery.Models;
using AppMAUIGallery.Views.Components.Mains;
using AppMAUIGallery.Views.Layouts;
using AppMAUIGallery.Views.Visuals;

namespace AppMAUIGallery.Repositories
{
    internal class CategoryRepository
    {
        public CategoryRepository() { }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category
            {
                Name = "Layout",
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
                    },
                    new Component
                    {
                        Name="Image",
                        Description="Apresenta uma imagem na tela.",
                        Page=typeof(ImagePage)
                    },
                    new Component
                    {
                         Name="ImageButton",
                         Description="Apresenta uma imagem com comportamento de botão na tela.",
                         Page=typeof(ImageButtonPage)
                    }
                }
            });
            categories.Add(new Category()
            {
                Name = "Visuais",
                Components = new List<Component>
                {
                    new Component()
                    {
                        Name="Frame",
                        Description="Caixa que envolve outros elementos.",
                        Page=typeof(FramePage)
                    },
                    new Component()
                    {
                        Name="Border",
                        Description="Caixa que envolve outros elementos.",
                        Page=typeof(BorderPage)
                    },
                    new Component()
                    {
                        Name="Shadow",
                        Description="Adiciona uma sombra ao elemento.",
                        Page=typeof(ShadowPage)
                    }
                }
            });

            return categories;
        }
    }
}
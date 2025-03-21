using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMAUIGallery.Models;
using AppMAUIGallery.Views.Animations;
using AppMAUIGallery.Views.Cells;
using AppMAUIGallery.Views.Components.Forms;
using AppMAUIGallery.Views.Components.Mains;
using AppMAUIGallery.Views.Layouts;
using AppMAUIGallery.Views.Lists;
using AppMAUIGallery.Views.Styles;
using AppMAUIGallery.Views.Visuals;

namespace AppMAUIGallery.Repositories
{
    public partial class GroupComponentRepository : IGroupComponentRepository
    {
        private void LoadData()
        {
            _components = new List<Component>();
            _groupComponents = new List<GroupComponent>();

            LoadLayout();
            LoadControls();
            LoadVisuals();
            LoadForms();
            LoadCells();
            LoadCollectionsAndLists();
            LoadStyles();
            LoadAnimations();
        }

        private void LoadLayout()
        {
            var components = new List<Component>
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
                };
            var group = new GroupComponent()
            {
                Name = "Layout"
            };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }
        private void LoadControls()
        {
            var components = new List<Component>
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
                };
            var group = new GroupComponent()
            {
                Name = "Componentes (Views)"
            };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }
        private void LoadVisuals()
        {
            var components = new List<Component>
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
                };
            var group = new GroupComponent()
            {
                Name = "Visuais"
            };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }
        private void LoadForms()
        {
            var components = new List<Component>
                {
                    new Component()
                    {
                        Name="Entry",
                        Description="Cria uma caixa de entrada de texto.",
                        Page=typeof(EntryPage)
                    },
                    new Component()
                    {
                        Name="Editor",
                        Description="Cria uma caixa de entrada de texto de multiplas linhas.",
                        Page=typeof(EditorPage)
                    },
                    new Component()
                    {
                        Name="CheckBox",
                        Description="Cria uma caixa de marcação.",
                        Page=typeof(CheckBoxPage)
                    },
                    new Component()
                    {
                        Name="RadioButton",
                        Description="Cria uma caixa de marcação de escolha única.",
                        Page=typeof(RadioButtonPage)
                    },
                    new Component()
                    {
                        Name="Switch",
                        Description="Caixa de marcação booleana.",
                        Page=typeof(SwitchPage)
                    },
                    new Component()
                    {
                        Name="Stepper",
                        Description="Cria opções para incrementar ou decrementar um número.",
                        Page=typeof(StepperPage)
                    },
                    new Component()
                    {
                        Name="Slider",
                        Description="Cria uma barra para incrementar ou decrementar um número.",
                        Page=typeof(SliderPage)
                    },
                    new Component()
                    {
                        Name="TimePicker",
                        Description="Seleção da hora e do minuto.",
                        Page=typeof(TimePickerPage)
                    },
                    new Component()
                    {
                        Name="DatePicker",
                        Description="Seleção de data.",
                        Page=typeof(DatePickerPage)
                    },
                    new Component()
                    {
                        Name="SearchBar",
                        Description="Campo de entrada de texto para pesquisa.",
                        Page=typeof(SearchBarPage)
                    },
                    new Component()
                    {
                        Name="Picker",
                        Description="Selecionar um item da lista.",
                        Page=typeof(PickerPage)
                    }
                };
            var group = new GroupComponent()
            {
                Name = "Formulários"
            };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }
        private void LoadCells()
        {
            var components = new List<Component>
                {
                    new Component()
                    {
                        Name="TextCell",
                        Description="Apresenta até duas 'labels' onde uma é destinada ao titulo e a outra a descrição.",
                        Page=typeof(TextCellPage)
                    },
                    new Component()
                    {
                        Name="ImageCell",
                        Description="Apresenta uma imagem com até duas 'labels' onde uma é destinada ao titulo e a outra a descrição.",
                        Page=typeof(ImageCellPage)
                    },
                    new Component()
                    {
                        Name="SwitchCell",
                        Description="Apresenta uma label em conjunto com um switch.",
                        Page=typeof(SwitchCellPage)
                    },
                    new Component()
                    {
                        Name="EntryCell",
                        Description="Apresenta uma label em conjunto com um entry.",
                        Page=typeof(EntryCellPage)
                    },
                    new Component()
                    {
                        Name="ViewCell",
                        Description="Permite criar a nossa célula com layout personalizado.",
                        Page=typeof(ViewCellPage)
                    }
                };
            var group = new GroupComponent()
            {
                Name = "Células"
            };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }
        private void LoadCollectionsAndLists()
        {
            var components = new List<Component>
                {
                    new Component()
                    {
                        Name="TableView",
                        Description="Apresenta células em linhas separadas e permite agrupar por seção.",
                        Page = typeof(TableViewPage)
                    },
                    new Component()
                    {
                        Name="Picker",
                        Description="Apresenta uma lista de seleção única.",
                        Page = typeof(PickerListPage)
                    },
                    new Component()
                    {
                        Name="ListView",
                        Description="Apresenta uma lista de items.",
                        Page = typeof(ListViewPage)
                    },
                    new Component()
                    {
                        Name="CollectionView",
                        Description="Apresenta uma lista de items.",
                        Page = typeof(CollectionViewPage)
                    },
                    new Component()
                    {
                        Name="CarouselView",
                        Description="Apresenta uma lista de items horizontais com navegação lateral.",
                        Page = typeof(CarouselViewPage)
                    },
                    new Component()
                    {
                        Name="BindableLayout (Atributo)",
                        Description="Permite que os layouts possam apresentar nossas listas e coleções.",
                        Page = typeof(BindableLayoutPage)
                    },
                    new Component()
                    {
                        Name="DataTemplateSelector (Classe)",
                        Description="Permite que os itens possam ser apresentados com layouts diferentes.",
                        Page = typeof(DataTemplateSelectorPage)
                    }
                };
            var group = new GroupComponent()
            {
                Name = "Listas e Coleções"
            };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }
        private void LoadStyles()
        {
            var components = new List<Component>
                {
                    new Component()
                    {
                        Name="Implicit & Explicit Styles",
                        Description="Explicar como funcionan os estilos.",
                        Page = typeof(ImplicitExplicitStyles)
                    },
                    new Component()
                    {
                        Name="Global Style",
                        Description="Aplica estilo global.",
                        Page = typeof(GlobalStyle)
                    },
                    new Component()
                    {
                        Name="ApplyToDerivedTypes",
                        Description="Aplicar um estilo aos elementos derivados da classe/componente atual.",
                        Page = typeof(ApplyDerivedTypes)
                    },
                    new Component()
                    {
                        Name="Inheritance Style",
                        Description="Como criar estilos derivados de outros.",
                        Page = typeof(InheritanceStyle)
                    },
                    new Component()
                    {
                        Name="Style Class",
                        Description="Cria classes de estilos para serem aplicadas aos componentes.",
                        Page = typeof(StyleClassPage)
                    },
                    new Component()
                    {
                        Name="StaticResource & DinamicResource",
                        Description="Define se o estilo pode ser alterado em tempo real.",
                        Page = typeof(StaticDinamicResource)
                    },
                    new Component()
                    {
                        Name="Theme",
                        Description="Define um tema padrão para o nosso projeto.",
                        Page = typeof(Theme)
                    },
                    new Component()
                    {
                        Name="AppThemeBinding",
                        Description="Adapta o tema ao modo claro/escuro do sistema operacional.",
                        Page = typeof(AppThemeBindingPage)
                    },
                    new Component()
                    {
                        Name="Visual State Manager (VSM)",
                        Description="Personaliza a paresentação de acordo com o estado do componente.",
                        Page = typeof(VisualStateManagerPage)
                    },
                };
            var group = new GroupComponent()
            {
                Name = "Styles"
            };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }
        private void LoadAnimations()
        {
            var components = new List<Component>
                {
                    new Component()
                    {
                        Name="Basic Animation",
                        Description="Animação basica do .NET MAUI.",
                        Page = typeof(BasicAnimation)
                    },
                };
            var group = new GroupComponent()
            {
                Name = "Styles"
            };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }
    }
}

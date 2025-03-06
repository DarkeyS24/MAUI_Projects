using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Views.Lists.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public short LaunchYear { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}, {LaunchYear}";
        }
    }

    public class GroupMovie : List<Movie> 
    {
        public string CompanyName {  get; set; }
    }

    public class MovieList
    {
        public static List<GroupMovie> GetGroupList() 
        {
            var disneyGroup = new GroupMovie() { CompanyName = "Disney" };
            disneyGroup.Add(new Movie()
            {
                Id = 1,
                Name = "Nosferatu",
                Description = "Uma jovem noiva é deixada sob os cuidados de amigos quando seu marido viaja para a Transilvânia para um encontro com o Conde Orlok. Atormentada por visões terríveis e uma crescente sensação de pavor, ela logo encontra uma força maligna que está muito além de sua compreensão.",
                Duration = new TimeSpan(2, 12, 0),
                LaunchYear = 2024
            });
            disneyGroup.Add(new Movie()
            {
                Id = 2,
                Name = "Babygirl",
                Description = "Uma CEO poderosa coloca sua carreira e família em risco quando começa um caso tórrido com seu estagiário muito mais jovem.",
                Duration = new TimeSpan(1, 54, 0),
                LaunchYear = 2024
            });
            disneyGroup.Add(new Movie()
            {
                Id = 3,
                Name = "Estrelas Além do Tempo",
                Description = "No auge da corrida espacial travada entre Estados Unidos e Rússia durante a Guerra Fria, uma equipe de cientistas da NASA, formada exclusivamente por mulheres afro-americanas, provou ser o elemento crucial que faltava na equação para a vitória dos Estados Unidos, liderando uma das maiores operações tecnológicas registradas na história americana e se tornando verdadeiras heroínas da nação.",
                Duration = new TimeSpan(2, 7, 0),
                LaunchYear = 2016
            });

            var paramountGroup = new GroupMovie() { CompanyName = "Paramount" };
            paramountGroup.Add(new Movie()
            {
                Id = 4,
                Name = "Arthur e os Minimoys",
                Description = "O garoto Arthur, de apenas dez anos, quer ajudar sua avó a não perder a casa. Ele sai em busca de um tesouro no mundo de criaturas minúsculas, os Minimoys, e conta com a ajuda de uma princesa.",
                Duration = new TimeSpan(1, 34, 0),
                LaunchYear = 2006
            });
            paramountGroup.Add(new Movie()
            {
                Id = 5,
                Name = "Entre Montanhas",
                Description = "The Gorge é um filme de ação romântica de ficção científica apocalíptica americana de 2025, dirigido por Scott Derrickson e escrito por Zach Dean. É estrelado por Miles Teller, Anya Taylor-Joy e Sigourney Weaver.",
                Duration = new TimeSpan(2, 7, 0),
                LaunchYear = 2025
            });
            paramountGroup.Add(new Movie()
            {
                Id = 6,
                Name = "Heidi",
                Description = "Heidi é uma garota órfã de oito anos de idade, feliz e tagarela, que mora com seu avô nos Alpes Suíços. Ela faz amigos com facilidade e todos sabem que sempre podem contar com sua ajuda.",
                Duration = new TimeSpan(1, 51, 0),
                LaunchYear = 2015
            });
            paramountGroup.Add(new Movie()
            {
                Id = 7,
                Name = "Extermínio",
                Description = "Uma praga transforma a maioria da humanidade em zumbis sedentos de sangue. Um grupo ainda não afetado se prepara para a mais perigosa jornada de suas vidas: tentar chegar a uma fortaleza militar em Manchester.",
                Duration = new TimeSpan(1, 56, 0),
                LaunchYear = 2002
            });

            var universalGroup = new GroupMovie() { CompanyName = "Universal" };
            universalGroup.Add(new Movie()
            {
                Id = 8,
                Name = "Os Deuses Devem Estar Loucos",
                Description = "Uma tribo tem uma vida feliz e tranquila em um remoto deserto da África, mas quando uma garrafa de Coca-Cola cai miraculosamente de um avião a vida da deles se transforma num caos. O líder da tribo, Xi (N!xau), decide devolver o estranho objeto aos deuses para restaurar a paz no local.",
                Duration = new TimeSpan(1, 49, 0),
                LaunchYear = 1980
            });
            universalGroup.Add(new Movie()
            {
                Id = 9,
                Name = "Roman J. Israel, Esq.",
                Description = "Roman Israel é um advogado de defesa idealista que decide mudar de firma após a morte do seu mentor e chefe. Ele passa por uma crise moral ao precisar defender Langston Bailey, um homem acusado de homicídio.",
                Duration = new TimeSpan(2, 9, 0),
                LaunchYear = 2017
            });
            universalGroup.Add(new Movie()
            {
                Id = 10,
                Name = "O Impossível",
                Description = "O casal Maria e Henry está aproveitando as férias de inverno na Tailândia junto com os três filhos pequenos. Mas em uma manhã, um tsunami de proporções devastadoras atinge o local, arrastando tudo o que encontra pela frente. Separados em dois grupos, a mãe e o filho mais velho vão enfrentar situações desesperadoras para se manterem vivos, enquanto, o pai e as duas crianças menores não sabem se os outros dois ainda estão vivos.",
                Duration = new TimeSpan(1, 54, 0),
                LaunchYear = 2012
            });

            List<GroupMovie> list = new List<GroupMovie>() { disneyGroup, paramountGroup, universalGroup};
            return list;
        }
        public static List<Movie> GetList()
        {
            List<Movie> list = new List<Movie>();
            list.Add(new Movie() { 
                Id=1, 
                Name= "Nosferatu", 
                Description= "Uma jovem noiva é deixada sob os cuidados de amigos quando seu marido viaja para a Transilvânia para um encontro com o Conde Orlok. Atormentada por visões terríveis e uma crescente sensação de pavor, ela logo encontra uma força maligna que está muito além de sua compreensão.", 
                Duration= new TimeSpan(2,12,0),
                LaunchYear = 2024 });
            list.Add(new Movie()
            {
                Id = 2,
                Name = "Babygirl",
                Description = "Uma CEO poderosa coloca sua carreira e família em risco quando começa um caso tórrido com seu estagiário muito mais jovem.",
                Duration = new TimeSpan(1, 54, 0),
                LaunchYear = 2024
            });
            list.Add(new Movie()
            {
                Id = 3,
                Name = "Estrelas Além do Tempo",
                Description = "No auge da corrida espacial travada entre Estados Unidos e Rússia durante a Guerra Fria, uma equipe de cientistas da NASA, formada exclusivamente por mulheres afro-americanas, provou ser o elemento crucial que faltava na equação para a vitória dos Estados Unidos, liderando uma das maiores operações tecnológicas registradas na história americana e se tornando verdadeiras heroínas da nação.",
                Duration = new TimeSpan(2, 7, 0),
                LaunchYear = 2016
            });
            list.Add(new Movie()
            {
                Id = 4,
                Name = "Arthur e os Minimoys",
                Description = "O garoto Arthur, de apenas dez anos, quer ajudar sua avó a não perder a casa. Ele sai em busca de um tesouro no mundo de criaturas minúsculas, os Minimoys, e conta com a ajuda de uma princesa.",
                Duration = new TimeSpan(1, 34, 0),
                LaunchYear = 2006
            });
            list.Add(new Movie()
            {
                Id = 5,
                Name = "Entre Montanhas",
                Description = "The Gorge é um filme de ação romântica de ficção científica apocalíptica americana de 2025, dirigido por Scott Derrickson e escrito por Zach Dean. É estrelado por Miles Teller, Anya Taylor-Joy e Sigourney Weaver.",
                Duration = new TimeSpan(2, 7, 0),
                LaunchYear = 2025
            });
            list.Add(new Movie()
            {
                Id = 6,
                Name = "Heidi",
                Description = "Heidi é uma garota órfã de oito anos de idade, feliz e tagarela, que mora com seu avô nos Alpes Suíços. Ela faz amigos com facilidade e todos sabem que sempre podem contar com sua ajuda.",
                Duration = new TimeSpan(1, 51, 0),
                LaunchYear = 2015
            });
            list.Add(new Movie()
            {
                Id = 7,
                Name = "Extermínio",
                Description = "Uma praga transforma a maioria da humanidade em zumbis sedentos de sangue. Um grupo ainda não afetado se prepara para a mais perigosa jornada de suas vidas: tentar chegar a uma fortaleza militar em Manchester.",
                Duration = new TimeSpan(1, 56, 0),
                LaunchYear = 2002
            });
            list.Add(new Movie()
            {
                Id = 8,
                Name = "Os Deuses Devem Estar Loucos",
                Description = "Uma tribo tem uma vida feliz e tranquila em um remoto deserto da África, mas quando uma garrafa de Coca-Cola cai miraculosamente de um avião a vida da deles se transforma num caos. O líder da tribo, Xi (N!xau), decide devolver o estranho objeto aos deuses para restaurar a paz no local.",
                Duration = new TimeSpan(1, 49, 0),
                LaunchYear = 1980
            });
            list.Add(new Movie()
            {
                Id = 9,
                Name = "Roman J. Israel, Esq.",
                Description = "Roman Israel é um advogado de defesa idealista que decide mudar de firma após a morte do seu mentor e chefe. Ele passa por uma crise moral ao precisar defender Langston Bailey, um homem acusado de homicídio.",
                Duration = new TimeSpan(2, 9, 0),
                LaunchYear = 2017
            });
            list.Add(new Movie()
            {
                Id = 10,
                Name = "O Impossível",
                Description = "O casal Maria e Henry está aproveitando as férias de inverno na Tailândia junto com os três filhos pequenos. Mas em uma manhã, um tsunami de proporções devastadoras atinge o local, arrastando tudo o que encontra pela frente. Separados em dois grupos, a mãe e o filho mais velho vão enfrentar situações desesperadoras para se manterem vivos, enquanto, o pai e as duas crianças menores não sabem se os outros dois ainda estão vivos.",
                Duration = new TimeSpan(1, 54, 0),
                LaunchYear = 2012
            });
            return list;
        }
    }
}

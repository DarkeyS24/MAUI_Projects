using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppJogoForca.Models;

namespace AppJogoForca.Repositories
{
    internal class WordRepository
    {
        private List<Word> words;

        public WordRepository() 
        {
            words = new List<Word>();
            words.Add(new Word("Fruta", "ABACATE".ToUpper()));
            words.Add(new Word("Fruta", "ABACAXI".ToUpper()));
            words.Add(new Word("Fruta", "ACEROLA".ToUpper()));
            words.Add(new Word("Fruta", "AMORA".ToUpper()));
            words.Add(new Word("Fruta", "CAJU".ToUpper()));
            words.Add(new Word("Fruta", "CABELUDINHA".ToUpper()));
            words.Add(new Word("Fruta", "CARAMBOLA".ToUpper()));
            words.Add(new Word("Fruta", "CEREJA".ToUpper()));
            words.Add(new Word("Fruta", "COCO".ToUpper()));
            words.Add(new Word("Fruta", "FIGO".ToUpper()));
            words.Add(new Word("Fruta", "GRAVIOLA".ToUpper()));
            words.Add(new Word("Fruta", "JABUTICABA".ToUpper()));
            words.Add(new Word("Fruta", "LARANJA".ToUpper()));
            words.Add(new Word("Fruta", "LIMAO".ToUpper()));
            words.Add(new Word("Fruta", "MANGA".ToUpper()));
            words.Add(new Word("Fruta", "MELANCIA".ToUpper()));
            words.Add(new Word("Fruta", "MORANGO".ToUpper()));
            words.Add(new Word("Fruta", "MUITA".ToUpper()));
            words.Add(new Word("Fruta", "PERA".ToUpper()));
            words.Add(new Word("Fruta", "PAPAYA".ToUpper()));
            words.Add(new Word("Fruta", "GRANADA".ToUpper()));
            words.Add(new Word("Fruta", "LIABOKA".ToUpper()));

            words.Add(new Word("Vegetal", "ALFACE".ToUpper()));
            words.Add(new Word("Vegetal", "BATATA".ToUpper()));
            words.Add(new Word("Vegetal", "BERINJELA".ToUpper()));
            words.Add(new Word("Vegetal", "CENOURA".ToUpper()));
            words.Add(new Word("Vegetal", "COUVE".ToUpper()));
            words.Add(new Word("Vegetal", "ESPINAFRE".ToUpper()));
            words.Add(new Word("Vegetal", "PEIXE".ToUpper()));
            words.Add(new Word("Vegetal", "PIMENTA".ToUpper()));
            words.Add(new Word("Vegetal", "REPOLHO".ToUpper()));
            words.Add(new Word("Vegetal", "TOMATE".ToUpper()));
            words.Add(new Word("Vegetal", "ERVILHA".ToUpper()));

            words.Add(new Word("Tempero", "ALHO".ToUpper()));
            words.Add(new Word("Tempero", "ALCAPARRA".ToUpper()));
            words.Add(new Word("Tempero", "ALECRIM".ToUpper()));
            words.Add(new Word("Tempero", "CANELA".ToUpper()));
            words.Add(new Word("Tempero", "COENTRO".ToUpper()));
            words.Add(new Word("Tempero", "COMINHO".ToUpper()));
            words.Add(new Word("Tempero", "LIMAO".ToUpper()));
            words.Add(new Word("Tempero", "PIMENTA".ToUpper()));
            words.Add(new Word("Tempero", "MOSTARDA".ToUpper()));
            words.Add(new Word("Tempero", "OREGANO".ToUpper()));
            words.Add(new Word("Tempero", "MANJERICAO".ToUpper()));

            words.Add(new Word("Cidade", "SALVADOR".ToUpper()));
            words.Add(new Word("Cidade", "FORTALEZA".ToUpper()));
            words.Add(new Word("Cidade", "CURITIBA".ToUpper()));
            words.Add(new Word("Cidade", "RECIFE".ToUpper()));
            words.Add(new Word("Cidade", "MACEIO".ToUpper()));
            words.Add(new Word("Cidade", "VITORIA".ToUpper()));
            words.Add(new Word("Cidade", "FLORIANOPOLIS".ToUpper()));

            words.Add(new Word("País", "BRASIL".ToUpper()));
            words.Add(new Word("País", "ARGENTINA".ToUpper()));
            words.Add(new Word("País", "EUA".ToUpper()));
            words.Add(new Word("País", "ALEMANHA".ToUpper()));
            words.Add(new Word("País", "ITALIA".ToUpper()));
            words.Add(new Word("País", "ESPANHA".ToUpper()));
            words.Add(new Word("País", "REINO UNIDO".ToUpper()));
            words.Add(new Word("País", "CANADA".ToUpper()));
            words.Add(new Word("País", "MEXICO".ToUpper()));
            words.Add(new Word("País", "JAPAO".ToUpper()));

            words.Add(new Word("Nome", "ANA".ToUpper()));
            words.Add(new Word("Nome", "MARIA".ToUpper()));
            words.Add(new Word("Nome", "PEDRO".ToUpper()));
            words.Add(new Word("Nome", "LUIZ".ToUpper()));
            words.Add(new Word("Nome", "CARLOS".ToUpper()));
            words.Add(new Word("Nome", "PAULO".ToUpper()));
            words.Add(new Word("Nome", "JULIA".ToUpper()));
            words.Add(new Word("Nome", "BEATRIZ".ToUpper()));
            words.Add(new Word("Nome", "GUSTAVO".ToUpper()));
            words.Add(new Word("Nome", "LUCAS".ToUpper()));
            words.Add(new Word("Nome", "MARCOS".ToUpper()));
            words.Add(new Word("Nome", "GABRIEL".ToUpper()));
            words.Add(new Word("Nome", "FERNANDA".ToUpper()));

            words.Add(new Word("País", "INDIA".ToUpper()));
            words.Add(new Word("País", "CHINA".ToUpper()));
            words.Add(new Word("País", "RUSSIA".ToUpper()));
            words.Add(new Word("País", "AUSTRÁLIA".ToUpper()));
            words.Add(new Word("País", "PORTUGAL".ToUpper()));
            words.Add(new Word("País", "SUECIA".ToUpper()));
            words.Add(new Word("País", "NORUEGA".ToUpper()));
            words.Add(new Word("País", "DINAMARCA".ToUpper()));
            words.Add(new Word("País", "FINLANDIA".ToUpper()));
        }

        public Word GetRamdomWord()
        {
            int maxValue = words.Count - 1;
            int minValue = 0;
            Random random = new Random();
            int num = random.Next(minValue, maxValue);
            return words[num];
        }
    }
}

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
            words.Add(new Word("Nome","Maria".ToUpper()));
            words.Add(new Word("Vegetal","Cenoura".ToUpper()));
            words.Add(new Word("Fruta","Abacate".ToUpper()));
            words.Add(new Word("Tempero","Nordestino".ToUpper()));
            words.Add(new Word("Tempero","Baiano".ToUpper()));
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

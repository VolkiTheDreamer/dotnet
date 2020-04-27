using System;
using System.Collections.Generic;
using System.Linq;
using MyUtility;

namespace ELAKİN
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> words = new List<string>(); //içini doldurcaz from datbase
            List<string> words = new List<string> {"ala","coco","deli","kemal","lale","lala","ela","mama","kale" };        
            var requestedLetters= new List<char> { 'a', 'e', 'k', 'l' }; //bunu da input alıcaz from user
            var alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToList<char>();
            var alphabetSmall = from a in alphabet
                                 select Convert.ToChar(a);
            ///Süre skıntı oluyorsa;
            /// recursive olmadan burada harfleri azalatarak göndermeye deneyelim, süre kısalıyor mu?
            ///bir de list yerine dizi deneyelim, süreye bakalım
            var lettersExcluded = alphabetSmall.Except<char>(requestedLetters).ToList<char>();
            //var resultWordList = GetWithAll(requestedLetters, words, lettersExcluded);
            var resultWordList = GetWithPart(requestedLetters, words);
            Ut.DizimsiYazdırToConsole(resultWordList,false);            
            Console.Read();
        }

        private static List<string> GetWithAll(List<char> letters, List<string>  wordsToSearch, List<char> lettersNotIntheList)
        {
            List<string> temp = new List<string>();
            foreach (var item in wordsToSearch)
            {
                foreach (var l in letters)
                {
                    if (item.Contains(l))
                    {
                        continue;
                    }
                    else
                    {
                        goto atla;
                    }
                }
                foreach (var l in lettersNotIntheList)
                {
                    if (item.Contains(l))
                    {
                        goto atla;
                    }
                }
                temp.Add(item);
                atla:;
            }
            return temp;
        }

        private static List<string> GetWithPart(List<char> letters, List<string> wordsToSearch)
        {
            List<string> temp = new List<string>();
            foreach (var item in wordsToSearch)
            {
                for (int i=0; i<item.Length;i++)
                {
                    if (letters.Contains(item[i]))
                    {
                        continue;
                    }
                    else
                    {
                        goto atla;
                    }
                }
                temp.Add(item);
                atla:;
            }
            return temp;
        }

    }
}

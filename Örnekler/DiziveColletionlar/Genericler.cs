using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUtility;

namespace DiziveColletionlar
{
    class Genericler
    {
        //linkedlist
        //LinkedListNode
        public void ListMetods()
        {
            /*
            - The search by index is very fast – we can access with equal speed each of the elements, regardless of the count of elements.
            - The search for an element by value works with as many comparisons as the count of elements (in the worst case), i.e. it is slow.
            - Inserting and removing elements is a slow operation – when we add or remove elements, especially if they are not in the end of the array, we have to shift the rest of the elements and this is a slow operation.
            - When adding a new element, sometimes we have to increase the capacity of the array, which is a slow operation, but it happens seldom and the average speed of insertion to List does not depend on the count of elements, i.e. it works very fast.
            Use List<T> when you don’t expect frequent insertion and deletion of elements, but you expect to add new elements at the end of the list or to access the elements by index.
             */
            List<int> list1 = new List<int>() { 1, 2, 3 };
            List<int> list2 = new List<int>() { 3, 4, 5 };
            list1.AddRange(list2);//list1 artık büyüdü
            Utilities.DiziYazdır(list1, "list1");
            var list3 = list2.Union(list1);//list2 değişmez
            Utilities.DiziYazdır(list3, "list3");//3,4,5,1,2
            var list4 = list2.Intersect(list1);
            Utilities.DiziYazdır(list4, "list4");//3,4,5            
        }

        public void LinkedListMetod()
        {
            /*Its elements contain a certain value and a pointer to the previous and the next element.
            - The append operation is very fast, because the list always knows its last element (tail).
            - Inserting a new element at a random position in the list is very fast (unlike List<T>) if we have a pointer to this position, e.g. if we insert at the list start or at the list end.
            - Searching for elements by index or by value in LinkedList is a slow operation, as we have to scan all elements consecutively by beginning from the start of the list.
            - Removing elements is a slow operation, because it includes searching.

            Using LinkedList<T> is preferable when we have to add / remove elements at both ends of the list and when the access to the elements is consequential.
However, when we have to access the elements by index, then List<T> is a more appropriate choice.
             */
            LinkedList<int> linkli = new LinkedList<int>();

        }

        public void SetsMetod()
        {
            //Sets are collections of unique elements (without any repeating elements inside)
            ISet<int> hashset1 = new HashSet<int>();
            ISet<int> sortedset1 = new SortedSet<int>();

            HashSet<string> aspNetStudents = new HashSet<string>();
            aspNetStudents.Add("S. Jobs");
            aspNetStudents.Add("B. Gates");
            aspNetStudents.Add("M. Dell");

            HashSet<string> silverlightStudents = new HashSet<string>();
            silverlightStudents.Add("M. Zuckerberg");
            silverlightStudents.Add("M. Dell");

            HashSet<string> allStudents = new HashSet<string>();
            allStudents.UnionWith(aspNetStudents);
            allStudents.UnionWith(silverlightStudents);

            HashSet<string> intersectStudents = new HashSet<string>(aspNetStudents);
            intersectStudents.IntersectWith(silverlightStudents);
            Console.WriteLine("ASP.NET students: " + string.Join(", ", aspNetStudents));
            Console.WriteLine("Silverlight students: " + string.Join(", ", silverlightStudents));
            Console.WriteLine("All students: " + string.Join(", ", allStudents));
            Console.WriteLine("Students in both ASP.NET and Silverlight: " +
            string.Join(", ", intersectStudents));
        }

    }

    public class SortedDictionary_WordCounting
    {
        private static readonly string Text = "Bir ben vardır bende benden içeri, bana seni gerek seni. Ben bir sen bir.";
        public static void Ana()
        {
            IDictionary<String, int> wordOccurrenceMap = GetWordOccurrenceMap(Text);
            PrintWordOccurrenceCount(wordOccurrenceMap);
        }
        private static IDictionary<string, int> GetWordOccurrenceMap(string text)
        {
            string[] tokens = text.Split(' ', '.', ',', '-', '?', '!');
            IDictionary<string, int> words = new SortedDictionary<string, int>();
            foreach (string word in tokens)
            {
                if (!string.IsNullOrEmpty(word.Trim()))
                {
                    int count;
                    if (!words.TryGetValue(word, out count))
                    {
                        count = 0;
                    }
                    words[word] = count + 1;
                }
            }
            return words;
        }
        private static void PrintWordOccurrenceCount(IDictionary<string, int> wordOccurenceMap)
        {
            foreach (var wordEntry in wordOccurenceMap)
            {
                Console.WriteLine("Word '{0}' occurs {1} time(s) in the text", wordEntry.Key, wordEntry.Value);
            }
        }
    }

    public class KelimeSayac
    {
        private static string metin = "Bir ben vardır bende benden içeri, bana seni gerek seni. Ben bir sen bir.";

        private static string[] KelimelereBöl(string textToBöl)
        {
            string[] bölünen = textToBöl.Split(new char[] { ' ', '.', ',' });
            return bölünen;
        }

        public static void Ana()
        {
            var mySorted = new SortedDictionary<string, int>();
            string[] parçalanan = KelimelereBöl(metin);

            foreach (string item in parçalanan)
            {
                if (!mySorted.ContainsKey(item.ToLower()))
                {
                    mySorted.Add(item.ToLower(), 1);
                }
                else
                {
                    mySorted[item.ToLower()]++;
                }
            }

            Utilities.DiziYazdır(mySorted, "mySorted");

        }
    }
}

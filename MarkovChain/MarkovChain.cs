using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarkovChain
{
    public class MarkovChain<T>
    {
        public Dictionary<T, List<T>> ItemsAndFollowing;
        private Random Rand;

        public MarkovChain(T[] items) 
        {            
            ItemsAndFollowing = new Dictionary<T, List<T>>();
            Rand = new Random();

            T previousItem = items[0];
            ItemsAndFollowing.Add(previousItem, new List<T>());
            for (int i = 1; i < items.Length; i++)
            {
                if (!ItemsAndFollowing.ContainsKey(items[i]))
                { ItemsAndFollowing.Add(items[i], new List<T>()); }
                ItemsAndFollowing[previousItem].Add(items[i]);

                previousItem = items[i];
            }
        }

        public List<T> GenerateChain(T start, int moveCount)
        {           
            List<T> chain = new();
            T current = start;
            chain.Add(start);

            for (int i = 0; i < moveCount; i++)
            {
                if (ItemsAndFollowing[current].Count <= 0)
                { throw new Exception("No next possilbe state."); }

                int randomIndex = Rand.Next(0, ItemsAndFollowing[current].Count);
                current = ItemsAndFollowing[current][randomIndex];
                chain.Add(current);
            }

            return chain;
        }
        public List<T> GenerateChain(T start, T end)
        {
            List<T> chain = new();
            T current = start;
            chain.Add(start);

            while (!current.Equals(end))
            {
                if (ItemsAndFollowing[current].Count <= 0)
                { throw new Exception("No next possilbe state."); }

                int randomIndex = Rand.Next(0, ItemsAndFollowing[current].Count);
                current = ItemsAndFollowing[current][randomIndex];
                chain.Add(current);
            }

            return chain;
        }

        public List<T>? MarkovDecisionProcess()
        {
            return default;
        }
    }
}
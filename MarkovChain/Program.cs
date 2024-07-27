using System.Drawing;

namespace MarkovChain
{
    internal class Program
    {
        
        static string GenerateSentence(MarkovChain<string> markovChain, string startingWord, int wordCount)
        {
            List<string> sentenceChain = markovChain.GenerateChain(startingWord, wordCount);
            string sentence = "";

            for (int i = 0; i < sentenceChain.Count; i++)
            { sentence += sentenceChain[i] + ' '; }
            return sentence;
        }
        static string GenerateSentence(MarkovChain<string> markovChain, string startingWord, string endingWord)
        {
            List<string> sentenceChain = markovChain.GenerateChain(startingWord, endingWord);
            string sentence = "";

            for (int i = 0; i < sentenceChain.Count; i++)
            { sentence += sentenceChain[i] + ' '; }
            return sentence;
        }
        static MarkovChain<string> CreateStringMarkovChain(string fileName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fullFilePath = Path.Combine(documentsPath, fileName + ".txt");
            string text = File.ReadAllText(fullFilePath);

            string[] words = text.Split([' ', '\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

            return new MarkovChain<string>(words);
        }

        static void PrintBoard(Tile agent)
        {
            Console.WriteLine("--------");
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 4; row++)
                {
                    Point currentPoint = new Point(row, column);

                    if (currentPoint == agent.Location)
                    { Console.Write("+"); }
                    else if (currentPoint == new Point(1, 1))
                    { Console.Write("X"); }
                    else if (currentPoint == new Point(3, 0))
                    { Console.Write("$"); }
                    else if (currentPoint == new Point(3, 1))
                    { Console.Write("@"); }
                    else
                    { Console.Write(" "); }
                    Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine("--------");
            }
            Console.WriteLine(); Console.WriteLine();
        }

        static void Main(string[] args)
        {
            /* // string chain testing
            var markov = CreateStringMarkovChain("perksOfBeingAWallflowerPageOne");
            string sentence = GenerateSentence(markov, "August", "me.\"");
            Console.WriteLine(sentence); */


            Tile t1A = new Tile(new Point(0, 0), "empty");
            Tile t2A = new Tile(new Point(0, 1), "empty");
            Tile t3A = new Tile(new Point(0, 2), "empty");
                 
            Tile t1B = new Tile(new Point(1, 0), "empty");
            Tile t2B = new Tile(new Point(1, 1), "wall");
            Tile t3B = new Tile(new Point(1, 2), "empty");
                 
            Tile t1C = new Tile(new Point(2, 0), "empty");
            Tile t2C = new Tile(new Point(2, 1), "empty");
            Tile t3C = new Tile(new Point(2, 2), "empty");
                 
            Tile t1D = new Tile(new Point(3, 0), "goal");
            Tile t2D = new Tile(new Point(3, 1), "fire");
            Tile t3D = new Tile(new Point(3, 2), "empty");

            Tile[] tiles = [
               //t2A, t2B, t2A,
                t1A, t1B, t1A,
                 t2A, t1A, t2A, t1A, t2A, t1A, t2A,
                t3A, t3B, t3A,
                 t2A, t3A, t2A, t3A, t2A, t3A, t2A, t1A,

               //t2B, t2C, t2B, 
                t1B, t1C, //t1B,
                 //t2B, t1B, t2B, t1B, t2B, t1B, t2B, 
                t2C, t3C, t3B, t3C,
                 //t2B, t3B, t2B, t3B, t2B, t3B, t2B,

               t2C, t2D, t2C,
                t1C, t1D, t1C,
                 t2C, t1C, t2C, t1C, t2C, t1C, t2C,
                t3C, t3D, t3C,
                 t2C, t3C, t2C, t3C, t2C, t3C, t2C,

               t2D,
                t2D, t1D, t2D, t1D, t2D, t1D, t2D,
                t3D, t2D, t3D, t2D, t3D, t2D, t3D, t2D, t2C

                //t1A, t1B, t1A, 
                //t2A, t1A, t2A, 
                //t2B, t2A,
                //t3A, t3B, t3A
            ];

            //change markov constructor generation to work like a graph, connecting points to nearby points, instead of connecting to new 

            MarkovChain<Tile> markovChain = new MarkovChain<Tile>(tiles);

            List<Tile> path = markovChain.GenerateChain(t1A, t1D);

            for (int i = 0; i < path.Count; i++)
            {
                PrintBoard(path[i]);
                Console.ReadKey();
            }
        }
    }
}
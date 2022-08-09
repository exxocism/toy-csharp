using System;
using System.Linq;
using System.Threading;

namespace Checkpoint01
{
    class Program
    {
        const string LINE = "----------------------------------------------------";
        const int FINISH_LINE = 50;
        const int KEEP_RUNNING = -1;
        static void Main(string[] args)
        {

            string[] runners = new string[] { "우", "마", "무", "스", "메" };
            int[] pos = Enumerable.Repeat(0, runners.Length).ToArray();
            int winner = KEEP_RUNNING;

            while (true)
            {
                winner = runEachTime(pos);
                displayResult(runners, pos);
                if (winner != KEEP_RUNNING) break;
                Thread.Sleep(1000);
            }
            Console.WriteLine("승리자는 : {0}", runners[winner]);
        }

        static void displayResult(string[] runners, int[] pos)
        {
            Console.Clear();
            Console.WriteLine(LINE);
            foreach (var current in pos.Select((pos, runnerIndex) => new { pos, runnerIndex }))
            {
                Console.WriteLine("{0}{1}", new string(' ', current.pos), runners[current.runnerIndex]);
            }
            Console.WriteLine(LINE);
        }

        static int runEachTime(int[] pos)
        {
            Random ramdomRun = new Random();
            for (int i = 0; i < pos.Length; i++)
            {
                int ranNum = ramdomRun.Next(1, 3);
                pos[i] += ranNum;
                if (pos[i] >= FINISH_LINE)
                {
                    pos[i] = FINISH_LINE;
                    return i;
                }
            }
            return KEEP_RUNNING;
        }
    }
}
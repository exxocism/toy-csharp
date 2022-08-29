using System;
using System.Linq;
using System.Threading;

namespace Checkpoint01
{
    class Program
    {
        enum GradeInfo
        {
            ID,
            Kor,
            Math,
            Eng,
        }
        const int MAX_STUDENTS = 3;
        const int BREAK_CODE = -1;
        static void Main(string[] args)
        {
            int count = (int)Enum.GetValues(typeof(GradeInfo)).Cast<GradeInfo>().Last();
            int[][] gradeStorage = new int[count + 1][];
            for (int i = 0; i < gradeStorage.GetLength(0); i++)
            {
                gradeStorage[i] = new int[MAX_STUDENTS];
            }
            for (int i = 0; i < MAX_STUDENTS; i++)
            {
                InputID(gradeStorage[(int)GradeInfo.ID], i);
                InputKor(gradeStorage[(int)GradeInfo.Kor], i);
                InputMath(gradeStorage[(int)GradeInfo.Math], i);
                InputEng(gradeStorage[(int)GradeInfo.Eng], i);
            }

            while (true)
            {
                PrintID(MAX_STUDENTS, gradeStorage[(int)GradeInfo.ID]);
                int studentID = checkID(0, MAX_STUDENTS, gradeStorage[(int)GradeInfo.ID]);
                if (studentID == BREAK_CODE) break;
                Console.WriteLine($"국어 점수 : {gradeStorage[(int)GradeInfo.Kor][studentID]}");
                Console.WriteLine($"수학 점수 : {gradeStorage[(int)GradeInfo.Math][studentID]}");
                Console.WriteLine($"영어 점수 : {gradeStorage[(int)GradeInfo.Eng][studentID]}");
                int gradeSum = gradeStorage[(int)GradeInfo.Kor][studentID] + gradeStorage[(int)GradeInfo.Math][studentID] + gradeStorage[(int)GradeInfo.Eng][studentID];
                Console.WriteLine($"총점 : {gradeSum}");
                Console.WriteLine($"평균 : {(float)gradeSum / (float)count}");
            }

        }

        static void InputID(int[] ID, int index)
        {
            Console.Write("학생 ID를 입력하세요? ");
            ID[index] = int.Parse(Console.ReadLine());
        }

        static void InputKor(int[] Kor, int index)
        {
            Console.Write("국어 점수를 입력하세요? ");
            Kor[index] = int.Parse(Console.ReadLine());
        }

        static void InputEng(int[] Eng, int index)
        {
            Console.Write("영어 점수를 입력하세요? ");
            Eng[index] = int.Parse(Console.ReadLine());
        }

        static void InputMath(int[] Math, int index)
        {
            Console.Write("수학 점수를 입력하세요? ");
            Math[index] = int.Parse(Console.ReadLine());
        }

        static void PrintID(int max, int[] ID)
        {
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine($"학생 ID: {ID[i]}");
            }
        }

        static int checkID(int id, int max, int[] ID)
        {
            while (true)
            {
                Console.Write("학생 ID를 입력하세요? (0) 나가기 ");
                int studentID = int.Parse(Console.ReadLine());
                if (studentID == 0) return BREAK_CODE;
                for (int i = 0; i < max; i++)
                {
                    if (studentID == ID[i]) return i;
                }
                Console.WriteLine("학생 아이디가 없어요. 다시 입력하세요");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
	internal abstract class Question
	{
		//protected Question(string body, double mark)
		//{
		//	Body = body;
		//	Mark = mark;
		//}

		public abstract string Header { get; }
		public string Body { get; set; }
		public double Mark { get; set; }
		public Answer[] Answers { get; set; }
		public Answer RighrAnswer { get; set; }
		protected Question()
		{

		}
		internal void GetBodyAndMark(int i)
		{
			double mark;
			do
			{
				Console.Write($"Plz Enter the Body Of Question Number {i + 1}: ");
				Body = Console.ReadLine();
			} while (Body == null || Body == String.Empty || !CheckIfNotWhiteSpace(Body));
            Console.WriteLine("=========================");
            do
			{
				Console.Write($"Plz Enter the Mark Of Question Number {i + 1}: ");
			} while ((!double.TryParse(Console.ReadLine(), out mark)) || mark <= 0 );
			Mark = mark;
		}

		// Based on there is no Body Of question his body less than 3 Chats
		internal static bool CheckIfNotWhiteSpace(string text)
		{
			int cnt = 0;
			for (int i = 0; i < text.Length; i++)
			{
				if (char.IsLetter(text[i]))
				{
					cnt++;
				}

			}
			return (cnt >= 3);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
	internal class PracticalExam : Exam
	{
		public PracticalExam(double timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
		{
		}

		public override void ShowExam()
		{
			double score = 0;
			double Degree = 0;

			for (int i = 0; i < NumberOfQuestions; i++)
			{
				if (Questions is not null)
				{
					score += Questions[i].Mark;

					int AnswerOfQuestion;
					Console.WriteLine($"{Questions[i].Header}   Mark:{Questions[i].Mark}");
					Console.WriteLine(Questions[i].Body);
					for (int j = 0; j < 4; j++)
					{ Console.WriteLine($"{j + 1}: {Questions[i].Answers[j].Text}"); }
					Console.WriteLine("=========================="); Console.WriteLine();

					while (!(int.TryParse(Console.ReadLine(), out AnswerOfQuestion)) ||
						(AnswerOfQuestion != 1 && AnswerOfQuestion != 2 && AnswerOfQuestion
						!= 3 && AnswerOfQuestion != 4)) ;
					if (Questions[i].RighrAnswer.Text == Questions[i].Answers[AnswerOfQuestion - 1].Text)
						Degree += Questions[i].Mark;
					Console.Clear();
				}
			}
			ShowRightAnswers();
			Console.WriteLine($"You Got {Degree} From {score}");
		}
	}
}

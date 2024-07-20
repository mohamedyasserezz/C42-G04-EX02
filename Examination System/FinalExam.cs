using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
	internal class FinalExam : Exam
	{
		public FinalExam(double timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
		{

		}

		public override void ShowExam()
		{
			double score = 0;
			double Degree = 0;
			Answer[] answers = new Answer[NumberOfQuestions];
			for (int i = 0; i < NumberOfQuestions; i++)
			{
				answers[i] = new Answer();
				if (Questions is not null)
				{ score += Questions[i].Mark; }
				int AnswerOfQuestion;
				
				Console.WriteLine($"{Questions[i].Header}   Mark:{Questions[i].Mark}");
				Console.WriteLine(Questions[i].Body);
				for (int j = 0; j < Questions[i].Answers.Length; j++)
				{ Console.WriteLine($"{j + 1}: {Questions[i].Answers[j].Text}"); }
				Console.WriteLine("=========================="); Console.WriteLine();
				if (Questions[i] is MCQ)
				{
					while (!(int.TryParse(Console.ReadLine(), out AnswerOfQuestion)) ||
					(AnswerOfQuestion != 1 && AnswerOfQuestion != 2 && AnswerOfQuestion
					!= 3 && AnswerOfQuestion != 4)) ;
				}
				else
				{
					while (!(int.TryParse(Console.ReadLine(), out AnswerOfQuestion)) ||
						(AnswerOfQuestion != 1 && AnswerOfQuestion != 2)) ;
				}
				
				if (Questions[i].RighrAnswer.Text == Questions[i].Answers[AnswerOfQuestion - 1].Text)
					Degree += Questions[i].Mark;
				answers[i].Text = Questions[i].Answers[AnswerOfQuestion - 1].Text;
				Console.Clear();
			}
			Console.Clear();
			ShowQuestions();
            Console.WriteLine("====================");
			ShowRightAnswers();
			Console.WriteLine("====================");
			Console.WriteLine("Your Answers is");
			for (int i = 0; i < answers.Length; i++)
			{
				Console.WriteLine($"Q{i + 1}: {answers[i].Text}");
			}
			Console.WriteLine("====================");
			Console.WriteLine($"You Got {Degree} From {score}");

		}
	}
}

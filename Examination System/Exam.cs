using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
	internal abstract class Exam
	{
		public List<Question> Questions { get; set; }
		protected Exam(double timeOfExam, int numberOfQuestions)
		{
			TimeOfExam = timeOfExam;
			NumberOfQuestions = numberOfQuestions;
		}
		public double TimeOfExam { get; set; }
		public int NumberOfQuestions { get; set; }
		public abstract void ShowExam();
		internal void ShowRightAnswers()
		{
			Console.WriteLine("The Right Asnwers: ");
			for (int i = 0; i < NumberOfQuestions; i++)
			{
				Console.WriteLine($"Q{i + 1} : {Questions[i].RighrAnswer.Text}");
			}
		}
		internal void ShowQuestions()
		{
			Console.WriteLine("The Questions Was: ");
			for (int i = 0; i < NumberOfQuestions; i++)
			{
				Console.WriteLine(Questions[i].Body);
			}
		}
	}
}

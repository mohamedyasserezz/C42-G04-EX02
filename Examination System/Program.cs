using System.Diagnostics;

namespace Examination_System
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Subject subject = new(10, "c#");
			subject.CreateExam();
			Console.Clear(); int cnt = 0;
			char start;
			do
			{
				Console.Write("Do you Want to start Exam y for Yes and N for No: ");
			} while (!char.TryParse(Console.ReadLine(), out start) || (start != 'y' && start != 'Y' && start != 'n' && start != 'N'));
			Console.Clear();
			if (start == 'y' || start == 'Y')
			{
				Stopwatch sw = Stopwatch.StartNew();
				sw.Start();
				subject.Exam.ShowExam();
				Console.WriteLine($"The Elapsed Time: {sw.Elapsed}");

			}

		}
		// have a good day

	}
}

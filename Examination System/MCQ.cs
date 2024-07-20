using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
	internal class MCQ : Question
	{

		public override string Header => "Choose the right Answer Question";
		public MCQ()
		{

		}
  //      public MCQ(string Body, double Mark, string[] choices) : base(Body, Mark)
		//{
		//	Choices = choices;
		//}
	}
}

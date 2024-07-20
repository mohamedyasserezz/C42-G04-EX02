using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
	internal class TrueOrFalse : Question
	{
		public override string Header { get => "True Or False Question"; }
        
        public TrueOrFalse()
        {
			Answers = [new Answer() { Id = 1, Text = "True" }, new Answer() { Id = 2, Text = "False" }];

		}
  //      public TrueOrFalse(string Body, double Mark) : base(Body, Mark)
		//{
		//	Answers = [new Answer() { Id = 1, Text = "True" }, new Answer() { Id = 2, Text = "False" }];
		//}
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
	internal class Subject
	{
		public Subject(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public Exam Exam { get; set; }
		internal void CreateExam()
		{
			
			int ExamType, Minutes, QuestionType;
			do
			{
				Console.Write("Plz Enter the Type Of Exam You Want (1 For Practical Exam and 2 For Final Exam): ");
			} while ((!(int.TryParse(Console.ReadLine(), out ExamType)) || (ExamType != 1 && ExamType != 2)));
			do
			{
				Console.Write("Plz Enter the Time Of Exam in Minutes: ");
			} while (!(int.TryParse(Console.ReadLine(), out Minutes)) || Minutes < 0);
			int NumberOfQuestion;
			do
			{
				Console.Write("Plz Enter the Number Of Questions: ");
			} while (!(int.TryParse(Console.ReadLine(), out NumberOfQuestion)) || NumberOfQuestion < 0);
			Console.Clear();



			if (ExamType == 1)
			{
				Exam = new PracticalExam(Minutes, NumberOfQuestion);
				Exam.Questions = new List<Question>();
				int AnswerOfQuestion;
				for (int i = 0; i < NumberOfQuestion; i++)
				{
					
					Question questionMCQ = new MCQ();
					questionMCQ.RighrAnswer = new();
					questionMCQ.Answers = new Answer[4];
					Console.WriteLine(questionMCQ.Header);
					questionMCQ.GetBodyAndMark(i);
					choices:  for (int j = 0; j < questionMCQ.Answers.Length; j++)
					{
						do
						{
							Console.Write($"Enter thr choice number ({j + 1}): ");
							questionMCQ.Answers[j] = new Answer();
							questionMCQ.Answers[j].Text = Console.ReadLine();
						} while (questionMCQ.Answers[j].Text == null || questionMCQ.Answers[j].Text == String.Empty);
						if(j == questionMCQ.Answers.Length -1)
						{
							if (questionMCQ.Answers[0].Text == questionMCQ.Answers[1].Text || questionMCQ.Answers[0].Text == questionMCQ.Answers[2].Text || questionMCQ.Answers[0].Text == questionMCQ.Answers[3].Text || 
								questionMCQ.Answers[1].Text == questionMCQ.Answers[2].Text || questionMCQ.Answers[1].Text == questionMCQ.Answers[3].Text ||
								questionMCQ.Answers[2].Text == questionMCQ.Answers[3].Text)
							{
                                Console.WriteLine("Enter Distencit values please");
								goto choices;
                            }
						}
					}
					
					do
					{
						Console.Write("Plz Enter the Right Answer Number: ");
					} while (!(int.TryParse(Console.ReadLine(), out AnswerOfQuestion)) ||
					(AnswerOfQuestion != 1 && AnswerOfQuestion != 2 && AnswerOfQuestion
					!= 3 && AnswerOfQuestion != 4));
					questionMCQ.RighrAnswer.Text = questionMCQ.Answers[AnswerOfQuestion - 1].Text;
					AddQuetion(questionMCQ);
					Console.Clear();
				}
			}



			else if (ExamType == 2)
			{
				Exam = new FinalExam(Minutes, NumberOfQuestion);
				Exam.Questions = new List<Question>();
				int AnswerOfQuestion;
				for (int i = 0; i < NumberOfQuestion; i++)
				{
					Console.Clear();
					do
					{
						Console.Write($"Plz Enter the Type Of Question Number {i+1} (1 For True and False 2 For MCQ): ");
					} while ((!(int.TryParse(Console.ReadLine(), out QuestionType)) || (QuestionType != 1 && QuestionType != 2)));


					Console.Clear();

					if (QuestionType == 1)
					{
						Question questionTF = new TrueOrFalse();
						questionTF.RighrAnswer = new();
						Console.WriteLine(questionTF.Header);
						questionTF.GetBodyAndMark(i);
						do
						{
							Console.Write("Enter the Right Answer 1 for True and 2 For False: ");
						} while (!(int.TryParse(Console.ReadLine(), out AnswerOfQuestion)) || (AnswerOfQuestion != 1 && AnswerOfQuestion != 2));
						questionTF.RighrAnswer.Text = AnswerOfQuestion == 1 ? "True" : "Flase";
						AddQuetion(questionTF);
					}
					else if (QuestionType == 2)
					{
						Question questionMCQ = new MCQ();
						questionMCQ.RighrAnswer = new();
						questionMCQ.Answers = new Answer[4];
						Console.WriteLine(questionMCQ.Header);
						questionMCQ.GetBodyAndMark(i);
						ch:  for (int j = 0; j < questionMCQ.Answers.Length; j++)
						{
							do
							{
								Console.Write($"Enter thr choice number ({j + 1}): ");
								questionMCQ.Answers[j] = new Answer();
								questionMCQ.Answers[j].Text = Console.ReadLine();
							} while (questionMCQ.Answers[j].Text == null || questionMCQ.Answers[j].Text==String.Empty);

							if (j == questionMCQ.Answers.Length -1)
							{
								if (questionMCQ.Answers[0].Text == questionMCQ.Answers[1].Text || questionMCQ.Answers[0].Text == questionMCQ.Answers[2].Text || questionMCQ.Answers[0].Text == questionMCQ.Answers[3].Text ||
														questionMCQ.Answers[1].Text == questionMCQ.Answers[2].Text || questionMCQ.Answers[1].Text == questionMCQ.Answers[3].Text ||
														questionMCQ.Answers[2].Text == questionMCQ.Answers[3].Text)
								{
									Console.WriteLine("Enter Distencit values please");
									goto ch;
								} 
							}
						}
						do
						{
							Console.Write("Plz Enter the Right Answer Number: ");
						} while (!(int.TryParse(Console.ReadLine(), out AnswerOfQuestion)) ||
						(AnswerOfQuestion != 1 && AnswerOfQuestion != 2 && AnswerOfQuestion
						!= 3 && AnswerOfQuestion != 4));
						questionMCQ.RighrAnswer.Text = questionMCQ.Answers[AnswerOfQuestion - 1].Text;
						AddQuetion(questionMCQ);
						Console.Clear();
					}

				}
			}

		}

		private void AddQuetion(Question question)
		{
			Exam.Questions.Add(question);
		}
	}
}

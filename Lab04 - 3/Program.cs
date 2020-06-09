using System;
using System.Collections.Generic;
using System.IO;

namespace Lab04___3
{
    class Program
    {
		static void Main(string[] args)
		{
			Console.WriteLine("Enter 0 to input from keyboard or 1 to input from file");
			int user = Convert.ToInt32(Console.ReadLine());

			List<SubjectIndex> subjects = new List<SubjectIndex>();
			if (user == 1)
			{
				Console.WriteLine("Enter file name:");
				string filename = Console.ReadLine();

				//File.Open(filename, FileMode.Open);
				StreamReader streamReader = new StreamReader(filename);

				while (!streamReader.EndOfStream)
				{
					string w = streamReader.ReadLine();
					string[] p = streamReader.ReadLine().Split(' ');
					int pageCount = Convert.ToInt32(streamReader.ReadLine());
					int[] pages = new int[p.Length];
					for (int i = 0; i < p.Length; i++)
					{
						pages[i] = Convert.ToInt32(p[i]);
					}

					subjects.Add(new SubjectIndex(w, pages, pageCount));
				}
				streamReader.Close();
			}
			else if (user == 0)
			{
				Console.WriteLine("How many subject indexes you want to enter?");
				int am = Convert.ToInt32(Console.ReadLine());
				for (int i = 0; i < am; i++)
				{
					AddItem(ref subjects);
				}
			}
			else
			{
				throw new Exception("Wrong number!");
			}

			string menu = "\nEnter:\tA - add a new item\n\tE - edit item\n\tD - delete item\n\tO - output items\n\tS - search by word\n\tR - sort by page number\n\t0 - exit the program";
			char user2;
			do
			{
				Console.WriteLine(menu);
				user2 = Convert.ToChar(Console.ReadLine());

				switch (user2)
				{
					case 'A':
						AddItem(ref subjects);
						break;
					case 'E':
						EditItem(ref subjects);
						break;
					case 'D':
						DeleteItem(ref subjects);
						break;
					case 'O':
						OutputItem(ref subjects);
						break;
					case 'S':
						SearchItem(ref subjects);
						break;
					case 'R':
						SortItems(ref subjects);
						break;
					case '0':
						break;
					default:
						throw new Exception("There is no such button in menu.");
				}
			} while (user2 != '0');

			Console.ReadKey();
		}

		public static void AddItem(ref List<SubjectIndex> subjects)
		{
			string w = InputWord();
			int[] pageNums = InputPages();
			int wordAmount = InputPageCount();

			subjects.Add(new SubjectIndex(w, pageNums, wordAmount));
		}

		public static void EditItem(ref List<SubjectIndex> subjects)
		{
			Console.WriteLine("Enter index of what item you want to edit:");
			int ind = Convert.ToInt32(Console.ReadLine());

			string w = InputWord();
			int[] pageNums = InputPages();
			int wordAmount = InputPageCount();

			subjects[ind].SetWord(w);
			subjects[ind].SetPages(pageNums);
			subjects[ind].SetThisPageCount(wordAmount);
		}

		public static void DeleteItem(ref List<SubjectIndex> subjects)
		{
			Console.WriteLine("Enter index of what item you want to delete:");
			int ind = Convert.ToInt32(Console.ReadLine());
			subjects.RemoveAt(ind);
		}

		public static void OutputItem(ref List<SubjectIndex> subjects)
		{
			for (int i = 0; i < subjects.Count; i++)
			{
				Console.WriteLine("\nSubject Index #{0}:", i + 1);
				OutputSubject(subjects[i]);
			}
		}

		public static void SearchItem(ref List<SubjectIndex> subjects)
		{
			Console.WriteLine("Enter a word you want to search:");
			string word = Console.ReadLine();

			foreach (SubjectIndex subject in subjects)
			{
				if (subject.GetWord() == word)
				{
					OutputSubject(subject);
				}
			}
		}

		public static void SortItems(ref List<SubjectIndex> subjects)
		{
			SubjectIndex temp;
			for (int i = 0; i < subjects.Count; i++)
			{
				for (int j = 0; j < subjects.Count - i - 1; j++)
				{
					if (subjects[j].GetThisPageCount() < subjects[j + 1].GetThisPageCount())
					{
						temp = subjects[j];
						subjects[j] = subjects[j + 1];
						subjects[j + 1] = temp;
					}
				}
			}
		}

		public static void OutputSubject(SubjectIndex subject)
		{
			Console.WriteLine("Word: {0}", subject.GetWord());

			Console.Write("It's written on pages: ");
			for (int j = 0; j < subject.GetPages().Length; j++)
			{
				Console.Write(subject.GetPages()[j] + ", ");
			}
			Console.WriteLine();

			Console.WriteLine("It's on this page {0} times", subject.GetThisPageCount());
		}

		public static string InputWord()
		{
			Console.WriteLine("Enter a word:");
			return Console.ReadLine();
		}

		public static int[] InputPages()
		{
			Console.WriteLine("How many page numbers you wnat to enter?");
			int pageSize = Convert.ToInt32(Console.ReadLine());
			int[] pageNums = new int[pageSize];
			for (int j = 0; j < pageSize; j++)
			{
				pageNums[j] = Convert.ToInt32(Console.ReadLine());
			}
			return pageNums;
		}

		public static int InputPageCount()
		{
			Console.WriteLine("How many of such words is on this page?");
			return Convert.ToInt32(Console.ReadLine());
		}
	}
}

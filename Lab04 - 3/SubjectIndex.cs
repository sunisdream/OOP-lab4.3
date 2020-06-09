using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04___3
{
	class SubjectIndex
	{
		private string word;
		private int[] pages;
		private int thisPageCount;

		public SubjectIndex() { pages = new int[100]; }
		public SubjectIndex(string word, int[] pages, int thisPageCount)
		{
			this.word = word;
			this.pages = pages;
			this.thisPageCount = thisPageCount;
		}

		public string GetWord() { return word; }
		public int[] GetPages() { return pages; }
		public int GetThisPageCount() { return thisPageCount; }
		public void SetWord(string w) { word = w; }
		public void SetPages(int[] p) { pages = p; }
		public void SetThisPageCount(int c) { thisPageCount = c; }
	}
}

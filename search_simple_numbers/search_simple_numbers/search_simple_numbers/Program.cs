using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace search_simple_numbers
{
	class MainClass
	{
		public static bool isSimpleQ(int number) { // O(n^2)
			for (int crnt_number = 2; crnt_number < number; ++crnt_number) {
				if (number % crnt_number == 0) {
					return false;
				}
			}
			return true;
		}

		public static bool isSimple(int number) { // O(sqrt(N))
			for (int crnt_number = 2; crnt_number <= (int)Math.Sqrt (number) + 1; ++crnt_number) {
				if (number % crnt_number == 0) {
					return false;
				}
			}
			return true;
		}
		
		public static void Main (string[] args)
		{
			int N = int.Parse (Console.ReadLine ());
			List<int> answer = new List<int>() { 2 };
			for (int index = 3; answer.Count < N; ++index) {
				if (isSimple (index)) {
					answer.Add(index);
				}
			}

			for (int index = 0; index < answer.Count; ++index) {
				Console.Write(String.Format("{0} ", answer [index]));
			}
		}
	}
}

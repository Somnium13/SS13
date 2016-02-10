using System;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {
	static class Num13 {
		public static double Round(double n, double m) {
			Logger.Debug("num->round");
			return 0;
		}

		public static int Floor(double n) {
			return (int)Math.Floor(n);
		}

		public static double Min(params double[] numbers) {
			if (numbers.Length == 0)
				throw new Exception("min called with zero args!");

			double winner = Double.PositiveInfinity;
			foreach (double n in numbers) {
				if (n < winner) winner = n;
			}
			return winner;
		}

		public static double Max(params double[] numbers) {
			if (numbers.Length == 0)
				throw new Exception("max called with zero args!");

			double winner = Double.NegativeInfinity;
			foreach (double n in numbers) {
				if (n > winner) winner = n;
			}
			return winner;
		}

		public static int MinInt(params int[] numbers) {
			if (numbers.Length == 0)
				throw new Exception("min called with zero args!");

			int winner = Int32.MaxValue;
			foreach (int n in numbers) {
				if (n < winner) winner = n;
			}
			return winner;
		}

		public static int MaxInt(params int[] numbers) {
			if (numbers.Length == 0)
				throw new Exception("max called with zero args!");

			int winner = Int32.MinValue;
			foreach (int n in numbers) {
				if (n > winner) winner = n;
			}
			return winner;
		}

		public static double Min(ByTable numbers) { // TODO
			Logger.Debug("num->min-tbl");
			return 0;
		}

		// Max is never used with a table! Here for completeness, tho
		public static double Max(ByTable numbers) {
			Logger.Debug("num->max-tbl");
			return 0;
		}

		// can also be called with a matrix, evidently
		// 1 = NORTH
		// 2 = SOUTH
		// 4 = EAST
		// 8 = WEST

		// 0 = NORTH, CCW
		static int[] dirs = new[] { 1, 9, 8, 10, 2, 6, 4, 5 };

		// This is not perfect but if you are passing random shit to this you deserve to get fisted.
		public static dynamic Rotate(object d, double angle) {
			if (d is bool || d is int || d is double) {
				int dir = Convert.ToInt32(d);

				if (angle == 0)
					return dir;

				switch (dir) { // convert to sane representation
					case 1: dir = 0; break;
					case 2: dir = 4; break;
					case 4: dir = 6; break;
					case 5: dir = 7; break;
					case 6: dir = 5; break;
					case 8: dir = 2; break;
					case 9: dir = 1; break;
					case 10: dir = 3; break;
					default: throw new Exception("DON'T KNOW THIS DIR!");
				}

				// turn
				int turns = (int)angle / 45;
				dir += turns;
				dir %= 8;

				if (dir < 0)
					dir += 8;

				dir = dirs[dir]; // convert back to insane representation
				//Console.Write("``");
				return dir;
			}
			else {
				throw new Exception("Can't rotate this!");
			}
		}


		// Watch out, this is sometimes used with files... Will be indistinguishable from hashing a string of the filename!
		// THE TRANSCOMPILER NOW ATTEMPTS TO FIX THIS, BUT IT MIGHT STILL HAPPEN!!!
		public static string Md5(string data) {
			var hasher = System.Security.Cryptography.MD5.Create();
			byte[] bytes = hasher.ComputeHash(System.Text.Encoding.ASCII.GetBytes(data));

			return BitConverter.ToString(bytes).Replace("-","").ToLower();
		}

		//this is used not only to construct new, but to do some kind of goofy transformations?!? In any event, it should probably not be used if you can help it!
		public static Game.Matrix Matrix(params object[] args) {
			Logger.Debug("num->matrix");
			return null;
		}
	}
}

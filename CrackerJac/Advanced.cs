using System;

namespace CrackerJac
{
	public static class Advanced
	{
		public static bool NumAppend(string curHash, string name, int lower, int upper, bool FirstCharUp)
		{
                	for (int x = 0; x < Program.Dictionary.Length; x++)
                        {
				for (int y = lower; y < upper; y++)
				{
					if (Supervisor.TermThreads)
					{
						return false;
					}
                        		if (Cracking.GenHash(ShouldAddCap(Program.Dictionary[x], FirstCharUp) + y.ToString()) == curHash)
                                	{
                                		Console.WriteLine("Password found for " + name + ", it is " + ShouldAddCap(Program.Dictionary[x], FirstCharUp) + y.ToString());
                                       		Supervisor.TermThreads = true;
						return true;
                                	}
                        	}
			}
			return false;
		}
		public static bool NumAppendSalt(string hash, string name, string salt, int lower, int upper, bool FirstCharUp = false)
		{
			for (int x = 0; x < Program.Dictionary.Length; x++)
                        {
				for (int y = lower; y < upper; y++)
				{
					if (Supervisor.TermThreads)
					{
						return false;
					}
                                	if (Salting.Run(ShouldAddCap(Program.Dictionary[x], FirstCharUp) + y.ToString(), salt) == hash)
                                	{
                                        	Console.WriteLine("Password found for " + name + ", it is " + ShouldAddCap(Program.Dictionary[x], FirstCharUp) + y.ToString());
                              			Supervisor.TermThreads = true;
				          	return true;
                                	}
                        	}
			}
			return false;
		}

		public static bool AddCapSalt(string hash, string name, string salt)
		{
			for (int x = 0; x < Program.Dictionary.Length; x++)
			{
				if (Supervisor.TermThreads)
				{
					return false;
				}
				if (Salting.Run(ShouldAddCap(Program.Dictionary[x], true), salt) == hash)
				{
					Console.WriteLine("Password found for " + name + ", it is " + ShouldAddCap(Program.Dictionary[x], true));
					Supervisor.TermThreads = true;
					return true;
				}
			}
			return false;
		}

		public static void AddCap(string curHash, string name)
		{
			for (int x = 0; x < Program.Dictionary.Length; x++)
			{
				if (Supervisor.TermThreads)
				{
					return;
				}
				if (Cracking.GenHash(ShouldAddCap(Program.Dictionary[x], true)) == curHash)
				{
					Console.WriteLine("Password found for " + name + ", it is " + ShouldAddCap(Program.Dictionary[x], true));
					Supervisor.TermThreads = true;
					return;
				}
			}
			return;
		}
		public static string ShouldAddCap(string text, bool FirstCharUp)
		{
			if (text == null)
			{
				return "";
			}
			if (FirstCharUp)
			{
				return text[0].ToString().ToUpper() + text.Substring(1);
			}
			else
			{
				return text;
			}
		}
	}
}

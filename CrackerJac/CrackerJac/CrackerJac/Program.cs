using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CrackerJac
{
	public static class Program
	{
		public static string[] Dictionary = new string[1000];
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
			if (args[0] == "-h")
			{
				Console.WriteLine("Usage: CrackerJac [DICTIONARY]... [HASHES]... [OPTIONS]...");
				Console.WriteLine("Dictionary based Unsalted and MyBB Salted MD5 hash cracker.");
				Console.WriteLine("OPTIONS:");
				Console.WriteLine("-h\tDisplays this help and exits");
				Console.WriteLine("-s\tCrackes salted MyBB passwords");
				Console.WriteLine("-u\tCrackes unsalted (regular) passwords");
				Console.WriteLine("-n\tCrackes numeric passwords");
	        	Console.WriteLine("-gu\tGenerates an unsalted password with syntax -gu [STRING]");
        	    Console.WriteLine("-gs\tGenerates a salted password with syntax -gs [SALT] [STRING]");
				Console.WriteLine("FILES:");
        		Console.WriteLine("[DICTIONARY] represents a plain text dictionary file.");
				Console.WriteLine("[HASHES] represents a plain text file containing names and hashes");
				Environment.Exit(0);
			}

            if (args[0] == "-gu")
            {
                Console.WriteLine("The unsalted hash is " + Cracking.GenHash(args[1]));
                Environment.Exit(0);
            }
            if (args[0] == "-gs")
            {
                Console.WriteLine("The salted hash is " + Cracking.GenSaltedHash(args[2], args[1]) + " with the salt " + args[1]);
                Environment.Exit(0);
            }
			if (!File.Exists(args[0]))
			{
				Console.WriteLine("CrackerJac: ERROR dictionary " + args[0] + " could not be loaded as the file does not exist");
				Environment.Exit(-1);
			}
			if (!File.Exists(args[1]))
			{
				Console.WriteLine("CrackerJac: ERROR hash file " + args[1] + " could not be loaded as the file does not exist");
				Environment.Exit(-1);
			}
			string[] hashes = File.ReadAllLines(args[1]);
			string[] buffer = new string[1000];

			using (StreamReader reader = new StreamReader(args[0]))
			{
				while (reader.Peek() != -1)
				{
					for (int y = 0; y < 1000; y++)
					{
						buffer[y] = reader.ReadLine();
					}
					Dictionary = buffer;

					if (args[2] == "-u")
					{
						for (int x = 0; x < hashes.Length; x++)
						{
							Cracking.Unsalted(hashes[0]);
						}
					}
					if (args[2] == "-s")
					{
						for (int x = 0; x < hashes.Length; x++)
						{
							Cracking.Salted(hashes[0]);
						}
					}	
				}
			}
		}
	}
}

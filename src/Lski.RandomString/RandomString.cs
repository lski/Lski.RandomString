using System;
using System.Text;

namespace Lski.RandomString
{
	/// <summary>
	/// A generator that creates random strings restricted to the character set supplied.
	/// </summary>
	public class RandomString
	{
		public const int DEFAULT_SIZE = 12;

		/// <summary>
		/// Length of the string to be generated, can be overidden when generating the string
		/// </summary>
		public int Size { get; set; }

		private char[] _characters;
		private readonly Random _random;

		/// <summary>
		/// The list of characters that is to be used when creating the random string
		/// </summary>
		public char[] Characters
		{
			get => _characters;
			set => _characters = value ?? new char[] { };
		}

		/// <summary>
		/// Creates a random string generator that will be based on the characters supplied
		/// </summary>
		/// <param name="characters">The characters to select from</param>
		public RandomString(Characters characters) : this(DEFAULT_SIZE, characters.Generate()) { }

		/// <summary>
		/// Creates a random string generator of the size supplied that will be based on the characters supplied
		/// </summary>
		/// <param name="characters">The characters to select from</param>
		/// <param name="size">The size of the string being output</param>
		public RandomString(int size, Characters characters) : this(size, characters.Generate()) { }

		/// <summary>
		/// Creates a random string generator that will be based on the characters supplied
		/// </summary>
		/// <param name="characters">The characters to select from</param>
		public RandomString(string characters) : this(DEFAULT_SIZE, characters.ToCharArray()) { }

		/// <summary>
		/// Creates a random string generator of the size supplied that will be based on the characters supplied
		/// </summary>
		/// <param name="characters">The characters to select from</param>
		/// <param name="size">The size of the string being output</param>
		public RandomString(int size, string characters) : this(size, characters.ToCharArray()) { }

		/// <summary>
		/// Creates a random string generator that will be based on the characters supplied
		/// </summary>
		/// <param name="characters">The characters to select from</param>
		public RandomString(char[] characters) : this(DEFAULT_SIZE, characters) { }

		/// <summary>
		/// Creates a random string generator of the size supplied that will be based on the characters supplied
		/// </summary>
		/// <param name="characters">The characters to select from</param>
		/// <param name="size">The size of the string being output</param>
		public RandomString(int size, char[] characters)
		{
			_ = characters ?? throw new ArgumentNullException(nameof(characters));

			Size = size;
			_characters = characters;
			_random = new Random();
		}

		/// <summary>
		/// Generates a random string
		/// </summary>
		public string Generate() => Generate(DEFAULT_SIZE);

		/// <summary>
		/// Generates a random string
		/// </summary>
		/// <param name="size">Overrides the size property just for this call</param>
		public string Generate(int size)
		{
			var code = new StringBuilder(size);

			// Cache the count, to avoid recalling it
			var charListCount = _characters.Length;

			// Now run through and create the string
			for (var i = 0; i < size; i++)
			{
				code.Append(_characters[_random.Next(charListCount)]);
			}

			return code.ToString();
		}
	}
}
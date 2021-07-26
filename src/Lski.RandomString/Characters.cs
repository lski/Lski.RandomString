using System;
using System.Text.RegularExpressions;

namespace Lski.RandomString
{
	/// <summary>
	/// A selection of predfined character lists
	/// </summary>
	[Flags]
	public enum Characters
	{
		/// <summary>
		/// Uppercase letters
		/// </summary>
		Uppercase = 1,

		/// <summary>
		/// Lowercase letters
		/// </summary>
		Lowercase = 2,

		/// <summary>
		/// Numbers 0-9
		/// </summary>
		Numbers = 4,

		/// <summary>
		/// Basic punctuation {}[]()/\'"`~,;:.<>_-
		/// </summary>
		Symbols = 8,

		/// <summary>
		/// Used to exclude similar looking characters iIlLoO10'`
		/// </summary>
		ExcludeSimilar = 16,

		/// <summary>
		/// Upper and lower case letters
		/// </summary>
		Alpha = Uppercase | Lowercase,

		/// <summary>
		/// Upper and lower case letters plus numbers
		/// </summary>
		AlphaNumerics = Alpha | Numbers,

		/// <summary>
		/// Uppercase, Lowercase, Numbers and symbols
		/// </summary>
		All = AlphaNumerics | Symbols
	}

	public static class CharactersExtenstions
	{
		public static string Generate(this Characters characters)
		{
			// using string instead of string builder, as the benefit is borderline on max 5 allocations
			string output = "";

			if (characters.HasFlag(Characters.Uppercase)) {
				output += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			}

			if (characters.HasFlag(Characters.Lowercase)) {
				output += "abcdefghijklmnopqrstuvwxyz";
			}

			if (characters.HasFlag(Characters.Numbers)) {
				output += "0123456789";
			}

			if (characters.HasFlag(Characters.Symbols)) {
				output += @"{}[]()/\'""`~,;:.<>";
			}

			if (characters.HasFlag(Characters.ExcludeSimilar)) {
				output = Regex.Replace(output, "[iIlLoO10'`]", "");
			}

			return output;
		}
	}
}
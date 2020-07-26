using FluentAssertions;
using System;
using Xunit;

namespace Lski.RandomString.Tests
{
	public class CharacterTests
	{
		[Fact]
		public void Characters_Should_Include_All()
		{
			var chars = Characters.All;

			var str = chars.Generate();

			str.Should().Be(@"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789{}[]()/\'""`~,;:.<>");
		}

		[Fact]
		public void Characters_Should_Exclude_Correct_Characters()
		{
			var chars = Characters.All | Characters.ExcludeSimilar;

			var str = chars.Generate();

			str.Should().Be(@"ABCDEFGHJKMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz23456789{}[]()/\""~,;:.<>");
		}

		[Fact]
		public void Characters_Should_Be_Uppercase_Only()
		{
			var chars = Characters.Uppercase;

			var str = chars.Generate();

			str.Should().Be(@"ABCDEFGHIJKLMNOPQRSTUVWXYZ");
		}
	}
}
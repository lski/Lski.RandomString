using FluentAssertions;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Lski.RandomString.Tests
{
	public class RandomStringTest
	{
		private readonly ITestOutputHelper _output;

		public RandomStringTest(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void RandomStrings_Are_Different()
		{
			var r = new RandomString(Characters.All);

			var s1 = r.Generate();
			var s2 = r.Generate();

			_output.WriteLine(s1);
			_output.WriteLine(s2);

			s1.Should().NotBe(s2);
		}

		[Fact]
		public void Should_Have_Length_Correct()
		{
			var r = new RandomString(Characters.All);

			var s1 = r.Generate();

			_output.WriteLine(s1);

			s1.Should().HaveLength(RandomString.DEFAULT_SIZE);

			s1 = r.Generate(12);

			_output.WriteLine(s1);

			s1.Should().HaveLength(12);
		}

		[Fact]
		public void Should_Only_Have_Uppercase_Letters()
		{
			var r = new RandomString(Characters.Uppercase);
			var uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

			var strings = Enumerable.Range(0, 100).Select((index) => r.Generate());

			strings
				.Any(randomString => // Are there any strings that
					randomString.Any(randomChar => // any of its characters
						!uppercaseChars.Any(upperChar => upperChar == randomChar) // are NOT in the list of uppercase letters
					)
				)
				.Should()
				.BeFalse(); // We should not have found any
		}

		[Fact]
		public void Should_Not_Have_Uppercase_Letters()
		{
			var r = new RandomString(Characters.Numbers | Characters.Lowercase | Characters.Symbols);
			var uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

			var strings = Enumerable.Range(0, 100).Select((index) => r.Generate());

			strings
				.Any(randomString => // Are there any strings that
					randomString.Any(randomChar => // any of its characters
						uppercaseChars.Any(upperChar => upperChar == randomChar) // are IN the list of uppercase letters as they shouldnt be
					)
				)
				.Should()
				.BeFalse(); // We should not have found any
		}
	}
}
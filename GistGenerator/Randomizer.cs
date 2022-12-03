using System.Text;

namespace GistGenerator;

public sealed class Randomizer
{
	private readonly Random _random;

	private static readonly char[] AllowedChars =
		"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

	private static readonly string[] Words =
	{
		"consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut",
		"labore", "et", "dolore", "magna", "aliquyam", "erat", "voluptua", "at", "vero", "eos", "accusam", "justo",
		"duo", "dolores", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata", "sanctus",
		"est", "lorem", "ipsum", "dolor", "sit", "amet", "duis", "autem", "vel", "eum", "iriure", "in", "hendrerit",
		"vulputate", "velit", "esse", "molestie", "consequat", "illum", "eu", "feugiat", "nulla", "facilisis",
		"eros", "accumsan", "iusto", "odio", "dignissim", "qui", "blandit", "praesent", "luptatum", "zzril",
		"delenit", "augue", "te", "feugait", "facilisi", "consectetuer", "adipiscing", "elit", "nonummy", "nibh",
		"euismod", "tincidunt", "laoreet", "aliquam", "volutpat", "wisi", "enim", "ad", "minim", "veniam", "quis",
		"nostrud", "exerci", "tation", "ullamcorper", "suscipit", "lobortis", "nisl", "aliquip", "ex", "commodo",
		"nam", "liber", "cum", "soluta", "nobis", "eleifend", "option", "congue", "nihil", "imperdiet", "doming",
		"id", "quod", "mazim", "placerat", "facer", "possim", "assum"
	};

	public Randomizer(Random random)
	{
		_random = random;
	}

	public string GetString(int length)
	{
		var output = new StringBuilder();

		for (var i = 0; i < length; i++)
		{
			output.Append(GetArrayElement(AllowedChars));
		}

		return output.ToString();
	}

	public bool TryProbability(double probability)
	{
		return _random.NextDouble() < probability;
	}

	public string GetSentence(int wordsCount)
	{
		string[] firstWords = { "Lorem", "ipsum", "dolor", "sit", "amet" };

		var output = new StringBuilder();

		output.Append(string.Join(" ", firstWords.Take(wordsCount)));

		for (var i = 0; i < wordsCount - firstWords.Length; i++)
		{
			output.Append(" " + GetArrayElement(Words));
		}

		output.Append('.');
		return output.ToString();
	}

	private T GetArrayElement<T>(IList<T> array)
	{
		return array[_random.Next(array.Count)];
	}
}
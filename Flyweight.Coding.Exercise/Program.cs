using System.Collections.Generic;

namespace Flyweight.Coding.Exercise
{
    public class Sentence
    {
        private readonly string[] _Words;
        private Dictionary<int, WordToken> _WordTokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            _Words = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                var wt = new WordToken();
                this._WordTokens.Add(index,wt);
                return _WordTokens[index];
            }
        }

        public override string ToString()
        {
            var ws = new List<string>();
            for (var i = 0; i < _Words.Length; i++)
            {
                var w = _Words[i];
                if (_WordTokens.ContainsKey(i) && _WordTokens[i].Capitalize)
                    w = w.ToUpperInvariant();
                ws.Add(w);
            }
            return string.Join(" ", ws);        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }


    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sparse
{
	class TokenRule : Rule
	{
		public Regex Pattern
		{
			get;
			set;
		}

		public TokenRule(string name) : base(name)
		{
		}

		public override SyntaxTree[] Parse(string input, int index)
		{
			Match match = this.Pattern.Match(input, index);
			if (match.Success)
			{
				return new SyntaxTree[1] { new SyntaxTree(this.Name, match.Value, index) };
			}
			else
			{
				return new SyntaxTree[0];
			}
		}
	}
}

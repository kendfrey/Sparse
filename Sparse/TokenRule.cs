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
			private set;
		}

		public TokenRule(string name, Regex pattern) : base(name)
		{
			this.Pattern = pattern;
		}
	}
}

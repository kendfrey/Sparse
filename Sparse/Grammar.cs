using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sparse
{
    public class Grammar
    {
		Dictionary<string, Rule> rules;

		string startRule;

		internal Grammar(Dictionary<string, Rule> rules, string startRule)
		{
			this.rules = rules;
			this.startRule = startRule;
		}

		public SyntaxTree Parse(string input)
		{
			SyntaxTree[] results = this.rules[this.startRule].Parse(input, 0);
			if (results.Length > 0)
			{
				return results[0];
			}
			else
			{
				return null;
			}
		}
    }
}

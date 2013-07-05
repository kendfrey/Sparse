using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sparse
{
	public class GrammarBuilder
	{
		Dictionary<string, object> rulePrimitives;

		public GrammarBuilder()
		{
			this.rulePrimitives = new Dictionary<string, object>();
		}

		public void AddTokenRule(string name, Regex pattern)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "You cannot specify a null name.");
			}
			if (pattern == null)
			{
				throw new ArgumentNullException("pattern", "You cannot specify a null pattern.");
			}
			if (this.rulePrimitives.ContainsKey(name))
			{
				throw new ArgumentException("The specified rule name already exists.", "name");
			}
			this.rulePrimitives.Add(name, pattern);
		}

		public void AddComplexRule(string name, string[][] alternations)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "You cannot specify a null name.");
			}
			if (alternations == null)
			{
				throw new ArgumentNullException("alternations", "You cannot specify a null set of alternations.");
			}
			if (alternations.Any(s => s == null))
			{
				throw new ArgumentException("You cannot specify a null alternation.", "alternations");
			}
			if (this.rulePrimitives.ContainsKey(name))
			{
				throw new ArgumentException("The specified rule name already exists.", "name");
			}
			this.rulePrimitives.Add(name, alternations.Select(arr => arr.ToArray()).ToArray());
		}

		public Grammar CreateGrammar(string startRule)
		{
			if (!this.rulePrimitives.ContainsKey(startRule))
			{
				throw new ArgumentException("The specified start rule does not exist.", "startRule");
			}
			string nonexistent = this.rulePrimitives
				.Select(kvp => kvp.Value)
				.OfType<string[][]>()
				.SelectMany(alt => alt.SelectMany(arr => arr))
				.FirstOrDefault(s => this.rulePrimitives.ContainsKey(s));
			if (nonexistent != null)
			{
				throw new InvalidOperationException(string.Format("The rule '{0}' does not exist.", nonexistent));
			}
			Dictionary<string, Rule> rules = this.rulePrimitives
				.ToDictionary(kvp => kvp.Key, kvp => kvp.Value is Regex ? new TokenRule(kvp.Key) as Rule : new ComplexRule(kvp.Key) as Rule);
			foreach (KeyValuePair<string, Rule> kvp in rules)
			{
				if (kvp.Value is TokenRule)
				{
					(kvp.Value as TokenRule).Pattern = this.rulePrimitives[kvp.Key] as Regex;
				}
				else
				{
					(kvp.Value as ComplexRule).Alternations = (this.rulePrimitives[kvp.Key] as string[][])
						.Select(arr => arr.Select(s => rules[s]).ToArray()).ToArray();
				}
			}
			return new Grammar(rules, startRule);
		}
	}
}

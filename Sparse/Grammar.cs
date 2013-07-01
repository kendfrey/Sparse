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
		string startRule;

		Dictionary<string, Rule> rules;
		
		public string StartRule
		{
			get
			{
				return startRule;
			}
			set
			{
				if (!rules.ContainsKey(value) && value != null)
				{
					throw new ArgumentException("The specified rule name does not exist.", "value");
				}
				startRule = value;
			}
		}

		public void AddTokenRule(string name, Regex pattern)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "You cannot specify a null name.");
			}
			if (rules.ContainsKey(name))
			{
				throw new ArgumentException("The specified rule name already exists.", "name");
			}
			rules.Add(name, new TokenRule(name, pattern));
		}

		public void AddComplexRule(string name, string[][] alternations)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "You cannot specify a null name.");
			}
			if (rules.ContainsKey(name))
			{
				throw new ArgumentException("The specified rule name already exists.", "name");
			}
			rules.Add(name, new ComplexRule(name, alternations.Select(arr => arr.ToArray()).ToArray()));
		}

		public void RemoveRule(string name)
		{
			if (!rules.ContainsKey(name))
			{
				throw new ArgumentException("The specified rule name does not exist.");
			}
			if (name == StartRule)
			{
				StartRule = null;
			}
			rules.Remove(name);
		}

		public void ClearRules()
		{
			StartRule = null;
			rules.Clear();
		}
    }
}

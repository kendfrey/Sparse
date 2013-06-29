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
		
		public string StartRule
		{
			get
			{
				return startRule;
			}
			set
			{
				if (!Rules.ContainsKey(value) && value != null)
				{
					throw new ArgumentException("The specified name does not exist.", "value");
				}
				startRule = value;
			}
		}

		Dictionary<string, Rule> Rules
		{
			get;
			set;
		}

		public void AddTokenRule(string name, Regex pattern)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "You cannot specify a null name.");
			}
			if (Rules.ContainsKey(name))
			{
				throw new ArgumentException("The specified rule name already exists.", "name");
			}
			Rules.Add(name, new TokenRule(pattern));
		}

		public void AddComplexRule(string name, string[][] alternations)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "You cannot specify a null name.");
			}
			if (Rules.ContainsKey(name))
			{
				throw new ArgumentException("The specified rule name already exists.", "name");
			}
			Rules.Add(name, new ComplexRule(alternations.Select(arr => arr.ToArray()).ToArray()));
		}

		public void RemoveRule(string name)
		{
			if (!Rules.ContainsKey(name))
			{
				throw new ArgumentException("The specified rule name does not exist.");
			}
			if (name == StartRule)
			{
				StartRule = null;
			}
			Rules.Remove(name);
		}

		public void ClearRules()
		{
			StartRule = null;
			Rules.Clear();
		}
    }
}

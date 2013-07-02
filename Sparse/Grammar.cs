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
				return this.startRule;
			}
			set
			{
				if (!this.rules.ContainsKey(value) && value != null)
				{
					throw new ArgumentException("The specified rule name does not exist.", "value");
				}
				this.startRule = value;
			}
		}

		public void AddTokenRule(string name, Regex pattern)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "You cannot specify a null name.");
			}
			if (this.rules.ContainsKey(name))
			{
				throw new ArgumentException("The specified rule name already exists.", "name");
			}
			this.rules.Add(name, new TokenRule(name, pattern));
		}

		public void AddComplexRule(string name, string[][] alternations)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "You cannot specify a null name.");
			}
			if (this.rules.ContainsKey(name))
			{
				throw new ArgumentException("The specified rule name already exists.", "name");
			}
			this.rules.Add(name, new ComplexRule(name, alternations.Select(arr => arr.ToArray()).ToArray()));
		}

		public void RemoveRule(string name)
		{
			if (!this.rules.ContainsKey(name))
			{
				throw new ArgumentException("The specified rule name does not exist.");
			}
			if (name == this.StartRule)
			{
				this.StartRule = null;
			}
			this.rules.Remove(name);
		}

		public void ClearRules()
		{
			this.StartRule = null;
			this.rules.Clear();
		}
    }
}

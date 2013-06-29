using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparse
{
	class ComplexRule : Rule
	{
		public Rule[][] Alternations
		{
			get;
			set;
		}

		public ComplexRule(string name, Rule[][] alternations) : base(name)
		{
			this.Alternations = alternations;
		}
	}
}

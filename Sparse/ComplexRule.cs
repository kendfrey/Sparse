using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparse
{
	class ComplexRule : Rule
	{
		public string[][] Alternations
		{
			get;
			set;
		}

		public ComplexRule(string name, string[][] alternations) : base(name)
		{
			this.Alternations = alternations;
		}

		public override SyntaxTree[] Parse(string input, int index)
		{
			throw new NotImplementedException();
		}
	}
}

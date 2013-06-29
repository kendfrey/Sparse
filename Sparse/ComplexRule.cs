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

		public ComplexRule(string[][] alternations)
		{
			this.Alternations = alternations;
		}
	}
}

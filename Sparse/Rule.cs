using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparse
{
	abstract class Rule
	{
		public string Name
		{
			get;
			private set;
		}

		protected Rule(string name)
		{
			this.Name = name;
		}

		public abstract SyntaxTree[] Parse(string input, int index);
	}
}

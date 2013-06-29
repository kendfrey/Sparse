using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparse
{
	public class SyntaxTree
	{
		public string RuleName
		{
			get;
			private set;
		}

		public ReadOnlyCollection<SyntaxTree> SyntaxTrees
		{
			get;
			private set;
		}

		internal SyntaxTree(string ruleName, SyntaxTree[] syntaxTrees)
		{
			this.RuleName = ruleName;
			this.SyntaxTrees = Array.AsReadOnly(syntaxTrees);
		}
	}
}

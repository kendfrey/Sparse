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

		public string Content
		{
			get
			{
				return string.Concat(this.SyntaxTrees.Select(t => t.Content));
			}
		}

		public int Index
		{
			get;
			private set;
		}

		public int Length
		{
			get;
			private set;
		}

		internal SyntaxTree(string ruleName, SyntaxTree[] syntaxTrees, int index, int length)
		{
			this.RuleName = ruleName;
			this.SyntaxTrees = Array.AsReadOnly(syntaxTrees);
			this.Index = index;
			this.Length = length;
		}
	}
}

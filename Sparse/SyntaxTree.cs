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
		string token;

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
				return this.token != null ? this.token : string.Concat(this.SyntaxTrees.Select(t => t.Content));
			}
		}

		public int Index
		{
			get;
			private set;
		}

		public int Length
		{
			get
			{
				return this.SyntaxTrees.Sum(t => t.Length);
			}
		}

		internal SyntaxTree(string ruleName, SyntaxTree[] syntaxTrees, int index)
		{
			this.token = null;
			this.RuleName = ruleName;
			this.SyntaxTrees = Array.AsReadOnly(syntaxTrees);
			this.Index = index;
		}

		internal SyntaxTree(string ruleName, string token, int index)
		{
			this.token = token;
			this.RuleName = ruleName;
			this.SyntaxTrees = null;
			this.Index = index;
		}
	}
}

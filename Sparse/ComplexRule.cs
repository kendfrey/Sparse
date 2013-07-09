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

		public ComplexRule(string name) : base(name)
		{
		}

		public override SyntaxTree[] Parse(string input, int index)
		{
			List<SyntaxTree> result = new List<SyntaxTree>();
			// for each alternation in the rule
			for (int i = 0; i < this.Alternations.Length; i++)
			{
				List<SyntaxTree> alternations = new List<SyntaxTree>();
				alternations.Add(new SyntaxTree(this.Name, new SyntaxTree[0], index));
				// for each rule in the alternation
				for (int j = 0; j < this.Alternations[i].Length; j++)
				{
					List<SyntaxTree> newAlternations = new List<SyntaxTree>();
					// for each match found so far
					for (int k = 0; k < alternations.Count; k++)
					{
						// parse the rule at the correct position
						SyntaxTree[] trees = this.Alternations[i][j].Parse(input, index + alternations[k].SyntaxTrees.Sum(tree => tree.Length));
						newAlternations.AddRange(trees.Select(tree => new SyntaxTree(this.Name, alternations[k].SyntaxTrees.Concat(Enumerable.Repeat(tree, 1)).ToArray(), index)));
					}
					alternations = newAlternations;
				}
				result.AddRange(alternations);
			}
			return result.ToArray();
		}
	}
}

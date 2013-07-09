using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparse;

namespace Test
{
	[TestClass]
	public class ComplexRuleTests
	{
		[TestMethod]
		public void ParseWithSingleMatch()
		{
			ComplexRule rule = new ComplexRule("TestRule");
			TokenRule number = new TokenRule("Number");
			number.Pattern = new Regex(@"\d+");
			TokenRule word = new TokenRule("Word");
			word.Pattern = new Regex("[a-z]+");
			rule.Alternations = new Rule[][] { new Rule[] { number, word, number } };
			SyntaxTree[] result = rule.Parse("123abc456", 2);
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Length);
			Assert.AreEqual("3abc456", result[0].Content);
			Assert.AreEqual(2, result[0].Index);
			Assert.AreEqual(7, result[0].Length);
			Assert.AreEqual("TestRule", result[0].RuleName);
			Assert.IsNotNull(result[0].SyntaxTrees);
			Assert.AreEqual(3, result[0].SyntaxTrees.Count);
			Assert.AreEqual("3", result[0].SyntaxTrees[0].Content);
			Assert.AreEqual(2, result[0].SyntaxTrees[0].Index);
			Assert.AreEqual(1, result[0].SyntaxTrees[0].Length);
			Assert.AreEqual("Number", result[0].SyntaxTrees[0].RuleName);
			Assert.IsNull(result[0].SyntaxTrees[0].SyntaxTrees);
			Assert.AreEqual("abc", result[0].SyntaxTrees[1].Content);
			Assert.AreEqual(3, result[0].SyntaxTrees[1].Index);
			Assert.AreEqual(3, result[0].SyntaxTrees[1].Length);
			Assert.AreEqual("Word", result[0].SyntaxTrees[1].RuleName);
			Assert.IsNull(result[0].SyntaxTrees[1].SyntaxTrees);
			Assert.AreEqual("456", result[0].SyntaxTrees[2].Content);
			Assert.AreEqual(6, result[0].SyntaxTrees[2].Index);
			Assert.AreEqual(3, result[0].SyntaxTrees[2].Length);
			Assert.AreEqual("Number", result[0].SyntaxTrees[2].RuleName);
			Assert.IsNull(result[0].SyntaxTrees[2].SyntaxTrees);
		}
	}
}

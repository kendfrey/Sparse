using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparse;

namespace Test
{
	[TestClass]
	public class TokenRuleTests
	{
		[TestMethod]
		public void ParseWithMatch()
		{
			TokenRule rule = new TokenRule("TestName");
			rule.Pattern = new Regex(@"\d+");
			SyntaxTree[] result = rule.Parse("123abc", 0);
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Length);
			Assert.AreEqual("123", result[0].Content);
			Assert.AreEqual(0, result[0].Index);
			Assert.AreEqual(3, result[0].Length);
			Assert.AreEqual("TestName", result[0].RuleName);
			Assert.IsNull(result[0].SyntaxTrees);
		}

		[TestMethod]
		public void ParseWithNoMatch()
		{
			TokenRule rule = new TokenRule("TestName");
			rule.Pattern = new Regex(@"\d+");
			SyntaxTree[] result = rule.Parse("123abc", 3);
			Assert.IsNotNull(result);
			Assert.AreEqual(0, result.Length);
		}

		[TestMethod]
		public void ParseWithShorterMatch()
		{
			TokenRule rule = new TokenRule("TestName");
			rule.Pattern = new Regex(@"\d+");
			SyntaxTree[] result = rule.Parse("123abc", 1);
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Length);
			Assert.AreEqual("23", result[0].Content);
			Assert.AreEqual(1, result[0].Index);
			Assert.AreEqual(2, result[0].Length);
			Assert.AreEqual("TestName", result[0].RuleName);
			Assert.IsNull(result[0].SyntaxTrees);
		}
	}
}

﻿using System;
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

		public Rule(string name)
		{
			this.Name = name;
		}
	}
}

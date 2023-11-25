using System;
using WWWisky.inventory.core.contracts;

namespace WWWisky.inventory.core.recipes
{
	/// <summary>
	/// 
	/// </summary>
	public class Requirement : IRequirement
	{
		public string ID { get; }
		
		
		public Requirement(string id)
		{
			ID = id;
		}
	}
}
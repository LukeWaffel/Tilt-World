using UnityEngine;
using System.Collections.Generic;
using ExpPlus.Molds.Collections;

namespace ExpPlus.Molds.Collections.Generated
{
	[CreateAssetMenu(menuName = "Collections/Level")]
	public class LevelCollection : Collection
	{
		public List<LevelEntry> entries = new List<LevelEntry>();
	}
}
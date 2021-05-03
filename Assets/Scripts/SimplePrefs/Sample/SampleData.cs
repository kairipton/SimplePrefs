using System;

namespace SPrefs
{
	[Serializable]
	public class SampleData : Internal.SPrefsBase<SampleData>
	{
		public int		level;
		public string	desc;
		public bool		isAwsome;
		public float	progress;
	
		// 생성자는 구현 하지 않아도 됨.
		//public SampleData()
		//{
		//	level = 99;
		//	desc = "Simple is always right";
		//	isAwsome = true;
		//	progress = 1f;
		//}
	}
}
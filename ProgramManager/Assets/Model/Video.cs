using System;

namespace Models
{
	[Serializable]

	public class Video
	{
		public string video;
		public int crc;
		public override string ToString()
		{
			return UnityEngine.JsonUtility.ToJson(this, true);
		}
	}
}
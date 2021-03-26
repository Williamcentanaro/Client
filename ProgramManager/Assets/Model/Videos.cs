using System;
using System.Collections.Generic;
 

namespace Models
{
	[Serializable]



	public class Videos
	{
		public int slot;
		public List<Video> videos;
		public override string ToString()
		{
			return UnityEngine.JsonUtility.ToJson(this, true);
		}
	}

}
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 





using UnityEngine;
namespace Assets.Script
{
	public class JsonMessage
	{
		public JsonReader reader { get; set; }
		public string idMacchina { get; set; }
		//Classe wrap dek JSON  e dell'ID Macchina
		public JsonMessage(JsonReader reader, string idMacchina)
		{
			this.reader = reader;
			this.idMacchina = idMacchina;
		}
	}
}
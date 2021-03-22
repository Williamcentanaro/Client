#Client

SINGLETON:

Nei progetti che presentano diverse classi singleton (come spesso accade), può essere pulito e conveniente astrarre il comportamento singleton a una classe base.
Un MonoBehaviour può quindi implementare il pattern singleton estendendo Singleton. Questo approccio consente di utilizzare il pattern con un impatto minimo sul Singleton stesso.
Si noti che uno dei vantaggi del pattern singleton è che è possibile accedere staticamente a un riferimento all'istanza es:
// Logs: String Instance
Debug.Log(SingletonImplementation.Instance.Text);


Pacchetto Newtonsoft Json Unity
è un pacchetto destinato a progetti di sviluppo Unity interni e come tale non è supportato. Utilizzare a proprio rischio.
La documentazione per questo pacchetto viene fornita come collegamenti alla documentazione di Json.NET.
Json.NET è un popolare framework JSON per .NET
Documentazione
Pagina principale di Json.NET Documentazione di Json.NET Codice sorgente Json.NET
Casi d'uso
Serializzatore JSON flessibile per la conversione tra oggetti .NET e JSON
LINQ to JSON per leggere e scrivere manualmente JSON
Scrivi JSON rientrato e di facile lettura
Converti JSON in e da XML
Supporta .NET Standard 2.0, .NET 2, .NET 3.5, .NET 4, .NET 4.5, Silverlight, Windows Phone e Windows 8 Store
Questo è un pacchetto destinato a progetti di sviluppo Unity interni e come tale non è supportato. Utilizzare a proprio rischio.

JSON in Unity :

La serializzazione JSON utilizza una nozione di JSON "strutturato": si crea una classe o una struttura per descrivere le variabili che si desidera memorizzare nei dati JSON.
Definisce una semplice classe C # contenente variabili e la contrassegna con l' Serializableattributo, in modo da funzionare con il serializzatore JSON. 
Nota:
Se i dati JSON non contengono un valore per un campo, il serializzatore non modifica il valore di quel campo. Questo metodo consente di ridurre al minimo le allocazioni riutilizzando gli oggetti creati in precedenza. Consente inoltre di "applicare patch" agli oggetti sovrascrivendoli deliberatamente con JSON che contiene solo un piccolo sottoinsieme di campi.
Avviso: l'API JSON Serializer supporta le sottoclassi MonoBehaviour e ScriptableObject oltre a strutture e classi semplici. Tuttavia, quando si deserializza JSON in sottoclassi di MonoBehaviouro ScriptableObject, è necessario utilizzare il metodo FromJsonOverwrite . Se si tenta di utilizzare FromJson , Unity genera un'eccezione perché questo comportamento non è supportato.
Per informazioni più dettagliate visitare la documentazione nel sito di Unity: https://docs.unity3d.com/Manual/JSONSerialization.html

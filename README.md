#Client

Nei progetti che presentano diverse classi singleton (come spesso accade), può essere pulito e conveniente astrarre il comportamento singleton a una classe base.
Un MonoBehaviour può quindi implementare il pattern singleton estendendo Singleton. Questo approccio consente di utilizzare il pattern con un impatto minimo sul Singleton stesso.
Si noti che uno dei vantaggi del pattern singleton è che è possibile accedere staticamente a un riferimento all'istanza es:
// Logs: String Instance
Debug.Log(SingletonImplementation.Instance.Text);

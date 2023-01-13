using UnityEngine;

public class PlayerManager : MonoBehaviour{
    
    private static readonly double MAX_X = 8.89;
    private static readonly double MAX_Y = 5;
    private static readonly double AGENT_WIDTH = 0.34;
    private static readonly double AGENT_HEIGHT = 0.74;

    [SerializeField] private GameObject agentPrefab;

    private void Start(){
        GenerateAgents(3);
    }

    private void Update(){
    }

    private void GenerateAgents(int count){
        var maxPlaceableX = MAX_X - AGENT_WIDTH / 2;
        var maxPlaceableY = MAX_Y - AGENT_HEIGHT / 2;

        var x = Random.Range((int) (-maxPlaceableX * 100), (int) maxPlaceableX * 100);
        var y = Random.Range((int) (-maxPlaceableY * 100), (int) maxPlaceableY * 100);

        var position = new Vector3(x / 100f, y / 100f, 0);

        var agent = Instantiate(agentPrefab, position, Quaternion.identity);
        agent.transform.SetParent(gameObject.transform);

        if (count != 1) GenerateAgents(count - 1);
    }
}
using UnityEngine;

public class BotManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 velocity;
    void Start()
    {
        Random.Range(0.001f,0.07f);
        velocity = new Vector2(0.05f,0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 botPos = this.transform.position;
        Vector2 newPos = botPos+velocity;
        this.transform.position=newPos;
    }
}
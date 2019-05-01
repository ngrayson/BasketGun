using UnityEngine.SceneManagement;
using UnityEngine;

public class BootStrapManager : MonoBehaviour
{
    enum GameState {Title, Play, Loss, Win};
    GameState currentState;
    // Start is called before the first frame update
    void Start()
    {
        //load title and set to title
    }

    void setTitle()
    {
    }

    void setPlay()
    {
    
    }

    void setLoss()
    {

    }

    void setWin()
    {
        
    }
    void clearScene(Scene targetScene)
    {
        // deletes everything in the target scene to unload it
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

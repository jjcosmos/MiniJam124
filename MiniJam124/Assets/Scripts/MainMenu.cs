using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Game.Singleton.GameState = GameState.Menus;
    }

    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            SceneManager.LoadScene(1);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quiiting the game...");
    }
}

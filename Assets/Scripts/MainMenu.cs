using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public void Onclick()
    {
        SceneManager.LoadScene("Level1");
    }
}

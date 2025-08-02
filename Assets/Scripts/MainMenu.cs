using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("DenemeSahne"); // Level1 sahnenin adı doğru mu kontrol et
    }


    public void QuitGame()
    {

        Application.Quit();
    }
}

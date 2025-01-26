using UnityEngine;
using UnityEngine.SceneManagement;

public class basicButtons : MonoBehaviour
{
    public void GoTOScene(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }
    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}

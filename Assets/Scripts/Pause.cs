using UnityEngine;

public class Pause : MonoBehaviour
{
    bool paused;

    [SerializeField] GameObject pauseMenu;
   public void Pausee()
    {
        if (paused)
        {
            paused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            paused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

using UnityEngine;

public class basicButtons : MonoBehaviour
{
    public void GoTOScene(int index)
    {
        Time.timeScale = 1;
        Gamemanager.Instance.SwitchScene(index);
    }
    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}

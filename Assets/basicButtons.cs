using UnityEngine;

public class basicButtons : MonoBehaviour
{
    public void GoTOScene(int index)
    {
        Gamemanager.Instance.SwitchScene(index);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

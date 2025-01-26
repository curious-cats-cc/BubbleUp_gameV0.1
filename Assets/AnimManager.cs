using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textBoxthing;

    [SerializeField] string[] texts;
    [SerializeField]
    GameObject[] Scenes;

    [SerializeField] GameObject barnScene;
    [SerializeField] GameObject miceScene;


    private void Start()
    {
        StartCoroutine(enumerator(0,1));
    }

    IEnumerator enumerator(int index, int waitTime)

    {
        yield return new WaitForSeconds(waitTime);
        textBoxthing.text = "";
        if(index > 0)
        {
            Scenes[index - 1].SetActive(false);
        }
        
        Scenes[index].SetActive(true);
        for (int i = 0; i < texts[index].Length; i++)
        {
            yield return new WaitForSeconds(0.05f);
            textBoxthing.text = textBoxthing.text + texts[index][i];
        }
        

        if (index<3)
        {
            StartCoroutine(enumerator(index + 1, 1));
        }
        
        else
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(1);
        }

    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(1f);
        textBoxthing.text = "";
        barnScene.SetActive(false);
        barnScene.SetActive(true);
        StartCoroutine(enumerator(3,2));
    }
}

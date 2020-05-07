using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeManager : MonoBehaviour
{
    public static SceneChangeManager instance;
    public Animator anim;

    public GameObject loading;
    private void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            return;
        }
        loading.SetActive(false);
    }

    public void SceneChangeMethod(string scenename)
    {
        StartCoroutine(SceneChange(scenename));
    }

    IEnumerator SceneChange(string scenename)
    {
        anim.SetTrigger("Transition");
        yield return new WaitForSeconds(2f);
        loading.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync(scenename);
        loading.SetActive(false);
    }
    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
        Application.Quit();
    }
    public void ClickSound(string name)
    {
        FindObjectOfType<AudioManager>().Play(name);
    }
    public void SetActive_Object(GameObject Go)
    {
        Go.SetActive(true);
    }
    public void SetUnActive_Object(GameObject Go)
    {
        Go.SetActive(false);
    }

}

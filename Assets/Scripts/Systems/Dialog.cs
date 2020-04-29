using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI text;

    [TextArea(1,3)]
    public string[] sentences;

    public float waittime;

    private int index;

    public GameObject Continue;
    public GameObject Skip;

    public string Scenename;

    private void Start()
    {
        StartCoroutine(type());
        Continue.SetActive(false);
    }
    private void Update()
    {
        if (text.text == sentences[index])
        {
            Continue.SetActive(true);
        }
        if(PlayerPrefs.GetInt("AlreadyLoaded")==1)
        {
            Skip.SetActive(true);
        }
    }
    IEnumerator type()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(waittime);
        }
    }
    public void nextSentence()
    {
        Continue.SetActive(false);
        if (index < sentences.Length - 1)
        {
            FindObjectOfType<AudioManager>().Play("Tap");
            index++;
            text.text = "";
            StartCoroutine(type());
        }
        else
        {
            text.text = "";
            PlayerPrefs.SetInt("AlreadyLoaded",1);
            SceneChangeManager.instance.SceneChangeMethod("Game");
        }
        if (index == 2)
        {
            FindObjectOfType<AudioManager>().Play("Slogan");
        }
    }
}
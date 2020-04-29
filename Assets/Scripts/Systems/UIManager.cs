using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    Wall Player;
    public ArtilleryController artilleryController;
    public TextMeshProUGUI MoneyUI;
    public TextMeshProUGUI Powercount;
    public TextMeshProUGUI BulletCount;
    public Animator textAnim;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Wall").GetComponent<Wall>();
        StartCoroutine(TextAnim());
    }

    void Update()
    {
        if(Player==null)
        {
            return;
        }
        else
        {
            MoneyUI.text = Player.GetComponent<Money>().MoneyCount.ToString();
            Powercount.text = "x" + Player.GetComponent<Powerup>().powerCount.ToString();
            BulletCount.text = "x" +artilleryController.BulletCount.ToString();
        }
    }
    IEnumerator TextAnim()
    {
        yield return new WaitForSeconds(1f);
        textAnim.SetTrigger("Start");
        yield return new WaitForSeconds(3f);
        textAnim.SetTrigger("End");
    }
    public void ActiveObject(GameObject gameObject)
    {
        bool isactive = gameObject.activeSelf;
        gameObject.SetActive(!isactive);
    }
}

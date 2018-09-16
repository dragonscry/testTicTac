using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winCondition : MonoBehaviour {

    public GameObject[] array;
    public string[] smth;

    public int Count;
    private GameObject winPanel;
    private GameObject restartBtn;
    private GameController gameController;
    private GameObject pve;
    private GameObject pvp;
    private AI aI;

    // Use this for initialization

    private void Awake()
    {
        winPanel = GameObject.FindGameObjectWithTag("winPanel");
        restartBtn = GameObject.Find("Restart");
        gameController = GetComponent<GameController>();
        aI = GetComponent<AI>();
        pve = GameObject.Find("PVE");
        pvp = GameObject.Find("PVP");
        Count = 0;
    }
    void Start () {
        array = GameObject.FindGameObjectsWithTag("Cell");

        smth = new string[9];
        winPanel.SetActive(false);
        restartBtn.SetActive(false);
    }

   public void Obj()
    {
        for (int i = 0; i < array.Length; i++)
        {
            smth[i] = array[i].GetComponent<OnClick>().choice;
        }
    }

    public void wining()
    {
        Count++;
        if (smth[0] == smth[1]&& smth[1] == smth[2] && smth[0] != "")
        {
            Winner("WINNER IS: " + smth[0].ToUpper());
            return;
        }
        if (smth[3] == smth[4] && smth[4] == smth[5] && smth[3] != "")
        {
            Winner("WINNER IS: " + smth[3].ToUpper());
            return;
        }
        if (smth[6] == smth[7] && smth[7] == smth[8] && smth[6] != "")
        {
            Winner("WINNER IS: " + smth[6].ToUpper());
            return;
        }
        if (smth[0] == smth[3] && smth[3] == smth[6] && smth[0] != "")
        {
            Winner("WINNER IS: " + smth[0].ToUpper());
            return;
        }
        if (smth[1] == smth[4] && smth[4] == smth[7] && smth[1] != "")
        {
            Winner("WINNER IS: " + smth[1].ToUpper());
            return;
        }
        if (smth[2] == smth[5] && smth[5] == smth[8] && smth[2] != "")
        {
            Winner("WINNER IS: " + smth[2].ToUpper());
            return;
        }
        if (smth[0] == smth[4] && smth[4] == smth[8] && smth[0] != "")
        {
            Winner("WINNER IS: " + smth[0].ToUpper());
            return;
        }
        if (smth[6] == smth[4] && smth[4] == smth[2] && smth[6] != "")
        {
            Winner("WINNER IS: " + smth[6].ToUpper());
            return;
        }
        else if (Count == 9)
        {
            Winner("IT's a DRAW");
        }

    }

    public void Restart()
    {
        Count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            BoxCollider2D col = array[i].GetComponent<BoxCollider2D>();
            SpriteRenderer spr = array[i].GetComponent<SpriteRenderer>();
            array[i].GetComponent<OnClick>().choice = "";
            if (spr.sprite !=null)
            {
                col.enabled = !col.enabled;
            }
            spr.sprite = null;
            winPanel.SetActive(false);

        }
        for (int i = 0; i < smth.Length; i++)
        {
            smth[i] = null;
        }
        gameController.Turn = 1;
        restartBtn.SetActive(false);

    }

    public void Winner(string str)
    {
        winPanel.SetActive(true);
        buttonActive(true);
        restartBtn.SetActive(true);
        Text winText = winPanel.GetComponentInChildren<Text>();
        winText.text = str;
        aI.playerAI = false;

    }

    public void buttonActive(bool enable)
    {
        pve.SetActive(enable);
        pvp.SetActive(enable);
    }
}

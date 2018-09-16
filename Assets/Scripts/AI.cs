using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public bool playerAI = false;

    public int countAI;
    public string[] playerChoice;
    public Sprite o;
    private winCondition win;
    private GameController gameController;

    private void Awake()
    {
        playerChoice = new string[9];
        win = GameObject.FindWithTag("GameController").GetComponent<winCondition>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        countAI = 0;
    }

    public void EnableAI()
    {
        playerAI = true;
        win.buttonActive(false);

    }

    public void DisableAI()
    {
        playerAI = false;
        win.buttonActive(false);
    }

    public void aiInGame()
    {
        if (playerAI == true)
        {

            AIChoice();
        }
    }

   
    void AIChoice()
    {
        if (win.Count < 9)
        {
            int arg = Random.Range(1, 9);
            if (win.smth[arg] == "")
            {
                win.array[arg].GetComponent<OnClick>().spr.sprite = o;
                win.array[arg].GetComponent<OnClick>().choice = "o";
                BoxCollider2D col = win.array[arg].GetComponent<BoxCollider2D>();
                col.enabled = !col.enabled;
                gameController.ChangeTurn();
                win.Obj();
                win.wining();
            }
            else
                AIChoice();
        }

        else if (win.Count == 9)
            return;

    }


}

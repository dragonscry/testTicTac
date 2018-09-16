using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour {

    public Sprite x;
    public Sprite o;

    private GameController gameController;
    private winCondition win;
    private AI aiScript;

    public SpriteRenderer spr;

    public string choice;

    public int playerTurn;
    

    private void Awake()
    {
        choice = "";
        spr = GetComponent<SpriteRenderer>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        win = GameObject.FindWithTag("GameController").GetComponent<winCondition>();
        aiScript = GameObject.FindWithTag("GameController").GetComponent<AI>();
    }

    private void OnMouseDown()
    {
        playerTurn = gameController.Turn;
        win.buttonActive(false);

        if (playerTurn == 1)
        {
            spr.sprite = x;
            choice = "x";
        }
        else if (playerTurn == 0)
        {
            spr.sprite = o;
            choice = "o";
        }
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        col.enabled = !col.enabled;
        gameController.ChangeTurn();
        win.Obj();
        win.wining();
        aiScript.aiInGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int columns;
    public int rows;
    public GameObject cell;

    public int Turn;

    void Board()
    {
        for (int x = -1; x < columns-1; x++)
        {
            for (int y = -1; y < rows-1; y++)
            {
                GameObject instance = Instantiate(cell, new Vector3(x, y, 0f), Quaternion.identity);
            }
        }
    }

    public void ChangeTurn()
    {
        if (Turn == 1)
        {
            Turn = 0;
        }
        else if (Turn == 0)
        {
            Turn = 1;
        }
    }
    void Awake()
    {

        Board();
        ChangeTurn();
    }

}

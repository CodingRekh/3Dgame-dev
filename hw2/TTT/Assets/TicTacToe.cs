using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TicTacToe : MonoBehaviour
{
    private int[,] board = new int[3, 3];       
    private int turn = 0;
    private int initTurn = 0;

    public Texture2D Background;
    public Texture2D O;
    public Texture2D X;
    public Texture2D Space;

    void Start()
    {
        init();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.normal.background = null;
        style.fontSize = 20;

        GUIStyle bigStyle = new GUIStyle();
        bigStyle.normal.textColor = Color.white;
        bigStyle.normal.background = null;
        bigStyle.fontSize = 50;

        GUI.Label(new Rect(0, 0, 920, 540), Background);

        int state = checkState();
        switch (state)
        {
            case 0:
                GUI.Label(new Rect(500, 50, 200, 50), "状态: 进行中, 玩家"+(turn+1)+"执棋", style);
                break;
            case 1:
                GUI.Label(new Rect(500, 50, 200, 50), "状态: 玩家1获胜", style);
                break;
            case 2:
                GUI.Label(new Rect(500, 50, 200, 50), "状态: 玩家2获胜", style);
                break;
            case 3:
                GUI.Label(new Rect(500, 50, 200, 50), "结果: 平局", style);
                break;
        }

        GUI.Label(new Rect(135, 25, 200, 50), "简易井字棋", bigStyle);

        if (GUI.Button(new Rect(200, 350, 100, 50), "重置"))
            init();

        if (GUI.Button(new Rect(200, 100, 100, 50), "玩家1:先手"))
        {
            initTurn = 0;
            init();
        }
        if (GUI.Button(new Rect(200, 150, 100, 50), "玩家1:后手"))
        {
            initTurn = 1;
            init();
        }

        playerVsPlayer();
    }

    void init()
    {
        turn = initTurn;
        for(int temp1 = 0; temp1 < 3; temp1++)
        {
            for(int temp2 = 0; temp2 < 3; temp2++)
            {
                board[temp1, temp2] = 0;
            }
        }
    }

    void playerVsPlayer()
    {
        for (int temp1 = 0; temp1 < 3; temp1++)
        {
            for (int temp2 = 0; temp2 < 3; temp2++)
            {
                switch (board[temp1, temp2])
                {
                    case 0:

                        if (GUI.Button(new Rect(450 + temp1 * 100, 100 + temp2 * 100, 100, 100), Space) && checkState() == 0)
                        {
                            board[temp1, temp2] = turn + 1;
                            turn = 1 - turn;
                        }
                        break;
                    case 1:
                        GUI.Button(new Rect(450 + temp1 * 100, 100 + temp2 * 100, 100, 100), O);
                        break;
                    case 2:
                        GUI.Button(new Rect(450 + temp1 * 100, 100 + temp2 * 100, 100, 100), X);
                        break;
                }
            }
        }
    }

    int checkState()
    {
        if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
            return board[0, 0];
        if (board[2, 0] != 0 && board[2, 0] == board[1, 1] && board[2, 0] == board[0, 2])
            return board[2, 0];

        int cnt = 0;
        for (int temp1 = 0; temp1 < 3; temp1++)
        {   
            if (board[temp1, 0] == board[temp1, 1] && board[temp1, 0] == board[temp1, 2] && board[temp1, 0] != 0)
                return board[temp1, 0];
            if (board[0, temp1] == board[1, temp1] && board[0, temp1] == board[2, temp1] && board[0, temp1] != 0)
                return board[0, temp1];
            for (int temp2 = 0; temp2 <3; temp2++)
            {
                if (board[temp1, temp2] == 0)
                    cnt++;
            }
        }
        return cnt==0?3:0;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private IUserAction userAction;
    string gameMessage;
    public int time;
    void Start()
    {
        time = 0;
        userAction = SSDirector.GetInstance().CurrentSenceController as IUserAction;
    }

    void OnGUI()
    {
        GUIStyle style_title = new GUIStyle();
        style_title.normal.textColor = Color.red;
        style_title.fontSize = 50;

        GUIStyle style_text = new GUIStyle();
        style_text.normal.textColor = Color.white;
        style_text.fontSize = 30;

        GUI.Label(new Rect(0, 0, 50, 200), "牧师与魔鬼", style_title);
        GUI.Label(new Rect(0, 80, 100, 50), "已用时间：" + time, style_text);

        if (GUI.Button(new Rect(0, 140, 100, 50), "重试"))
        {
            userAction.Restart();
        }

        GUI.Label(new Rect(0, 220, 100, 50), gameMessage, style_text);

    }

    public void setGameMessage(bool isWin)
    {
        if (isWin)
        {
            gameMessage = "胜利！";
        }
        else
        {
            gameMessage = "可惜失败！请重试！";
        }
    }

    public void resetGameMessage()
    {
        gameMessage = "";
    }
}

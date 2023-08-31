using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedButtons : MonoBehaviour
{
    public Image[] gameSpeedIcons;

    private void Start()
    {
        for(int i = 0; i < gameSpeedIcons.Length; i++)
        {
            gameSpeedIcons[i].color =Color.white;
        }
        gameSpeedIcons[0].color = new Color32(100, 230, 120, 255);
    }

    public void ActivateButton(int arrayIndex) 
    {
        for (int i = 0; i < gameSpeedIcons.Length; i++)
        {
            gameSpeedIcons[i].color = Color.white;
        }
        gameSpeedIcons[arrayIndex].color = new Color32(100, 230, 120, 255);
    }

    private void Update()
    {
        if (gameSpeedIcons[0].color ==new Color32(100, 230, 120, 255))
        {
            Time.timeScale = 0f;
        }

        else if (gameSpeedIcons[1].color ==new Color32(100, 230, 120, 255))
        {
            Time.timeScale = 1f;
        }

        else if (gameSpeedIcons[2].color ==new Color32(100, 230, 120, 255))
        {
            Time.timeScale = 3f;
        }
    }
}

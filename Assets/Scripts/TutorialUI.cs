using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField]
    GameObject tutorialUi;

    //tells the PlayerLighting class that the user pressed the play button
    public bool hasStarted = false;

    private void Awake()
    {
        tutorialUi.gameObject.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void HideTutorialCanvas()
    {
        hasStarted = true;
        tutorialUi.gameObject.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}

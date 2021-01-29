using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField]
    GameObject tutorialUi;

    private void Awake()
    {
        tutorialUi.gameObject.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void HideTutorialCanvas()
    {
        tutorialUi.gameObject.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}

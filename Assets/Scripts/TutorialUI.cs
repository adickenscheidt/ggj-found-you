using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    //UI canvas
    [SerializeField]
    GameObject tutorialUi;

    //Player Object
    [SerializeField]
    GameObject playerObject;

    //Player Object SRenderer
    SpriteRenderer spriteRenderer;

    //The Spotlight that follows the player
    [SerializeField]
    Light playerLight;

    private void Awake()
    {
        tutorialUi.gameObject.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        spriteRenderer = playerObject.GetComponent<SpriteRenderer>();

        playerLight.range = 25;
        playerLight.intensity = 14;
    }

    private void Start()
    {
        spriteRenderer.color = new Color(.3f, .3f, .3f, 1f);
    }

    public void HideTutorialCanvas()
    {
        tutorialUi.gameObject.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        playerLight.range = 35;
        playerLight.intensity = 22;
        spriteRenderer.color = new Color(.8f, .8f, .8f, 1f);
    }
}

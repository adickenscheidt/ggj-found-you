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
        //sets the Ui visible
        tutorialUi.gameObject.SetActive(true);
        //makes sure the cursor is visible
        Cursor.visible = true;
        //sets time to 0
        Time.timeScale = 0;
        spriteRenderer = playerObject.GetComponent<SpriteRenderer>();

        //dims the light
        playerLight.range = 25;
        playerLight.intensity = 14;
    }

    private void Start()
    {
        spriteRenderer.color = new Color(.3f, .3f, .3f, 1f);
    }


    /// <summary>
    /// Button Event, turns off ui canvas, activates time and Light.
    /// </summary>
    public void HideTutorialCanvas()
    {
        //deactivates the UI/Canvas
        tutorialUi.gameObject.SetActive(false);
        //makes the cursor invisible
        Cursor.visible = false;
        //the game time runs normally
        Time.timeScale = 1;
        //creates a small cone of light around the player
        playerLight.range = 35;
        playerLight.intensity = 22;
        //lightens up the players sprite (only 80%, as it is too bright normally)
        spriteRenderer.color = new Color(.8f, .8f, .8f, 1f);
    }
}

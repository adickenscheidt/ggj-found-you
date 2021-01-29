using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLighting : MonoBehaviour
{
    //the spotlight in the player Children
    [SerializeField]
    GameObject playerObject;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    Light playerLight;

    TutorialUI tutUI;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        tutUI = FindObjectOfType<TutorialUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutUI.hasStarted)
        {
            playerLight.range = 25;
            playerLight.intensity = 14;
        }
        else
        {
            playerLight.range = 35;
            playerLight.intensity = 22;
            spriteRenderer.color = new Color(.8f, .8f, .8f, 1f);
        }
    }
}

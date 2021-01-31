using UnityEngine;
using UnityEngine.AI;

public class Victim : MonoBehaviour
{
    public float movementSpeed = 15f;
    public bool alive = true;
    public bool hidden = false;
    public float nextHideTime;

    // Start is called before the first frame update
    void Start()
    {
        // var aiObject = GetComponentInChildren<AIController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Hide()
    {
        hidden = true;
        gameObject.SetActive(false);
    }

    public void Unhide()
    {
        hidden = false;
        gameObject.SetActive(true);
        nextHideTime = Time.time + 10f;
    }

    public void Kill()
    {

    }
}

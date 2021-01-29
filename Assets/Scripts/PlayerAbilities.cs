using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject Cake;
    public float CoolDown;

    void Update()
    {
        CoolDown -= Time.deltaTime;
        if (CoolDown <= 0)
        {
            CoolDown = 0;
            if (Input.GetKeyDown("3"))
            {
                GameObject Bait = Instantiate(Cake, new Vector2(transform.position.x, transform.position.y - 1), transform.rotation) as GameObject;
                Bait.GetComponent<GameObject>();
                CoolDown = 10;
            }
        }
    }

    //private void putCakeOnGround()
    //{
    //    if (Input.GetKeyDown("3"))
    //    {
    //        GameObject Bait = Instantiate(Cake, new Vector2(transform.position.x, transform.position.y - 1), transform.rotation) as GameObject;
    //        Bait.GetComponent<GameObject>();
    //    }
    //}
}

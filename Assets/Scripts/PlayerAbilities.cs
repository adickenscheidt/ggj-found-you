using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject Cake;
    public static GameObject foundFootsteps;
    public float CoolDown;
    public float CFFCoolDown;
    public float CFFShow;

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
        CheckForFootsteps();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, SenseRange);
    }

    public float SenseRange = 15f;

    public void CheckForFootsteps()
    {
        CFFCoolDown -= Time.deltaTime;
        CFFShow -= Time.deltaTime;
        var collision = Physics.OverlapSphere(transform.position, SenseRange);
        foreach(var footstep in collision)
        {
            var foundFootsteps = footstep.GetComponent<Footstep>();
            if (foundFootsteps == null)
            {
                continue;
            }

            while (Input.GetKeyDown("2") && CFFCoolDown <= 0)
            {
                foundFootsteps.Show();
                CFFShow = 10;
                CFFCoolDown = 20;
            }
            if (CFFShow <= 0)
            {
                foundFootsteps.Hide();
            }
        }
    }
}

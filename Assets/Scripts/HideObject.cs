using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    private List<GameObject> _hidingVictims;

    // Start is called before the first frame update
    void Start()
    {
        _hidingVictims = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideIn(GameObject hidingVictim)
    {
        _hidingVictims.Add(hidingVictim);
    }
}

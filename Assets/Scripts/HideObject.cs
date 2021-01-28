using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    private List<VictimAI> _hidingVictims;

    // Start is called before the first frame update
    void Start()
    {
        _hidingVictims = new List<VictimAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideIn(VictimAI hidingVictim)
    {
        _hidingVictims.Add(hidingVictim);
    }
}

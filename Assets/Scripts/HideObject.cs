using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    private List<Victim> _hidingVictims;

    // Start is called before the first frame update
    void Start()
    {
        _hidingVictims = new List<Victim>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideIn(Victim hidingVictim)
    {
        _hidingVictims.Add(hidingVictim);
        hidingVictim.Hide();
    }

    public void KickVictimsOut()
    {
        foreach (var hidingVictim in _hidingVictims)
        {
            hidingVictim.Unhide();
        }
        _hidingVictims.Clear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProximityEvents/Cauldron")]
public class CauldronEvent : ProximityEvent
{
    public override void Activate(GameObject self, GameObject target, List<GameObject> additionalTargets)
    {
        Debug.Log("cauldron activated");
        additionalTargets[0].GetComponent<SpriteRenderer>().enabled = true;
        additionalTargets[1].GetComponent<SpriteRenderer>().enabled = true;
        additionalTargets[2].GetComponent<SpriteRenderer>().enabled = false;
    }

    public override void Deactivate(GameObject self, GameObject target, List<GameObject> additionalTargets)
    {
        Debug.Log("cauldron de-activated");
        additionalTargets[0].GetComponent<SpriteRenderer>().enabled = false;
        additionalTargets[1].GetComponent<SpriteRenderer>().enabled = false;
        additionalTargets[2].GetComponent<SpriteRenderer>().enabled = true;
    }
}

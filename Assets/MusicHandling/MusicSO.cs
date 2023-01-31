using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Music")]
public class MusicSO : ScriptableObject
{
    public int phase = 0;
    public int layer = 0;

    public int BPM = 140;

    public int[] phaseLayerCount = new int[4] { 6, 9, 12, 13 };

    public void IncreasePhase()
    {
        phase++;
    }

    public void IncreaseLayer()
    {
        layer++;
        if (layer >= phaseLayerCount[phase] && phaseLayerCount[phase] != 13)
        {
            IncreasePhase();
        }
    }
}

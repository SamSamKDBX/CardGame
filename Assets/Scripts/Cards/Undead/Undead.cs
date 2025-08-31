using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Undead : CharacterCard
{
    protected override void Play()
    {
        Debug.Log("Play " + name);
    }

    // Skills :
    // LVL1
    private void ForceDuNombre()
    {
        // s'exécute à chaque frame. (ou chaque fois qu'on pose une carte)
        // + 100 PB pour chaque mort-vivant sur le terrain.
        //hpMax += GetNbCarteIngame("Undead");
    }
}

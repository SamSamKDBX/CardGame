using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Undead : CharacterCard
{
    public override void Play()
    {
        Debug.Log("Play " + name);
        // 1 : demander quelles cartes sacrifier
        // 2 : sacrifier les cartes après validation
        // 3 : poser la carte à l'emplacement choisi
        // 4 : appliquer les effets potentiels 
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

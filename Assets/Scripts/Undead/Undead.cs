using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Undead : CharacterCard
{
    public override void Play()
    {
        Debug.Log("Play " + name);
    }
}

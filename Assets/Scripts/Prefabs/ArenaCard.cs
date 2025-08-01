using UnityEngine;

public class ArenaCard : Card
{
    public override void Play()
    {
        Debug.Log("Play " + name);
    }
}

using UnityEngine;

public class ArenaCard : Card
{
    protected override void Play()
    {
        Debug.Log("Play " + name);
    }
}

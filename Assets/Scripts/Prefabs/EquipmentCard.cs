using UnityEngine;

public class EquipmentCard : Card
{
    protected string Effect;
    protected override void Play()
    {
        Debug.Log("Play " + name);
    }
}

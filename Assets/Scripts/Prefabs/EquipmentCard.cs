using UnityEngine;

public class EquipmentCard : Card
{
    protected string Effect;
    public override void Play()
    {
        Debug.Log("Play " + name);
    }
}

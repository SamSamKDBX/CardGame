// doit être un composant de "CardsCanvas"

using System.Collections.Generic;
using UnityEngine;

public class Places : MonoBehaviour
{
    protected Dictionary<string, Transform> cardPlaces;
    protected virtual void Awake()
    {
        cardPlaces = new Dictionary<string, Transform>
        {
            {"FRONT", transform.Find("FrontCardPlace")?.transform},
            {"DECK", transform.Find("DeckPlace")?.transform},
            {"TRASH", transform.Find("TrashPlace")?.transform},
            {"SUPER_DECK", transform.Find("SuperDeckPlace")?.transform},
            {"UNKNOWN", transform.Find("UnknownPlace")?.transform},
            {"DEF1", transform.Find("DefPlace1")?.transform},
            {"DEF2", transform.Find("DefPlace2")?.transform},
            {"DEF3", transform.Find("DefPlace3")?.transform},
            {"ATK1", transform.Find("AtkPlace1")?.transform},
            {"ATK2", transform.Find("AtkPlace2")?.transform},
            {"ATK3", transform.Find("AtkPlace3")?.transform},
            {"ATK4", transform.Find("AtkPlace4")?.transform},
            {"HAND", transform.Find("HandPlace")?.transform},
        };
    }

    public Transform Get(string place)
    {
        return cardPlaces[place];
    }
}
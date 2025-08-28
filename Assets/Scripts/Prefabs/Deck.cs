using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<Card> cards;

    public void SetAllCards(List<Card> _cards)
    {
        cards = _cards;
    }

    public List<Card> GetAllCards()
    {
        return cards;
    }
}
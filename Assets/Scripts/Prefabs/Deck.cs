using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<Card> cards;

    public void SetAllCards(List<Card> _cards)
    {
        cards = _cards;
        ShowAllBack();
    }

    public List<Card> GetAllCards()
    {
        return cards;
    }

    public void Shuffle()
    {
        // mélanger
    }

    [ContextMenu("ShowAllBack")]
    public void ShowAllBack()
    {
        cards.ForEach(card => card.ShowBack());
    }

    [ContextMenu("ShowAllFront")]
    public void ShowAllfront()
    {
        cards.ForEach(card => card.ShowFront());
    }
}
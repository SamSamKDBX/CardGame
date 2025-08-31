using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<Card> cards;
    private List<Card> ingameCards;

    protected virtual void Awake()
    {
        ingameCards = new List<Card>();
        
        // on récupère la liste des cartes du deck
        cards = new List<Card>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform card = transform.GetChild(i);
            cards.Add(card.GetComponent<Card>());
        }
    }

    public void SetAllCards(List<Card> _cards)
    {
        cards = _cards;
        ShowAllBack();
    }

    public void AddIngameCard(Card card)
    {
        ingameCards.Add(card);
        cards.Remove(card);
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
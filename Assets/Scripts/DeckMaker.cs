using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DeckMaker : MonoBehaviour
{
    [SerializeField] private Card undead;
    [SerializeField] private Card necromancer;
    [SerializeField] private Card bloodyCemetery;
    [SerializeField] private Deck deck;

    [ContextMenu("Créer un deck")]
    public void Make()
    {
        // nouvelle liste de cartes
        List<Card> cards = new List<Card>();

        // on ajoute les cartes qu'on veut à la liste
        for (int i = 0; i < 30; i++)
        {
            Card instance = Instantiate(undead, deck.transform);
            instance.name = "Undead";
            cards.Add(instance);
            if (i < 20)
            {
                instance = Instantiate(necromancer, deck.transform);
                instance.name = "Necromancer";
                cards.Add(instance);
            }
            if (i < 10)
            {
                instance = Instantiate(bloodyCemetery, deck.transform);
                instance.name = "BloodyCemetery";
                cards.Add(instance);
            }
        }

        // on ajoute les cartes au deck
        deck.SetAllCards(cards);
    }

    [ContextMenu("Afficher les cartes du deck dans la console")]
    public void ShowDeck()
    {
        Debug.Log("Affichage des cartes");
        foreach (Card card in deck.GetAllCards())
        {
            Debug.Log(card.name);
        }
    }

    [ContextMenu("Supprimer toutes les cartes du deck")]
    public void ClearDeck()
    {
        foreach (Card card in deck.GetAllCards())
        {
            DestroyImmediate(card.gameObject);
        }
        deck.SetAllCards(new List<Card>());
    }
}
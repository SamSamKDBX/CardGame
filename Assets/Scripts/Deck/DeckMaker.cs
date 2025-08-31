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
        // on vide le deck
        ClearDeck();

        // nouvelle liste de cartes
        List<Card> cards = new List<Card>();

        // on ajoute les cartes qu'on veut à la liste
        for (int i = 0; i < 60; i++)
        {
            Card instance;
            if (i >= 30)
            {
                instance = Instantiate(undead, deck.transform);
                instance.name = "Undead";
                cards.Add(instance);
            }
            else if (i < 30 && i >= 10)
            {
                instance = Instantiate(necromancer, deck.transform);
                instance.name = "Necromancer";
                cards.Add(instance);
            }
            else if (i < 10)
            {
                instance = Instantiate(bloodyCemetery, deck.transform);
                instance.name = "BloodyCemetery";
                cards.Add(instance);
            }
            else
            {
                return;
            }
            instance.transform.localPosition = Vector3.zero + new Vector3(0, 0, i);
        }
        // on tri les cartes par nom
        cards.Sort((a, b) => string.Compare(a.name, b.name));

        // on ajoute les cartes au deck
        deck.SetAllCards(cards);
    }

    [ContextMenu("Afficher la liste des cartes dans la console")]
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
        while (transform.childCount > 0)
        {
            Transform card = transform.GetChild(0);
            DestroyImmediate(card.gameObject);
        }
        deck.SetAllCards(new List<Card>());
    }
}
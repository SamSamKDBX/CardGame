using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Player opponentPlayer;
    private Deck deck; // deck du joueur
    private Deck opponentDeck; // deck de l'adversaire
    private List<Card> hand;
    protected Places cardPlaces;

    protected virtual void Start()
    {
        // on récupère la liste des places de cartes possibles
        cardPlaces = GameObject.Find("CardsCanvas").GetComponent<Places>();

        // (récupérer les decks de chaque joueur.)
        if (player == null)
        {
            Debug.Log("player is null");
            return;
        }
        if (opponentPlayer == null)
        {
            Debug.Log("opponentPlayer is null");
            return;
        }
        deck = player.GetDeck();
        opponentDeck = opponentPlayer.GetDeck();

        // TODO
        // 1 : Mélanger les deck
        // 2 : faire piocher une main (a voir pour les cas ou il n'y a pas de carte à poser)

        // on créer une main
        hand = new List<Card>();
        StartCoroutine(DrawFromDeck(8)); // ⚠️ on lance en coroutine
    }

    // piocher un nombre de carte et les ajouter à la main
    public IEnumerator DrawFromDeck(int nbOfCards)
    {
        // on pioche les cartes une par une
        for (int i = 0; i < nbOfCards; i++)
        {
            // TODO : les skills ne doivent pas s'afficher en main
            Card drawnCard = deck.GetAllCards().Last();
            // on ajoute la carte à la liste des cartes en main
            hand.Add(drawnCard);
            // on indique au deck qu'elle est en jeu
            deck.AddIngameCard(drawnCard);

            // on bouge la carte de place
            yield return StartCoroutine(drawnCard.ChangePlaceCoroutine(cardPlaces.Get("HAND")));

            // petit délai optionnel pour l'effet visuel (0.1–0.2s)
            yield return new WaitForSeconds(0.15f);

            UpdateHandLayout();
            // TODO : trier la main
        }
    }

    private void UpdateHandLayout()
    {
        float cardSpacing = 100f; // distance entre cartes
        for (int i = 0; i < hand.Count; i++)
        {
            Vector3 targetPos = new Vector3(i * cardSpacing, 0, 0);
            hand[i].transform.localPosition = targetPos;
        }
    }
}
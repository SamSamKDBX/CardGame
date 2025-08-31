using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Player opponentPlayer;
    private Deck deck; // deck du joueur
    private Deck opponentDeck; // deck de l'adversaire
    void Start()
    {
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

        // 1 : Mélanger les deck
        // 2 : faire piocher une main (a voir pour les cas ou il n'y a pas de carte à poser)
        // 3 : faire poser au moins une carte à chacun
        // 4 : 
    }
}
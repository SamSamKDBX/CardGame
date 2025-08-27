using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    private Player player;
    private Player opponentPlayer;
    private Deck deck; // deck du joueur
    private Deck opponentDeck; // deck de l'adversaire
    void Start()
    {
        // récupérer les joueurs
        //player = GameObject.Find("Player");
        // (récupérer les decks de chaque joueur.)
        this.deck = FindAnyObjectByType<Player>().GetDeck();

        // 1 : Mélanger les deck
        // 2 : faire piocher une main (a voir pour les cas ou il n'y a pas de carte à poser)
        // 3 : faire poser au moins une carte à chacun
        // 4 : 
    }
}
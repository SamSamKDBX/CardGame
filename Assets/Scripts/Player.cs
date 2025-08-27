using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly string pseudo;
    private readonly Side side;
    [SerializeField] private Deck deckObject;
    private Deck deck;

    void Start()
    {
        deck = deckObject.GetDeck();
    }

    public Deck GetDeck()
    {
        return this.deck;
    }
}
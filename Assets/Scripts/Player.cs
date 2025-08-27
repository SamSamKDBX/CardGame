using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly string pseudo;
    private readonly Side side;
    [SerializeField] private Deck deck;

    public Deck GetDeck()
    {
        return this.deck;
    }
}
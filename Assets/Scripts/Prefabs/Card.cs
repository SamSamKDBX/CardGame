using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    protected Transform lastParent;

    protected Places cardPlaces;

    private bool isFrontShowed;

    protected virtual void Awake()
    {
        isFrontShowed = true;
        cardPlaces = GameObject.Find("CardsCanvas").GetComponent<Places>();
    }

    protected abstract void Play();

    [ContextMenu("ShowFront")]
    public void ShowFront()
    {
        transform.Find("Front").gameObject.SetActive(true);
        transform.Find("Back").gameObject.SetActive(false);
        isFrontShowed = true;
    }

    [ContextMenu("ShowBack")]
    public void ShowBack()
    {
        transform.Find("Front").gameObject.SetActive(false);
        transform.Find("Back").gameObject.SetActive(true);
        isFrontShowed = false;
    }

    [ContextMenu("GoToFrontPlace")]
    protected void GoToFrontPlace()
    {
        ChangePlace(cardPlaces.Get("FRONT"));
    }

    [ContextMenu("GoToDeck")]
    protected void GoToDeck()
    {
        ChangePlace(cardPlaces.Get("DECK"));
    }

    [ContextMenu("GoToLastPlace")]
    protected void GoToLastPlace()
    {
        ChangePlace(lastParent);
    }

    public void ChangePlace(Transform place)
    {
        // on récupère la position actuelle pour y revenir potentiellement.
        lastParent = transform.parent;

        // Animation du déplacement
        StartCoroutine(MoveToPosition(place.position, 0.5f)); // 0.5s de déplacement

        // on change de position
        transform.SetParent(place, false);

        // si la carte va dans le deck ou le super deck, on la retourne
        if (place == cardPlaces.Get("DECK") || place == cardPlaces.Get("SUPER_DECK"))
        {
            Debug.Log("ShowBack");
            ShowBack();
        }
        else
        {
            Debug.Log("ShowFront");
            ShowFront();
        }

        // si on se retrouve en position de visualisation, on affiche les compétences
        if (place == cardPlaces.Get("FRONT") && this is CharacterCard)
        {
            Debug.Log("ShowSkills");
            ShowSkills();
        }
        else
        {
            Debug.Log("HideSkills");
            HideSkills();
        }
    }

    // animation de mouvement de la carte
    private IEnumerator MoveToPosition(Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    protected virtual void ShowSkills() { }
    protected virtual void HideSkills() { }
}
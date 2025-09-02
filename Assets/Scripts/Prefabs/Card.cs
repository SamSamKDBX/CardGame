using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    protected Transform lastParent;

    protected Places cardPlaces;
    [SerializeField]
    protected GameObject emptyPlace;

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
        StartCoroutine(ChangePlaceCoroutine(place));
    }

    public IEnumerator ChangePlaceCoroutine(Transform place)
    {
        // on récupère la position actuelle pour y revenir potentiellement.
        lastParent = transform.parent;

        // on récupère la position dans la main qui est libre
        GameObject tempEmptyPlace = Instantiate(emptyPlace, place, false);

        // On stocke la position cible
        Vector3 targetPos = tempEmptyPlace.transform.position;
        targetPos = new Vector3(targetPos.x, targetPos.y, targetPos.z + 50);

        // On anime la carte vers la position
        Coroutine move = StartCoroutine(MoveToPosition(targetPos, 1f));
        Coroutine flip = StartCoroutine(FlipCard(true, 1f));

        yield return move;
        yield return flip;

        // Animation du déplacement
        //StartCoroutine(MoveToPosition(tempEmptyPlace.transform.position, 1));

        // supprimer l'objet temporaire
        Destroy(tempEmptyPlace);

        // on change de position
        transform.SetParent(place, false);
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);

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

    public IEnumerator FlipCard(bool showFront, float duration = 0.5f)
    {
        float elapsed = 0f;
        Quaternion startRot = transform.rotation;
        Quaternion halfRot = Quaternion.Euler(0, 90, 0);
        Quaternion endRot = Quaternion.Euler(0, 180, 0);

        while (elapsed < duration / 2f)
        {
            transform.rotation = Quaternion.Slerp(startRot, halfRot, elapsed / (duration / 2f));
            elapsed += Time.deltaTime;
            yield return null;
        }

        // On bascule le visuel à mi-tour
        if (showFront)
        {
            ShowFront();
        }
        else
        {
            ShowBack();
        }

        elapsed = 0f;
        while (elapsed < duration / 2f)
        {
            transform.rotation = Quaternion.Slerp(halfRot, endRot, elapsed / (duration / 2f));
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = Quaternion.identity;
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
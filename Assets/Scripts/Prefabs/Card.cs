using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    protected Transform lastParent;

    protected Dictionary<string, Transform> cardPlaces;

    private bool isFrontShowed;

    protected virtual void Awake()
    {
        isFrontShowed = true;
        cardPlaces = new Dictionary<string, Transform>
        {
            {"FRONT", GameObject.Find("FrontCardPlace")?.transform},
            {"DECK", GameObject.Find("DeckPlace")?.transform},
            {"TRASH", GameObject.Find("TrashPlace")?.transform},
            {"SUPER_DECK", GameObject.Find("SuperDeckPlace")?.transform},
            {"SUPER_TRASH", GameObject.Find("SuperTrashPlace")?.transform},
            {"DEF1", GameObject.Find("DefPlace1")?.transform},
            {"DEF2", GameObject.Find("DefPlace2")?.transform},
            {"DEF3", GameObject.Find("DefPlace3")?.transform},
            {"ATK1", GameObject.Find("AtkPlace1")?.transform},
            {"ATK2", GameObject.Find("AtkPlace2")?.transform},
            {"ATK3", GameObject.Find("AtkPlace3")?.transform},
            {"ATK4", GameObject.Find("AtkPlace4")?.transform},
        };
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
        ChangePlace(cardPlaces["FRONT"]);
    }

    [ContextMenu("GoToDeck")]
    protected void GoToDeck()
    {
        ChangePlace(cardPlaces["DECK"]);
        ShowBack();
    }

    protected void ChangePlace(Transform place)
    {
        // si la carte n'est plus sur visualisation, on cache les compétences
        if (lastParent == cardPlaces["FRONT"] && this is CharacterCard)
        {
            HideSkills();
        }

        // on récupère la position actuelle pour y revenir potentiellement.
        lastParent = transform.parent;

        // Animation du déplacement
        StartCoroutine(MoveToPosition(place.position, 0.5f)); // 0.5s de déplacement

        // on change de position
        transform.SetParent(place, false);

        // si la carte va dans le deck ou le super deck, on la retourne
        if (transform.parent == cardPlaces["DECK"] || transform.parent == cardPlaces["SUPER_DECK"])
        {
            ShowBack();
        }
        else
        {
            ShowFront();
        }

        // si on se retrouve en position de visualisation, on affiche les compétences
        if (place == cardPlaces["FRONT"] && this is CharacterCard)
        {
            ShowSkills();
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

    [ContextMenu("GoToLastPlace")]
    protected void GoToLastPlace()
    {
        ChangePlace(lastParent);
    }

    protected virtual void ShowSkills() { }
    protected virtual void HideSkills() { }
}
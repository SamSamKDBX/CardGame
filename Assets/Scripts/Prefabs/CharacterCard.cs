using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class CharacterCard : Card
{
    [SerializeField] private int invocationPrice;
    [SerializeField] protected int hpMax;
    private int currentHP;
    private int currentSP; // Shield Points
    private LVL currentLVL;
    protected readonly List<Skill> Skills = new List<Skill>(6);

    protected TextMeshProUGUI hpText;

    public void LevelUp()
    {
        Debug.Log("Level Up for " + name);
        // afficher une animation
        // mettre à jour le niveau
        if (currentLVL < LVL.LVL3)
        {
            currentLVL++;
        }
    }

    public override void Play()
    {
        Debug.Log("Play " + name);
        // 1 : demander quelles cartes sacrifier
        // 2 : sacrifier les cartes après validation
        // 3 : poser la carte à l'emplacement choisi
        // 4 : appliquer les effets potentiels 
    }

    private void Select()
    {
        // avancer la carte de la caméra
        // afficher les compétences cachées
        if (currentLVL >= LVL.LVL2)
        {
            transform.Find("SkillsLVL2").gameObject.SetActive(true);
        }
        if (currentLVL == LVL.LVL3)
        {
            transform.Find("SkillsLVL3").gameObject.SetActive(true);
        }
    }

    protected virtual void Awake()
    {
        // récupération des pv sur le composant de la carte.
        SetAttributes();
    }

    private void SetAttributes()
    {
        // on récupère le texte des HP
        var tmps = GetComponentsInChildren<TextMeshProUGUI>(true);
        foreach (var tmp in tmps)
        {
            //Debug.Log("found : " + tmp.name);
            if (tmp.name == "HP")
            {
                hpText = tmp;
                break;
            }
        }

        // on gere les erreurs si le text est invalide
        if (hpText == null)
            Debug.LogWarning($"{name} : Aucun TextMeshProUGUI trouvé pour afficher les PV.");

        if (hpMax <= 0)
            Debug.LogError($"{name} : HPMax n'est pas initialisé !");
        if (invocationPrice < 0)
            Debug.LogError($"{name} : InvocationPrice n'est pas initialisé !");

        // on set les attributs
        currentHP = hpMax;
        currentSP = 0;
        currentLVL = LVL.LVL1;
        // on update le text HP
        UpdateHPText();
    }

    // mise à jour du text de la carte en fonction du nombre réel d'HP
    protected void UpdateHPText()
    {
        if (hpText != null)
            hpText.text = currentHP.ToString();
    }
}

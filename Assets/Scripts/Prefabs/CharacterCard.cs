using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterCard : Card
{
    [SerializeField] private int invocationPrice;
    [SerializeField] protected int hpMax;
    private int currentHP;
    private int currentSP; // Shield Points
    private LVL currentLVL;
    protected readonly List<Skill> Skills = new List<Skill>(6);
    private GameObject SkillsLVL2;
    private GameObject SkillsLVL3;

    protected TextMeshProUGUI hpText;

    [ContextMenu("LevelUp")]
    public void LevelUp()
    {
        // afficher une animation
        // mettre à jour le niveau
        if (currentLVL < LVL.LVL3)
        {
            currentLVL++;
        }
        Debug.Log("Level Up for " + name + " " + currentLVL);
    }

    [ContextMenu("ResetLevel")]
    public void ResetLevel()
    {
        currentLVL = LVL.LVL1;
    }

    [ContextMenu("ShowLevel")]
    public void ShowLevel()
    {
        Debug.Log("LVL = " + currentLVL);
    }

    protected override void ShowSkills()
    {
        if (currentLVL >= LVL.LVL2)
        {
            SkillsLVL2.SetActive(true);
        }
        else
        {
            SkillsLVL2.SetActive(false);
        }
        if (currentLVL == LVL.LVL3)
        {
            SkillsLVL3.SetActive(true);
        }
        else
        {
            SkillsLVL3.SetActive(false);
        }
    }

    protected override void HideSkills()
    {
        SkillsLVL2.SetActive(true);
        SkillsLVL3.SetActive(true);
    }

    protected override void Play()
    {
        Debug.Log("Play " + name);
        // 1 : demander quelles cartes sacrifier
        // 2 : sacrifier les cartes après validation
        // 3 : poser la carte à l'emplacement choisi
        // 4 : appliquer les effets potentiels 
    }

    protected override void Awake()
    {
        base.Awake();
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

        // on récupère les gameobject des skills
        SkillsLVL2 = transform.GetChild(0).GetChild(7).gameObject;
        SkillsLVL3 = transform.GetChild(0).GetChild(8).gameObject;

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

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class CharacterCard : Card
{
    [SerializeField] private int invocationPrice;
    [SerializeField] private int hpMax;
    private int currentHP;
    private int currentSP; // Shield Points
    private LVL currentLVL;
    protected readonly List<Skill> Skills = new List<Skill>(6);

    protected TextMeshProUGUI hpText;

    public override void Play()
    {
        Debug.Log("Play " + name);
    }

    protected virtual void Awake()
    {
        var tmps = GetComponentsInChildren<TextMeshProUGUI>(true);
        foreach (var tmp in tmps)
        {
            Debug.Log("found : " + tmp.name);
            if (tmp.name == "HP")
            {
                hpText = tmp;
                break;
            }
        }

        if (hpText == null)
            Debug.LogWarning($"{name} : Aucun TextMeshProUGUI trouvé pour afficher les PV.");

        if (hpMax <= 0)
            Debug.LogError($"{name} : HPMax n'est pas initialisé !");
        if (invocationPrice < 0)
            Debug.LogError($"{name} : InvocationPrice n'est pas initialisé !");

        currentHP = hpMax;
        currentSP = 0;
        currentLVL = LVL.LVL1;
        UpdateHPText();
    }

    protected void UpdateHPText()
    {
        if (hpText != null)
            hpText.text = currentHP.ToString();
    }
}

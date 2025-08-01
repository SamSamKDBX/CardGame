using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] private int demages;
    [SerializeField] private int executionPrice;
    public abstract void Execute();
}
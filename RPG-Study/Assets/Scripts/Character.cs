using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterType characterType;
    [SerializeField] private string nameCharacter;
    [SerializeField] private int baseHealth;
    [SerializeField] private int baseAttack;
    [SerializeField] private int baseShield;
    [SerializeField] private int baseAgility;

    [SerializeField] private int maxHealth;

    [SerializeField] private int currentHealth;
    [SerializeField] private int currentShield;
    [SerializeField] private int currentAttack;
    [SerializeField] private int currentAgility;

    public string NameCharacter
    {
        get { return nameCharacter; }
    }

    public int MaxHealth
    {
        get {return this.maxHealth;}
    }

    public int CurrentHealth
    {
        get {return this.currentHealth;}
    }

    public int CurrentShield
    {
        get {return this.currentShield;}
    }

    public int CurrentAttack
    {
        get {return this.currentAttack;}
    }

    public int CurrentAgility
    {
        get { return currentAgility; }
    }

    // Actions
    public void Attack()
    {
        
    }

}

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CombatController : MonoBehaviour
{

    [SerializeField] private List<Character> players;
    [SerializeField] private Character currentPlayer;
    [SerializeField] private List<Character> enemies;
    [SerializeField] private List<Character> actionQueue = new();

    private struct InitiativeEntry
    {
        public Character character;
        public int initiativeValue;
    }

    [Header("Selection")]
    [SerializeField] private CombatSelect combatSelect = CombatSelect.None;
    [SerializeField] private GameObject selectArrow;
    [SerializeField] private int enemyIndexSelection = 0;
    [SerializeField] private int playerIndexSelection = 0;

    void Start()
    {
        InitCombat();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)) ChangeCombatSelect(CombatSelect.SelectingEnemy);
        if(Input.GetKeyDown(KeyCode.O)) ChangeCombatSelect(CombatSelect.None);
        if(Input.GetKeyDown(KeyCode.P)) ChangeCombatSelect(CombatSelect.SelectingAlly);

        if(combatSelect == CombatSelect.SelectingEnemy)
        {
            if(Input.GetKeyDown(KeyCode.A)) PreviousEnemy();
            if(Input.GetKeyDown(KeyCode.D)) NextEnemy();
        }
        else if(combatSelect == CombatSelect.SelectingAlly)
        {
            if(Input.GetKeyDown(KeyCode.A)) PreviousAlly();
            if(Input.GetKeyDown(KeyCode.D)) NextAlly();
        }
    }

    private void InitCombat()
    {
        ChangeCombatSelect(CombatSelect.None);
        DetermineTurnOrder();
        UpdateCanvasPlayer();
    }

    private void UpdateCanvasPlayer()
    {
        
        foreach(Character player in players)
        {
            if(player.NameCharacter != players[playerIndexSelection].NameCharacter)
            {
                player.gameObject.SetActive(false);
            }
            else
            {
                player.gameObject.SetActive(true);
            }
        }
        CombatEvents.Instance.CurrentPlayerSelected(players[playerIndexSelection]);
    }

    private void ChangeCombatSelect(CombatSelect cs)
    {
        combatSelect = cs;
        switch (combatSelect)
        {
            case CombatSelect.SelectingEnemy:
                selectArrow.GetComponent<SpriteRenderer>().enabled = true;
                enemyIndexSelection = 0;
                UpdateArrow();
                break;

            case CombatSelect.None:
                selectArrow.GetComponent<SpriteRenderer>().enabled = false;
                break;

            case CombatSelect.SelectingAlly:
                selectArrow.GetComponent<SpriteRenderer>().enabled = false;
                break;
            
            default:
                break;
        }

    }

    private void NextEnemy()
    {
        enemyIndexSelection++;
        if(enemyIndexSelection >= enemies.Count) enemyIndexSelection = 0;
        UpdateArrow();
    }

    private void PreviousEnemy()
    {
        enemyIndexSelection--;
        if(enemyIndexSelection < 0) enemyIndexSelection = enemies.Count-1;
        UpdateArrow();
    }
    private void NextAlly()
    {
        playerIndexSelection++;
        if(playerIndexSelection >= players.Count) playerIndexSelection = 0;
        UpdateCanvasPlayer();
    }

    private void PreviousAlly()
    {
        playerIndexSelection--;
        if(playerIndexSelection < 0) playerIndexSelection = players.Count-1;
        UpdateCanvasPlayer();
    }

    private void UpdateArrow()
    {
        selectArrow.transform.position = enemies[enemyIndexSelection].GetComponent<CharacterAnimationController>().SelectPosistion.position;
        // CombatEvents.Instance.CurrentPlayerSelected(currentPlayer);
        CombatEvents.Instance.CurrentEnemySelected(enemies[enemyIndexSelection]);
    }

    public void DetermineTurnOrder()
    {
        List<Character> allCombatants = new List<Character>();
        allCombatants.AddRange(players);
        allCombatants.AddRange(enemies);
        
        List<InitiativeEntry> initiativeList = new List<InitiativeEntry>();

        foreach (Character combatant in allCombatants)
        {
            int d20Roll = Random.Range(1, 21); 
            
            int totalInitiative = combatant.CurrentAgility + d20Roll; 

            initiativeList.Add(new InitiativeEntry
            {
                character = combatant,
                initiativeValue = totalInitiative
            });
        }

        // 3. Ordenar os personagens pelo valor de Iniciativa (do maior para o menor)
        List<Character> orderedCharacters = initiativeList
            .OrderByDescending(entry => entry.initiativeValue)
            .Select(entry => entry.character)
            .ToList();

        // 4. Armazenar o resultado na actionQueue
        actionQueue = orderedCharacters;
    }

}

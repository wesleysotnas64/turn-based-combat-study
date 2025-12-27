using UnityEngine;
using TMPro;

public class EnemyInfoCanvasController : MonoBehaviour
{
    [SerializeField] private TMP_Text textName;
    [SerializeField] private TMP_Text textHP;
    [SerializeField] private TMP_Text textShield;
    
    void Start()
    {
        CombatEvents.Instance.OnCurrentEnemySelected += UpdateEnemyInfoCanvas;
    }

    private void UpdateEnemyInfoCanvas(Character currentEnemy)
    {
        textName.text = currentEnemy.NameCharacter;
        textHP.text = $"HP {currentEnemy.CurrentHealth}/{currentEnemy.MaxHealth}";
        textShield.text = $"Shield {currentEnemy.CurrentShield}";
    }
}

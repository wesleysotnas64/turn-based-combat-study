using UnityEngine;
using TMPro;

public class PlayerInfoCanvasController : MonoBehaviour
{
    [SerializeField] private TMP_Text textName;
    [SerializeField] private TMP_Text textHP;
    [SerializeField] private TMP_Text textAttack;
    [SerializeField] private TMP_Text textShield;
    [SerializeField] private TMP_Text textAgility;
    [SerializeField] private TMP_Text textIntelligence;

    void Start()
    {
        CombatEvents.Instance.OnCurrentPlayerSelected += UpdatePlayerInfoCanvas;
    }

    private void UpdatePlayerInfoCanvas(Character currentPlayer)
    {
        textName.text = currentPlayer.NameCharacter;
        textHP.text = $"HP {currentPlayer.CurrentHealth}/{currentPlayer.MaxHealth}";
        textAttack.text = $"Attack {currentPlayer.CurrentAttack}";
        textShield.text = $"Shield {currentPlayer.CurrentShield}";
        textAgility.text = $"Agility {currentPlayer.CurrentAgility}";
        textIntelligence.text = $"Intelligence {currentPlayer.CurrentIntelligence}";
    }
    
}

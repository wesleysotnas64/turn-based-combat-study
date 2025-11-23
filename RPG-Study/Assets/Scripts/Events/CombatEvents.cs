using System;
using UnityEngine;

public class CombatEvents : MonoBehaviour
{
    //Singleton para os eventos do combate
    public static CombatEvents Instance;

    private void Awake() => Instance = this;

    public event Action<Character> OnCurrentPlayerSelected;
    public void CurrentPlayerSelected(Character currentPlayer) => OnCurrentPlayerSelected?.Invoke(currentPlayer); //Aciona o evento somente se houver inscritos
    
}

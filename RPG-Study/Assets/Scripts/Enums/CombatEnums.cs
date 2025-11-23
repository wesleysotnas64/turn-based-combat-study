public enum CombatSelect
{
    // O combate está ativo, mas a UI não está focada em seleção (e.g., mostrando texto de ação)
    None,

    // O jogador deve escolher um aliado como alvo (e.g., para cura ou buff)
    SelectingAlly,

    // O jogador deve escolher um inimigo como alvo (e.g., para ataque ou debuff)
    SelectingEnemy,

    // Nenhuma seleção de alvo é necessária (e.g., usando um ataque que afeta todos)
    ActionConfirmed 
}
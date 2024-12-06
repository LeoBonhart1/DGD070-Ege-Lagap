using Entitas;
using UnityEngine;

public class CheckPlayerHealthSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _playerHealthGroup;

    public CheckPlayerHealthSystem(Contexts contexts)
    {
        _playerHealthGroup = contexts.game.GetGroup(GameMatcher.PlayerHealth);
    }

    public void Execute()
    {
        foreach (var entity in _playerHealthGroup.GetEntities())
        {
            if (entity.isPlayerDamaged)
            {
                entity.ReplacePlayerHealth(Mathf.Max(0, entity.playerHealth.Value - 10));
                entity.isPlayerDamaged = false; // Clear the tag component
            }

            if (entity.isPlayerHealed)
            {
                entity.ReplacePlayerHealth(Mathf.Min(100, entity.playerHealth.Value + 10));
                entity.isPlayerHealed = false; // Clear the tag component
            }
        }
    }
}
using Entitas;
using UnityEngine;

public class ChangePlayerHealthSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _playerHealthGroup;

    public ChangePlayerHealthSystem(Contexts contexts)
    {
        _playerHealthGroup = contexts.game.GetGroup(GameMatcher.PlayerHealth);
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (var entity in _playerHealthGroup.GetEntities())
            {
                entity.isPlayerDamaged = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            foreach (var entity in _playerHealthGroup.GetEntities())
            {
                entity.isPlayerHealed = true;
            }
        }
    }
}

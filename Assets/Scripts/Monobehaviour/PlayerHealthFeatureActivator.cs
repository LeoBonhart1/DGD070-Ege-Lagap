using Entitas;
using Entitas.Unity;
using UnityEngine;

public class PlayerHealthFeatureActivator : MonoBehaviour
{
    private Systems _systems;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        _systems = new PlayerHealthFeature(contexts);

        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}

using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class ECSConnect : MonoBehaviour
{
   
    private EcsWorld _ecsWorld;
   
    private EcsSystems _systems;
    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _systems = new EcsSystems(_ecsWorld);


        AddInjections();
        AddOneFrames();
        AddSystems();

        _systems.ConvertScene();
        _systems.Init();

    }

    private void Update()
    {
        _systems.Run();
    }

    private void AddInjections()
    {

    }
    private void AddSystems()
    {
        _systems.Add(new PlayParticlesSystem());
    }


    private void AddOneFrames()
    {

    }
    private void OnDestroy()
    {
        _systems?.Destroy();
        _systems = null;
        _ecsWorld?.Destroy();
        _ecsWorld = null;
    }
}

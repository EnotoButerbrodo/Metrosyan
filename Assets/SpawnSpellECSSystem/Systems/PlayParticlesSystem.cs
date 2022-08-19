using UnityEngine;
using Voody.UniLeo;
using Leopotam.Ecs;
public class PlayParticlesSystem : IEcsRunSystem
{

    private readonly EcsWorld _world = null;
    private readonly EcsFilter<GolemTag,StartingParticlesComponent,ParticlesTransform> _creatParticlesFilter = null;
    public void Run()
    {
        foreach (var i in _creatParticlesFilter)
        {
            ref var entity = ref _creatParticlesFilter.GetEntity(i);
            ref var particles = ref _creatParticlesFilter.Get2(i);
            ref var transfromPart = ref _creatParticlesFilter.Get3(i);

            if(entity != null)
            {
                var partTemp = Object.Instantiate(particles._particle,transfromPart.ParticlesPosition.position,Quaternion.identity) as GameObject;
                partTemp.GetComponent<ParticleSystem>().Play();
                if(!partTemp.GetComponent<ParticleSystem>().IsAlive())
                {
                    
                }      
                Object.Destroy(partTemp,1f);
                entity.Del<StartingParticlesComponent>();
            }

        }
    }
}

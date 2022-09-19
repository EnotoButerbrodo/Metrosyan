
using System;

public class InstantCastInitial : SpellCastInitialHandler
{
    //При нажатии на слот моментально применить скилл по позиции курсора
    public override event Action CastStarted;

    public override event Action Initialized;

    public override void InitialCast()
    {
        CastStarted?.Invoke();
        Initialized?.Invoke();
    }

    public override void Disable()
    {
        
    }

}


using System;


/*Цепочка каста
 *  Начало каста
 *  Процесс каста
 *  Завершение каста
    При выборе слота создается эта цепочка. Начальный блок подписывается на эвент
    выбора слота. Затем на него подписываются другие этапы исходя из 
 * */

public abstract class SpellCastInitialHandler
{
    //Этот метод подписывается на событие, которое должно начать каст
    public abstract void InitialCast();

    //Безопасно отключить компонент
    public abstract void Disable();

    //Событие, когда каст начинается

    public abstract event Action CastStarted;

    //Вызывает, когда завершает свою работу.

    public abstract event Action Initialized;
    
}

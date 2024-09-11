using UnityEngine;

namespace _Construction.Scripts.Game
{
    public class SomeCommonService
    {
        // Например провайдер состояния, или провайдер настроек, сервис аналитики, платежки - чего угодно
        public SomeCommonService()
        {
            Debug.Log(GetType().Name + " has been created");
        }
    }
}

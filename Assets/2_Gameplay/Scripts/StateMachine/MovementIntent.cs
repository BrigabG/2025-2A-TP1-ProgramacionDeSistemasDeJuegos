using UnityEngine;

namespace Gameplay
{
    public class MovementIntent
    {
     public enum IntentType
            {
                None,
                WantToJump,
                Landed,
                //...
            }
    
            public IntentType Type { get; }
            public object Data { get; }
            
            public static MovementIntent NoneIntent => new MovementIntent(IntentType.None);
    
            public MovementIntent(IntentType type, object data = null)
            {
                Type = type;
                Data = data;
            }
    }
}

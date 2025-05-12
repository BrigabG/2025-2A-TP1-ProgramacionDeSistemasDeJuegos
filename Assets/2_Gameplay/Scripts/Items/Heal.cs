using Excercise1;
using UnityEngine;

namespace Gameplay
{
    public class Heal : MonoBehaviour, IInteractable
    {
        public void Interact(IInteractor target)
        {
            Debug.Log($"{name}({nameof(Heal).Colored("#555555")}): Healed {target.transform.name} :)");
            gameObject.SetActive(false);
        }
    }
}
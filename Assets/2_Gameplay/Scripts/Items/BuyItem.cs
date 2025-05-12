using Excercise1;
using UnityEngine;

namespace Gameplay
{
    public class BuyItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private string itemName;
        public void Interact(IInteractor target)
        {
            Debug.Log($"{name}({nameof(Heal).Colored("#555555")}): {target.transform.name} now has item {itemName}");
            gameObject.SetActive(false);
        }
    }
}
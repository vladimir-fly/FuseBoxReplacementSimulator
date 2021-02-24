using UnityEngine;

namespace FBRS.Bases
{
    public abstract class SelectorBase<T> : MonoBehaviour
    {
        public ESelectorTypeId TypeId;
        public abstract T Toggle();
        public abstract bool TryToggle();
    }
}
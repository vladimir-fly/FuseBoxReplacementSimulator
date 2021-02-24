using System;
using UnityEngine;

namespace FBRS.Bases
{
    public abstract class BinarySelector : SelectorBase<bool>
    {
        [SerializeField] protected bool Value;
        public Action<bool> OnToggle;
        public Func<bool, bool> Check;

        public override bool Toggle()
        {
            Value = !Value;
            OnToggle?.Invoke(Value);
            return Value;
        }

        public override bool TryToggle()
        {
            var toggledValue = !Value;
            if (Check != null && (bool) Check?.Invoke(toggledValue))
                Toggle();
            return false;
        }
    }
}
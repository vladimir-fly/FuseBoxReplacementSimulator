using System;
using FBRS.Bases;

namespace FBRS.DataTypes
{
    /// <summary>
    /// Scenario step
    /// </summary>
    [Serializable]
    public class Step
    {
        public readonly string SelectorId;
        public ESelectorTypeId SelectorTypeId;
        public bool Value;

        public Step(string selectorId, ESelectorTypeId selectorTypeId, bool value)
        {
            SelectorId = selectorId;
            SelectorTypeId = selectorTypeId;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            var target = (Step) obj;
            return target != null && Value == target.Value && SelectorTypeId == target.SelectorTypeId;
        }
    }
}
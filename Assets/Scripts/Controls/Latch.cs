using UnityEngine;
using UnityEngine.EventSystems;

using FBRS.Bases;
using FBRS.Helpers;

namespace FBRS.Controls
{
    /// <summary>
    /// Box latch view
    /// </summary>
    [RequireComponent(typeof(SelectorViewTween))]
    public class Latch : BinarySelector, IPointerClickHandler
    {
        private SelectorViewTween _selectorViewTween;

        void Start()
        {
            _selectorViewTween = GetComponent<SelectorViewTween>();
            _selectorViewTween.DoTween(Value);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            TryToggle();
        }

        public override bool Toggle()
        {
            var result = base.Toggle();
            _selectorViewTween.DoTween(Value);
            return result;
        }
    }
}
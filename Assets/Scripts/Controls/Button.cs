using UnityEngine;
using UnityEngine.EventSystems;

using FBRS.Bases;
using FBRS.Helpers;

namespace FBRS.Controls
{
    /// <summary>
    /// Binary state button
    /// </summary>
    [RequireComponent(typeof(SelectorViewTween))]
    public class Button : BinarySelector, IPointerClickHandler
    {
        private SelectorViewTween _buttonViewTween;
        
        private void Start()
        {
            _buttonViewTween = GetComponent<SelectorViewTween>();
            _buttonViewTween.DoTween(Value);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            TryToggle();
        }

        public override bool Toggle()
        { 
            var result = base.Toggle();
            _buttonViewTween.DoTween(Value);
            return result;
        }
    }
}
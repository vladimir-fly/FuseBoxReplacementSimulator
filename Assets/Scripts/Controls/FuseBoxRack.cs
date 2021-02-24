using UnityEngine;
using UnityEngine.EventSystems;

using FBRS.Bases;

namespace FBRS.Controls
{
    /// <summary>
    /// Show/hide functionality for fusebox pedestal 
    /// </summary>
    public class FuseBoxRack : BinarySelector, IPointerClickHandler
    {
        [SerializeField] private Transform _fuseBox;

        void Start()
        {
            _fuseBox.gameObject.SetActive(Value);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            TryToggle();
        }

        public override bool Toggle()
        {  
            var result = base.Toggle();
            _fuseBox.gameObject.SetActive(Value);
            return result;
        }
    }
}
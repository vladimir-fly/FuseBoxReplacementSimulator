using System;
using UnityEngine;
using UnityEngine.EventSystems;

using FBRS.Bases;

namespace FBRS.Controls
{
    /// <summary>
    /// Handle for box cover
    /// </summary>
    public class CoverHandle : BinarySelector, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Transform _anchor;
        [SerializeField] private float _speed = 0.5f;
        [SerializeField] private bool _rotateOrDrag;

        [SerializeField] private float _minAngle;
        [SerializeField] private float _maxAngle = 90f;

        [SerializeField] private Vector2 _minOffset;
        [SerializeField] private Vector2 _maxOffset;
        [SerializeField] private bool _verticalDrag;
        
        private float _rotationX;
        private Vector3 _position;
        private bool _state;
        private bool _canDrag;
        
        /// <summary>
        /// Allows to move or flip out cover
        /// </summary>
        public void OnDrag(PointerEventData eventData)
        {
            if (!_canDrag) return;
            
            if (_rotateOrDrag)
            {
                _rotationX += eventData.delta.y * _speed;
                _anchor.rotation = Quaternion.Euler(Mathf.Clamp(_rotationX, _minAngle, _maxAngle), 0, 0);
                _state = _anchor.rotation.eulerAngles.x == _minAngle ^ _anchor.rotation.eulerAngles.x <= _maxAngle;
            }
            else
            {
                var x = Mathf.Clamp(_position.x + eventData.delta.x, _minOffset.x, _maxOffset.x);
                var y = Mathf.Clamp(_position.y + eventData.delta.y, _minOffset.y, _maxOffset.y);
                
                _position = _verticalDrag ? new Vector3(x, 0, y) : new Vector3(x, y, 0);
                
                _anchor.localPosition = _position * _speed;
                _state = Math.Abs(_anchor.localPosition.x - _minOffset.x) < 1 ^ _anchor.localPosition.x <= _maxOffset.x;
            }
        }

        public override bool Toggle()
        {   
            Value = _state;
            OnToggle?.Invoke(Value);
            return Value;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (Check == null) return;
            _canDrag = Check.Invoke(!Value);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Toggle();
        }
    }
}
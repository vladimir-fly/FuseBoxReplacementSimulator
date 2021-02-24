using System;
using System.Collections;
using UnityEngine;

namespace FBRS.Helpers
{
    /// <summary>
    /// Helper that allows simple moving of selectors visual parts
    /// </summary>
    public class SelectorViewTween : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Vector3 _direction = Vector3.right;
        [SerializeField] private float _offset = 1f;
        [SerializeField] private float _fraction = 0.1f;
        [SerializeField] private float _timing = .05f;
        [SerializeField] private float _tolerance = .1f;

        public void DoTween(bool forward, Action callback = null)
        {
            StopAllCoroutines();

            var position = _transform.localPosition;
            var offset = forward ? _direction * _offset : -_direction * _offset;

            StartCoroutine(Tween(position, offset, callback));
        }

        private IEnumerator Tween(Vector3 position, Vector3 offset)
        {
            var target = position + offset;
            while ((target - _transform.localPosition).magnitude >= _tolerance)
            {
                _transform.localPosition += offset * _fraction;
                yield return new WaitForSeconds(_timing);
            }
        }

        private IEnumerator Tween(Vector3 position, Vector3 offset, Action callback)
        {
            yield return Tween(position, offset);
            callback?.Invoke();
        }
    }
}
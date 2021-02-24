using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using FBRS.DataTypes;
using FBRS.Bases;

namespace FBRS.Behaviours
{
    public class SessionScenarioView : MonoBehaviour
    {
        public event Action<Step> OnStep;
        public Func<Step, bool> CheckStep;
        
        [SerializeField] private List<BinarySelector> _selectors;
        
        private void Start()
        {
            _selectors = transform.GetComponentsInChildren<BinarySelector>().ToList();
            
            foreach (var selector in _selectors)
            {
               
                selector.OnToggle = b =>
                {
                    var selectorId = selector.name;
                    var selectorTypeId = selector.TypeId;
                    var step = new Step(selectorId, selectorTypeId, b);    
                    OnStep?.Invoke(step);
                };

                selector.Check = b =>
                {
                    var selectorId = selector.name;
                    var selectorTypeId = selector.TypeId;
                    var step = new Step(selectorId, selectorTypeId, b);
                    return CheckStep(step);
                };
            }
        }
    }
}
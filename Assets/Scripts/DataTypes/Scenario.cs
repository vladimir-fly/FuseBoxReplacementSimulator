using System.Collections.Generic;
using UnityEngine;
using FBRS.Bases;

namespace FBRS.DataTypes
{
    /// <summary>
    /// Scenario data 
    /// </summary>
    [CreateAssetMenu(fileName = "Scenario", menuName = "FBRS/Scenario", order = 1)]
    public class Scenario : ScriptableObject
    {
        public EScenarioId ScenarioIdID;
        public List<Step> Steps; 
    }
}
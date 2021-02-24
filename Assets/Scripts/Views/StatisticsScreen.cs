using System.Linq;

using UnityEngine;
using UnityEngine.UI;

using FBRS.DataTypes;

namespace FBRS.Behaviours
{
    public class StatisticsScreen : MonoBehaviour
    {
        public Text Results;
        public Button Restart;

        public void UpdateResults(Session session)
        {
            Results.text = $"Scenario: {session.ScenarioId}; \n" +
                           $"Mistakes: {session.StepResults.Sum(sr => sr.Attempts)}; \n" +
                           $"Time {session.StopTime - session.StartTime} \n";
        }
    }
}
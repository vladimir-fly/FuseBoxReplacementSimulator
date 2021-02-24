using System;
using System.Collections.Generic;
using System.Linq;

using FBRS.Bases;

namespace FBRS.DataTypes
{
    /// <summary>
    /// Session contains scenario steps and aggregate step results 
    /// </summary>
    public class Session
    {
        public EScenarioId ScenarioId { get; }
        public HashSet<StepResult> StepResults { get; }

        public DateTime StartTime { get; private set; }
        public DateTime StopTime { get; private set; }

        public Session(EScenarioId scenarioId)
        {
            ScenarioId = scenarioId;
            StepResults = new HashSet<StepResult>();
        }

        public void AddStepResult(Step step)
        {
            if (!StepResults.Any(sr => sr.Step.SelectorId == step.SelectorId && sr.Step.Value == step.Value))
                StepResults.Add(new StepResult(step));
            else
            {
                var stepResult = StepResults.First(sr => sr.Step.SelectorId == step.SelectorId && sr.Step.Value == step.Value);
                stepResult.Attempts++;
            }
        }

        public void StartSession()
        {
            StartTime = DateTime.Now;
        }

        public void EndSession()
        {
            StopTime = DateTime.Now;
        }
    }
}
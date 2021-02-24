using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using Object = UnityEngine.Object;

using FBRS.Bases;
using FBRS.Behaviours;
using FBRS.DataTypes;
using FBRS.Managers;

namespace FBRS.Controllers
{
    /// <summary>
    /// Session and session view management 
    /// </summary>
    public class SessionController
    {
        private Session _session;
        private Queue<Step> _scenarioSteps;
        private SessionScenarioView _sessionScenarioView;
        
        public event Action OnSessionError;
        public event Action<Session> OnSessionEnd;

        public void StartSession(EScenarioId scenarioId)
        {
            _session = new Session(scenarioId);
            _session.StartSession();
            
            var scenario = Resources.Load<Scenario>($"{scenarioId.ToString()}_data");
            _scenarioSteps = new Queue<Step>(scenario.Steps);
            
            _sessionScenarioView = ResourceManager.Load<SessionScenarioView>(scenarioId.ToString());
            _sessionScenarioView.OnStep += ProcessStep;
            _sessionScenarioView.CheckStep = CheckStep;
        }

        private bool CheckStep(Step step)
        {
            var checkResult = _scenarioSteps.Peek().Equals(step);
            if (!checkResult)
            {
                OnSessionError?.Invoke();
                _session.AddStepResult(step);
            }

            return checkResult;
        }

        private void ProcessStep(Step step)
        {
            if (_scenarioSteps.Peek().Equals(step))
                _scenarioSteps.Dequeue();
            else
                OnSessionError?.Invoke();

            _session.AddStepResult(step);

            if (!_scenarioSteps.Any())
                OnSessionEnd?.Invoke(_session);
        }

        public void ClearView()
        {
            Object.Destroy(_sessionScenarioView.gameObject);
        }
    }
}
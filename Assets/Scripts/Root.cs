using UnityEngine;

using FBRS.Controllers;
using FBRS.Managers;

namespace FBRS
{
    /// <summary>
    /// Entry point in scene
    /// </summary>
    public class Root : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;

        private void Start()
        {
            _uiManager = FindObjectOfType<UIManager>();
            
            if (_uiManager == null)
                _uiManager = ResourceManager.Load<UIManager>();
            
            var sessionController = new SessionController();

            _uiManager.OnStart += scenarioId => sessionController.StartSession(scenarioId);
            _uiManager.OnClear += sessionController.ClearView;
            _uiManager.OnQuit += Application.Quit;

            sessionController.OnSessionError += _uiManager.ShowErrorDialog;
            sessionController.OnSessionEnd += _uiManager.ShowStatsDialog;
        }
    }
}
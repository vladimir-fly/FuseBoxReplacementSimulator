using System;
using UnityEngine;

using FBRS.Bases;
using FBRS.Behaviours;
using FBRS.DataTypes;

namespace FBRS.Managers
{
    /// <summary>
    /// Screen management
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        public event Action<EScenarioId> OnStart;
        public event Action OnClear;
        public event Action OnQuit;

        [SerializeField] private MainMenuScreen _mainMenuScreen;
        [SerializeField] private ErrorScreen _errorScreen;
        [SerializeField] private StatisticsScreen _statisticsScreen;

        private void Start()
        {
            // Main menu screen
            _mainMenuScreen.V1.onClick.AddListener(() =>
            {
                OnStart?.Invoke(EScenarioId.V1);
                _mainMenuScreen.gameObject.SetActive(false);
            });
            
            _mainMenuScreen.V2.onClick.AddListener(() =>
            {
                OnStart?.Invoke(EScenarioId.V2);
                _mainMenuScreen.gameObject.SetActive(false);
            });
            
            // Error screen
           _errorScreen.Restart.onClick.AddListener(() =>
           {
               OnClear?.Invoke();
               _mainMenuScreen.gameObject.SetActive(true);
               _errorScreen.gameObject.SetActive(false);
           });
              
           _errorScreen.Cancel.onClick.AddListener(() =>
           {
               _errorScreen.gameObject.SetActive(false);
           });
           
           // Statistics screen
           _statisticsScreen.Restart.onClick.AddListener(() =>
           {
               OnClear?.Invoke();
               _mainMenuScreen.gameObject.SetActive(true);
               _statisticsScreen.gameObject.SetActive(false);
           });
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
                OnQuit?.Invoke();
        }

        public void ShowErrorDialog()
        {
            _errorScreen.gameObject.SetActive(true);
        }

        public void ShowStatsDialog(Session session)
        {
            session.EndSession();
            _statisticsScreen.gameObject.SetActive(true);
            _statisticsScreen.UpdateResults(session);
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AppsoleutCodersLLP.SettingUI
{
    public class GraphicsSettingsController : MonoBehaviour
    {
        [SerializeField] private Toggle automaticGraphicsPresetToggle;
        [SerializeField] private Toggle lowGraphicsPresetToggle;
        [SerializeField] private Toggle mediumGraphicsPresetToggle;
        [SerializeField] private Toggle highGraphicsPresetToggle;
        [SerializeField] private Toggle advancedGraphicsPresetToggle;
        [SerializeField] private Toggle customGraphicsPresetToggle;

        [SerializeField] private GameObject graphicsPanel;
        [SerializeField] private GameObject automaticGraphicsPannel;
        [SerializeField] private GameObject LowGraphicsPannel;
        [SerializeField] private GameObject mediumGraphicsPannel;
        [SerializeField] private GameObject highGraphicsPannel;
        [SerializeField] private GameObject advancedGraphicsPannel;
        [SerializeField] private GameObject customGraphicsPannel;


        void Start()
        {
            automaticGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsPanel);
            lowGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsPanel);
            mediumGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsPanel);
            highGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsPanel);
            advancedGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsPanel);
            customGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsPanel);
        }
        void LoadGraphicsPanel(bool arg)
        {
            graphicsPanel.SetActive(true);
        }

        void LoadAutomaticGraphicsPannel(bool argument)
        {
            automaticGraphicsPannel.SetActive(true);
            LowGraphicsPannel.SetActive(false);
            highGraphicsPannel.SetActive(false);
            advancedGraphicsPannel.SetActive(false);
            mediumGraphicsPannel.SetActive(false);
            customGraphicsPannel.SetActive(false);
        }

        void LoadLowGraphicsPanel(bool argument)
        {
            LowGraphicsPannel.SetActive(true);
            automaticGraphicsPannel.SetActive(false);
            highGraphicsPannel.SetActive(false);
            advancedGraphicsPannel.SetActive(false);
            mediumGraphicsPannel.SetActive(false);
            customGraphicsPannel.SetActive(false);
        }

        void LoadHighGraphicsPanel(bool argument)
        {
            highGraphicsPannel.SetActive(true);
            LowGraphicsPannel.SetActive(false);
            automaticGraphicsPannel.SetActive(false);
            advancedGraphicsPannel.SetActive(false);
            mediumGraphicsPannel.SetActive(false);
            customGraphicsPannel.SetActive(false);
        }

        void LoadAdvancedGraphicsPanel(bool argument)
        {
            advancedGraphicsPannel.SetActive(true);
            highGraphicsPannel.SetActive(false);
            LowGraphicsPannel.SetActive(false);
            automaticGraphicsPannel.SetActive(false);
            mediumGraphicsPannel.SetActive(false);
            customGraphicsPannel.SetActive(false);
        }

        void LoadMediumGraphicsPanel(bool argument)
        {
            mediumGraphicsPannel.SetActive(true);
            advancedGraphicsPannel.SetActive(false);
            highGraphicsPannel.SetActive(false);
            LowGraphicsPannel.SetActive(false);
            automaticGraphicsPannel.SetActive(false);
            customGraphicsPannel.SetActive(false);
        }

        void LoadCustomGraphicsPanel(bool argument)
        {
            customGraphicsPannel.SetActive(true);
            mediumGraphicsPannel.SetActive(false);
            advancedGraphicsPannel.SetActive(false);
            highGraphicsPannel.SetActive(false);
            LowGraphicsPannel.SetActive(false);
            automaticGraphicsPannel.SetActive(false);
        }
    }
}
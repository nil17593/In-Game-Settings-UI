using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AppsoleutCodersLLP.SettingUI
{
    public class SettingsUIManager : MonoBehaviour
    {
        #region Toggles
        [Header("Settings Toggles")]
        [SerializeField] private Toggle [] settingToggles;

        //[SerializeField] private Toggle privacySettingsToggle;
        //[SerializeField] private Toggle graphicsSettingToggle;
        //[SerializeField] private Toggle languageSettingsToggle;
        //[SerializeField] private Toggle controlSettingsToggle;

        [Header("Graphics Presets Toggle")]


        [SerializeField] private Toggle automaticGraphicsPresetToggle;
        [SerializeField] private Toggle lowGraphicsPresetToggle;
        [SerializeField] private Toggle mediumGraphicsPresetToggle;
        [SerializeField] private Toggle highGraphicsPresetToggle;
        [SerializeField] private Toggle advancedGraphicsPresetToggle;
        [SerializeField] private Toggle customGraphicsPresetToggle;

        [Header("Shadow Toggles")]
        [SerializeField] private Toggle lowShadowToggle;
        [SerializeField] private Toggle highShadowToggle;
        [SerializeField] private Toggle midShadowToggle;
        [SerializeField] private Toggle offShadowToggle;

        [Header("Anti Aliasing Toggles")]
        [SerializeField] private Toggle antiAliasing2XToggle;
        [SerializeField] private Toggle antiAliasing4XToggle;
        [SerializeField] private Toggle antiAliasingoffToggle;

        [Header("V-Sync Toggles")]
        [SerializeField] private Toggle vSyncOnToggle;
        [SerializeField] private Toggle vSyncOffToggle;

        [Header("Reflection Toggles")]
        [SerializeField] private Toggle reflectionOnToggle;
        [SerializeField] private Toggle reflectionOffToggle;
        #endregion

        #region Sliders
        [Header("Sliders")]
        [SerializeField] private Slider resolutionSlider;
        [SerializeField] private Slider shadowDistanceSlider;
        [SerializeField] private Slider drawDistanceSlider;
        #endregion

        #region Panels
        [Header("Panels")]
        [SerializeField] private GameObject privacySettingPanel;
        [SerializeField] private GameObject graphicsSettingPanel;
        [SerializeField] private GameObject languageSettingsPanel;
        [SerializeField] private GameObject controlSettingsPanel;
        [SerializeField] private GameObject graphicsPanel;
        #endregion

        #region Texts
        [Header("Texts")]
        //[Range(0,100)]
        //[SerializeField] private TextMeshProUGUI sliderValue;
        #endregion

        #region Bools
        private bool isGraphicsPanelVal;
        #endregion

        private int sliderPercentage;

        public enum SettingToggleType
        {
            control,
            language,
            graphics,
            privacy
                        
        }
        private void Start()
        {
            //load respective settings panels on toggles value change
            settingToggles[(int)SettingToggleType.privacy].onValueChanged.AddListener(LoadPrivacySettings);
            settingToggles[(int)SettingToggleType.graphics].onValueChanged.AddListener(LoadGraphicsPresetSettings);
            settingToggles[(int)SettingToggleType.language].onValueChanged.AddListener(LoadLanguageSettings);
            settingToggles[(int)SettingToggleType.control].onValueChanged.AddListener(LoadControlSettings);

            

            //load different graphics panels for different presets
            automaticGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsForAutomaticPreset);
            lowGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsForLowPreset);
            mediumGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsForMediumPreset);
            highGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsForHighPreset);
            advancedGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsForAdvancedPreset);
            customGraphicsPresetToggle.onValueChanged.AddListener(LoadGraphicsForCustomPreset);

            //ChangeSliderValue(sliderPercentage);
        }

        private void LoadLanguageSettings(bool val)
        {
            languageSettingsPanel.SetActive(val);        
        }

        private void LoadControlSettings(bool val)
        {
            controlSettingsPanel.SetActive(val);   
        }

        private void LoadPrivacySettings(bool val)
        {
            privacySettingPanel.SetActive(val);
        }

        private void LoadGraphicsPresetSettings(bool val)
        {
            graphicsSettingPanel.SetActive(val);
            if (val == false)
            {
                graphicsPanel.SetActive(val);
            }
        }

        private void LoadGraphicsForCustomPreset(bool val)
        {
            graphicsPanel.SetActive(val);
        }

        private void LoadGraphicsForAutomaticPreset(bool val)
        {
            graphicsPanel.SetActive(val);
            resolutionSlider.SetValueWithoutNotify(0.5f);
            shadowDistanceSlider.SetValueWithoutNotify(0.8f);
            drawDistanceSlider.SetValueWithoutNotify(0.8f);
            highShadowToggle.isOn = true;
            antiAliasing4XToggle.isOn = true;
            vSyncOnToggle.isOn = true;
            reflectionOffToggle.isOn = true;
        }

        private void LoadGraphicsForLowPreset(bool val)
        {
            graphicsPanel.SetActive(val);
            resolutionSlider.SetValueWithoutNotify(0.5f);
            shadowDistanceSlider.SetValueWithoutNotify(0.8f);
            drawDistanceSlider.SetValueWithoutNotify(0.8f);
            lowShadowToggle.isOn = true;
            antiAliasingoffToggle.isOn = true;
            vSyncOffToggle.isOn = true;
            reflectionOffToggle.isOn = true;
        }

        private void LoadGraphicsForHighPreset(bool val)
        {
            graphicsPanel.SetActive(val);
            resolutionSlider.SetValueWithoutNotify(0.9f);
            shadowDistanceSlider.SetValueWithoutNotify(0.8f);
            drawDistanceSlider.SetValueWithoutNotify(0.7f);
        }

        private void LoadGraphicsForMediumPreset(bool val)
        {
            graphicsPanel.SetActive(val);
            resolutionSlider.SetValueWithoutNotify(0.5f);
            shadowDistanceSlider.SetValueWithoutNotify(0.4f);
            drawDistanceSlider.SetValueWithoutNotify(0.4f);
            antiAliasing2XToggle.SetIsOnWithoutNotify(val);
        }

        private void LoadGraphicsForAdvancedPreset(bool val)
        {
            graphicsPanel.SetActive(val);
            resolutionSlider.SetValueWithoutNotify(sliderPercentage);
            shadowDistanceSlider.SetValueWithoutNotify(0.5f);
            drawDistanceSlider.SetValueWithoutNotify(0.4f);
        }

        //private void ChangeSliderValue(int changeValue)
        //{
        //    sliderPercentage += changeValue;
        //    RefreshSliderValue();
        //}

        //private void RefreshSliderValue()
        //{
        //    sliderValue.text = "0" + sliderPercentage;
        //}
    }
}
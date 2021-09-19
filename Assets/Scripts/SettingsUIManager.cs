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

        [Header("Graphics Presets Toggle")]
        [SerializeField] private Toggle[] graphicsPresetToggles;

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

        public enum PresetType
        {
            Automatic,
            Advanced,
            High,
            Medium,
            Low,
            Custom
        }

        private void Start()
        {
            //load respective settings panels on toggles value change
            settingToggles[(int)SettingToggleType.privacy].onValueChanged.AddListener(LoadPrivacySettings);
            settingToggles[(int)SettingToggleType.graphics].onValueChanged.AddListener(LoadGraphicsPresetSettings);
            settingToggles[(int)SettingToggleType.language].onValueChanged.AddListener(LoadLanguageSettings);
            settingToggles[(int)SettingToggleType.control].onValueChanged.AddListener(LoadControlSettings);



            //load different graphics panels for different presets
            graphicsPresetToggles[(int)PresetType.Automatic].onValueChanged.AddListener(LoadGraphicsForAutomaticPreset);
            graphicsPresetToggles[(int)PresetType.Advanced].onValueChanged.AddListener(LoadGraphicsForAdvancedPreset);
            graphicsPresetToggles[(int)PresetType.High].onValueChanged.AddListener(LoadGraphicsForHighPreset);
            graphicsPresetToggles[(int)PresetType.Medium].onValueChanged.AddListener(LoadGraphicsForMediumPreset);
            graphicsPresetToggles[(int)PresetType.Low].onValueChanged.AddListener(LoadGraphicsForLowPreset);
            graphicsPresetToggles[(int)PresetType.Custom].onValueChanged.AddListener(LoadGraphicsForCustomPreset);
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
            resolutionSlider.SetValueWithoutNotify(0f);
            shadowDistanceSlider.SetValueWithoutNotify(0f);
            drawDistanceSlider.SetValueWithoutNotify(0f);
            highShadowToggle.isOn = true;
            antiAliasing4XToggle.isOn = true;
            vSyncOnToggle.isOn = true;
            reflectionOffToggle.isOn = true;
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
            highShadowToggle.isOn = true;
            antiAliasing4XToggle.isOn = true;
            vSyncOnToggle.isOn = true;
            reflectionOnToggle.isOn = true;
        }

        private void LoadGraphicsForMediumPreset(bool val)
        {
            graphicsPanel.SetActive(val);
            resolutionSlider.SetValueWithoutNotify(0.5f);
            shadowDistanceSlider.SetValueWithoutNotify(0.4f);
            drawDistanceSlider.SetValueWithoutNotify(0.4f);
            midShadowToggle.isOn = true;
            antiAliasing2XToggle.isOn = true;
            vSyncOffToggle.isOn = true;
            reflectionOffToggle.isOn = true;
        }

        private void LoadGraphicsForAdvancedPreset(bool val)
        {
            graphicsPanel.SetActive(val);
            resolutionSlider.SetValueWithoutNotify(0.7f);
            shadowDistanceSlider.SetValueWithoutNotify(0.5f);
            drawDistanceSlider.SetValueWithoutNotify(0.4f);
            midShadowToggle.isOn = true;
            antiAliasing4XToggle.isOn = true;
            vSyncOnToggle.isOn = true;
            reflectionOffToggle.isOn = true;
        }
    }
}
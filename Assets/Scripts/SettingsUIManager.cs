using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AppsoleutCodersLLP.SettingUI
{
    public class SettingsUIManager : MonoBehaviour
    {
        /// <summary>
        /// all setting panels are handles in this class 
        /// all panels are load through this class
        /// toggles are used because we need values either true or false
        /// loading of preset panel and preset settings panel
        /// used arrays for different toggle group
        /// </summary>
        
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

        #region Buttons
        [SerializeField]private Button doneButton;
        #endregion

        #region Texts
        [Header("Texts")]
        //[Range(0,100)]
        [SerializeField] private TextMeshProUGUI sliderValue;
        #endregion

        #region private integers
        private int currentSavedGraphics=0;
        #endregion

        //enums for settings togles types
        public enum SettingToggleType
        {
            control,
            language,
            graphics,
            privacy                       
        }

        //enums for preset types
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

            doneButton.onClick.AddListener(OnDoneButtonClick);
            graphicsPresetToggles[PlayerPrefs.GetInt("SavedGraphics", currentSavedGraphics)].isOn=true;
            sliderValue = GetComponent<TextMeshProUGUI>();

            //load different graphics panels for different presets
            graphicsPresetToggles[(int)PresetType.Automatic].onValueChanged.AddListener(LoadGraphicsForAutomaticPreset);
            graphicsPresetToggles[(int)PresetType.Advanced].onValueChanged.AddListener(LoadGraphicsForAdvancedPreset);
            graphicsPresetToggles[(int)PresetType.High].onValueChanged.AddListener(LoadGraphicsForHighPreset);
            graphicsPresetToggles[(int)PresetType.Medium].onValueChanged.AddListener(LoadGraphicsForMediumPreset);
            graphicsPresetToggles[(int)PresetType.Low].onValueChanged.AddListener(LoadGraphicsForLowPreset);
            graphicsPresetToggles[(int)PresetType.Custom].onValueChanged.AddListener(LoadGraphicsForCustomPreset);
        }

        //load language setting panel on language toggle true
        private void LoadLanguageSettings(bool val)
        {
            languageSettingsPanel.SetActive(val);        
        }

        //loads control setting panel on control toggle true
        private void LoadControlSettings(bool val)
        {
            controlSettingsPanel.SetActive(val);   
        }

        //loads privacy setting panel on privacy toggle true
        private void LoadPrivacySettings(bool val)
        {
            privacySettingPanel.SetActive(val);
        }

        //loads graphics preset settings on preset toggle true
        private void LoadGraphicsPresetSettings(bool val)
        {
            graphicsSettingPanel.SetActive(val);//presets panel setActive true 
            if (val == false)
            {
                graphicsPanel.SetActive(val);//preset setting panel setActive true
            }
        }

        //loads custom preset settings
        private void LoadGraphicsForCustomPreset(bool val)
        {
            graphicsPanel.SetActive(val);
            resolutionSlider.SetValueWithoutNotify(PlayerPrefs.GetInt("SavedGraphics",currentSavedGraphics));
            shadowDistanceSlider.SetValueWithoutNotify(0f);
            drawDistanceSlider.SetValueWithoutNotify(0f);
            highShadowToggle.isOn = true;
            antiAliasing4XToggle.isOn = true;
            vSyncOnToggle.isOn = true;
            reflectionOffToggle.isOn = true;
            
            //PlayerPrefs.SetInt("SavedGraphics", currentSavedGraphics);
        }

        //loads automatic preset settings 
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
            //PlayerPrefs.SetInt("SavedGraphics", 1);
        }

        //loads low preset settings
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
            //PlayerPrefs.SetInt("SavedGraphics", 1);
        }

        //loads high graphics preset
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
            //PlayerPrefs.SetInt("SavedGraphics", 1);
        }

        //load medium graphics preset 
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
            //PlayerPrefs.SetInt("SavedGraphics", 1);
        }

        //load advanced graphics preset
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
            //PlayerPrefs.SetInt("SavedGraphics", 1);
        }

        //saves graphics on button click
        private void OnDoneButtonClick()
        {
            PlayerPrefs.SetInt("SavedGraphics", currentSavedGraphics);
        }
    }
}
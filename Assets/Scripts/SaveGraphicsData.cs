using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AppsoleutCodersLLP.SettingUI
{
    public class SaveGraphicsData : MonoBehaviour
    {
        /// <summary>
        /// in this class graphics data is saved
        /// used arrays for toggles
        /// </summary>
        #region Toggles
        [Header("Shadow Toggles")]
        [SerializeField] private Toggle[] shadowToggles;

        [Header("Anti Aliasing Toggles")]
        [SerializeField] private Toggle[] antiAliasingToggles;

        [Header("V-Sync Toggles")]
        [SerializeField] private Toggle[] vSyncToggles;

        [Header("Reflection Toggles")]
        [SerializeField] private Toggle[] reflectionToggles;
        #endregion

        #region Sliders
        [Header("Sliders")]
        [SerializeField] private Slider resolutionSlider;
        [SerializeField] private Slider shadowDistanceSlider;
        [SerializeField] private Slider drawDistanceSlider;
        #endregion

        #region private floats
        private float valueOfResolutionSlider;
        private float valueOfShadowDistanceSlider;
        private float valueOfDrawDistanceSlider;
        #endregion

        private void Start()
        {
            SaveOnShadowToggle();
            SaveAntiAliasingToggle();
            SaveVsyncToggle();
            SaveReflectionToggle();

            //percentageText = GetComponent<TextMeshProUGUI>();

            shadowToggles[PlayerPrefs.GetInt("ShadowToggleVal")].isOn = true;
            antiAliasingToggles[PlayerPrefs.GetInt("SavedAntiAliasingToggle")].isOn = true;
            vSyncToggles[PlayerPrefs.GetInt("SavedVsyncToggle")].isOn = true;
            reflectionToggles[PlayerPrefs.GetInt("SavedReflectionToggle")].isOn = true;

            valueOfResolutionSlider = PlayerPrefs.GetFloat("ValuseOfResolutionSlide");
            resolutionSlider.value = valueOfResolutionSlider;
            valueOfShadowDistanceSlider = PlayerPrefs.GetFloat("ValueOfShadowDistanceSlider");
            shadowDistanceSlider.value = valueOfShadowDistanceSlider;
            valueOfDrawDistanceSlider = PlayerPrefs.GetFloat("ValueOfDrawDistanceSlider");
            drawDistanceSlider.value = valueOfDrawDistanceSlider;
        }

        private void Update()
        {
            SetResolution();
            SetShadowDistance();
            SetDrawDistanceSlider();
        }

        //save resolution slider value
        private void SetResolution()
        {
            valueOfResolutionSlider = resolutionSlider.value;
            if (resolutionSlider)
            {
                PlayerPrefs.SetFloat("ValuseOfResolutionSlide", valueOfResolutionSlider);
            }
        }

        //save shadow distance slider value
        private void SetShadowDistance()
        {
            valueOfShadowDistanceSlider = shadowDistanceSlider.value;
            if (shadowDistanceSlider)
            {
                PlayerPrefs.SetFloat("ValueOfShadowDistanceSlider", valueOfShadowDistanceSlider);
            }
        }

        //save draw distance slider value
        private void SetDrawDistanceSlider()
        {
            valueOfDrawDistanceSlider = drawDistanceSlider.value;
            if (drawDistanceSlider)
            {
                PlayerPrefs.SetFloat("ValueOfDrawDistanceSlider", valueOfDrawDistanceSlider);
            }
        }


        //checks and saves value of selected shadow toggle
        private void SaveOnShadowToggle()
        {
            for (int i = 0; i < shadowToggles.Length; i++)
            {
                if (shadowToggles[i].isOn == true)
                {
                    PlayerPrefs.SetInt("ShadowToggleVal", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("ShadowToggleVal", 0);
                }
            }
        }

        //saves antialiasing data
        private void SaveAntiAliasingToggle()
        {
            for (int i = 0; i < antiAliasingToggles.Length; i++)
            {
                if (antiAliasingToggles[i].isOn == true)
                {
                    PlayerPrefs.SetInt("SavedAntiAliasingToggle", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("SavedAntiAliasingToggle", 0);
                }
            }
        }

        //saves vsync data
        private void SaveVsyncToggle()
        {
            for (int i = 0; i < vSyncToggles.Length; i++)
            {
                if (vSyncToggles[i].isOn == true)
                {
                    PlayerPrefs.SetInt("SavedVsyncToggle", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("SavedVsyncToggle", 0);
                }
            }
        }

        //saves reflection data
        private void SaveReflectionToggle()
        {
            for (int i = 0; i < reflectionToggles.Length; i++)
            {
                if (reflectionToggles[i].isOn == true)
                {
                    PlayerPrefs.SetInt("SavedReflectionToggle", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("SavedReflectionToggle", 0);
                }
            }
        }
    }
}
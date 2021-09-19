using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace AppsoleutCodersLLP
{
    public class SaveLanguageData : MonoBehaviour
    {
        [SerializeField] private Toggle [] languageSettingToggles;
        public static int currentLanguageNumber;

        public enum LanguageType
        {
            Dutch,
            English,
            French,
            Chinese,
            German,
            Italian,
            Portuguese,
            Espanol,
            Swenska,
            Japanese,
            Vietnamese,
            Korean,
            Russian,
            Arabic,
            Turkish
        }

        private void Start()
        {
            languageSettingToggles[PlayerPrefs.GetInt("SavedLanguage")].isOn = true;
            foreach (LanguageType i in Enum.GetValues(typeof(LanguageType)))
            {
                LanguageType language = i;
                languageSettingToggles[(int)language].onValueChanged.AddListener((v) => OnLanguagesToggleClick(v, language));

            }
            Debug.Log(PlayerPrefs.GetInt("SavedLanguage"));
        }

        private void OnLanguagesToggleClick(bool val, LanguageType languageType)
        {
            if (val)
            {
                currentLanguageNumber = (int)languageType;
                PlayerPrefs.SetInt("SavedLanguage",currentLanguageNumber);
                Debug.Log("currentLanguage " +currentLanguageNumber);
            }
        }
    }
}
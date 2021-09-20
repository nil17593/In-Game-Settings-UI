﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace AppsoleutCodersLLP
{
    public class SaveLanguageData : MonoBehaviour
    {
        #region Toggles
        [Header("Language Tggles")]
        [SerializeField] private Toggle [] languageSettingToggles;
        #endregion 

        #region Buttons
        [SerializeField] private Button doneButton;
        #endregion

        #region private variables
        private int currentLanguageNumber;
        #endregion

        //enums for language type
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
            doneButton.onClick.AddListener(OnDoneButtonClick);
            languageSettingToggles[PlayerPrefs.GetInt("SavedLanguage")].isOn = true;
            Debug.Log("previously Saved Language= "+PlayerPrefs.GetInt("SavedLanguage").ToString());
            GetSelectedLanguage();
        }

        //saveing language which is selected by user
        private void OnLanguagesToggleClick(bool val, LanguageType languageType)
        {
            if (val)
            {
                currentLanguageNumber = (int)languageType;
                //PlayerPrefs.SetInt("SavedLanguage",currentLanguageNumber);
                Debug.Log("currentLanguage= "+ (string)currentLanguageNumber.ToString());
            }
        }

        private void GetSelectedLanguage()
        {
            foreach (LanguageType i in Enum.GetValues(typeof(LanguageType)))
            {
                languageSettingToggles[(int)i].onValueChanged.AddListener((v) => OnLanguagesToggleClick(v, i));
            }
        }

        private void OnDoneButtonClick()
        {
            PlayerPrefs.SetInt("SavedLanguage", currentLanguageNumber);
        }
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AppsoleutCodersLLP.SettingUI
{
    public class SaveControlToggleData : MonoBehaviour
    {
        [SerializeField] private Toggle[] steeringControlToggles;
        [SerializeField] private Toggle musicOnOffToggle;
        [SerializeField] private Toggle soundOnOffToggle;
        [SerializeField] private Toggle[] handSettingsToggle;

        [SerializeField] private Button doneButton;
        private int currentSteeringNumber;
        private int currentSoundNumber;
        private int currentMusicNumber;
        private int currentHandNumber;
       

        public enum SteeringType
        {
            Steering,
            TouchPad,
            Tilt,
        }

        public enum HandType
        {
            Left,
            Right
        }

        private void Start()
        {
            doneButton.onClick.AddListener(OnDoneButtonClick);
            steeringControlToggles[PlayerPrefs.GetInt("SavedType")].isOn = true;
            handSettingsToggle[PlayerPrefs.GetInt("HandValue")].isOn = true;
            //musicOnOffToggles[PlayerPrefs.GetInt("SavedType")].isOn = true;
            //handSettingsToggle[PlayerPrefs.GetInt("SavedType")].isOn = true;
            SaveSoundMusicData();

            steeringControlToggles[(int)SteeringType.Steering].onValueChanged.AddListener(OnStreeringToggleClick);
            steeringControlToggles[(int)SteeringType.TouchPad].onValueChanged.AddListener(OnTouchPadToggleClick);
            steeringControlToggles[(int)SteeringType.Tilt].onValueChanged.AddListener(OnTiltToggleClick);


            musicOnOffToggle.onValueChanged.AddListener(OnMusicToggleClick);
            soundOnOffToggle.onValueChanged.AddListener(OnSoundToggleClick);
            
            
            handSettingsToggle[(int)HandType.Left].onValueChanged.AddListener(OnLeftHandToggleClick);
            handSettingsToggle[(int)HandType.Right].onValueChanged.AddListener(OnRightHandToggleClick);
        }

        //private void OnSteeringTypeToggleClick(int steeringType)
        //{
        //    steeringControlToggles[steeringType].isOn = true;
        //}

        private void OnStreeringToggleClick(bool val)
        {
            if (val)
            {
                currentSteeringNumber = (int)SteeringType.Steering;
            }
        }

        private void OnTouchPadToggleClick(bool val)
        {
            if (val)
            {
                currentSteeringNumber = (int)SteeringType.TouchPad;
            }
        }

        private void OnTiltToggleClick(bool val)
        {
            if (val)
            {
                currentSteeringNumber = (int)SteeringType.Tilt;
            }
        }

        private void OnDoneButtonClick()
        {
            PlayerPrefs.SetInt("SavedType", currentSteeringNumber);
            PlayerPrefs.SetInt("SoundValue", currentSoundNumber);
            PlayerPrefs.SetInt("MusicValue", currentMusicNumber);
            PlayerPrefs.SetInt("HandValue", currentHandNumber);
            //PlayerPrefs.SetInt("SavedLanguage", SaveLanguageData.currentLanguageNumber);
            //PlayerPrefs.SetInt("SavedType", currentSoundNumber);
            //PlayerPrefs.SetInt("SavedType", handNumber);
        }

        private void OnMusicToggleClick(bool val)
        {
            if (val)
            {
               // PlayerPrefs.SetInt("MusicValue", 1);
                currentMusicNumber = 1;
            }
            else
            {
                //PlayerPrefs.SetInt("MusicValue", 0);
                currentMusicNumber = 0;
            }
        }

        private void OnSoundToggleClick(bool val)
        {
            if (val)
            {
                currentSoundNumber = 1;
            }
            else
            {
                currentSoundNumber = 0;
            }
        }

        private void OnLeftHandToggleClick(bool val)
        {
            if (val)
            {
                currentHandNumber = (int)HandType.Left;
            }
        }

        private void OnRightHandToggleClick(bool val)
        {
            if (val)
            {
                currentHandNumber = (int)HandType.Right;
            }
        }

        private void SaveSoundMusicData()
        {
            if (PlayerPrefs.GetInt("MusicValue") == 1)
            {
                musicOnOffToggle.isOn = true;
                Debug.Log("music on");
            }
            else
            {
                musicOnOffToggle.isOn = false;
            }

            if (PlayerPrefs.GetInt("SoundValue") == 1)
            {
                soundOnOffToggle.isOn = true;
                Debug.Log("sound on");
            }
            else
            {
                soundOnOffToggle.isOn = false;
            }
        }


    }
}
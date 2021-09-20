using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AppsoleutCodersLLP.SettingUI
{
    public class SaveControlToggleData : MonoBehaviour
    {
        #region Toggles
        [Header("Steering Toggle")]
        [SerializeField] private Toggle[] steeringControlToggles;

        [Header("Hand Setting Toggle")]
        [SerializeField] private Toggle[] handSettingsToggle;

        [SerializeField] private Toggle musicOnOffToggle;
        [SerializeField] private Toggle soundOnOffToggle;
        #endregion

        #region Buttons
        [SerializeField] private Button doneButton;
        #endregion

        #region private integers
        private int currentSteeringNumber;
        private int currentSoundNumber;
        private int currentMusicNumber;
        private int currentHandNumber;
        #endregion

        //enum for steering type
        public enum SteeringType
        {
            Steering,
            TouchPad,
            Tilt,
        }

        //enum for hand type
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
            SaveSoundMusicData();
            
            //steering control toggles
            steeringControlToggles[(int)SteeringType.Steering].onValueChanged.AddListener(OnStreeringToggleClick);
            steeringControlToggles[(int)SteeringType.TouchPad].onValueChanged.AddListener(OnTouchPadToggleClick);
            steeringControlToggles[(int)SteeringType.Tilt].onValueChanged.AddListener(OnTiltToggleClick);

            //music toggles
            musicOnOffToggle.onValueChanged.AddListener(OnMusicToggleClick);
            soundOnOffToggle.onValueChanged.AddListener(OnSoundToggleClick);
            
            //hand control toggles
            handSettingsToggle[(int)HandType.Left].onValueChanged.AddListener(OnLeftHandToggleClick);
            handSettingsToggle[(int)HandType.Right].onValueChanged.AddListener(OnRightHandToggleClick);
        }

        //triggers when steering togle true
        private void OnStreeringToggleClick(bool val)
        {
            if (val)
            {
                currentSteeringNumber = (int)SteeringType.Steering;
            }
        }

        //triggers whem touch pad toggle true
        private void OnTouchPadToggleClick(bool val)
        {
            if (val)
            {
                currentSteeringNumber = (int)SteeringType.TouchPad;
            }
        }

        //triggers when tilt toggle true
        private void OnTiltToggleClick(bool val)
        {
            if (val)
            {
                currentSteeringNumber = (int)SteeringType.Tilt;
            }
        }

        //saves data on click of done button
        private void OnDoneButtonClick()
        {
            PlayerPrefs.SetInt("SavedType", currentSteeringNumber);
            PlayerPrefs.SetInt("SoundValue", currentSoundNumber);
            PlayerPrefs.SetInt("MusicValue", currentMusicNumber);
            PlayerPrefs.SetInt("HandValue", currentHandNumber);
        }

        //set music toggle true
        private void OnMusicToggleClick(bool val)
        {
            if (val)
            {
                currentMusicNumber = 1;
            }
            else
            {
                currentMusicNumber = 0;
            }
        }

        //set sound toggle true
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

        //sets left hand control toggle true
        private void OnLeftHandToggleClick(bool val)
        {
            if (val)
            {
                currentHandNumber = (int)HandType.Left;
                Debug.Log("Left Hand Control selected");
            }
        }

        //set right hand control toggle true
        private void OnRightHandToggleClick(bool val)
        {
            if (val)
            {
                currentHandNumber = (int)HandType.Right;
                Debug.Log("Right Hand Control selected");
            }
        }

        //used player prefs for saving data
        //saves music data 
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
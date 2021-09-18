using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AppsoleutCodersLLP.SettingUI
{
    public class ControlToggleController : MonoBehaviour
    {
        [SerializeField] private Toggle[] steeringControlToggles;
        [SerializeField] private Button doneButton;
        private int currentSteeringNumber;
        public enum SteeringType
        {
            Steering,
            TouchPad,
            Tilt,
        }

        private void Start()
        {
            doneButton.onClick.AddListener(OnDoneButtonClick);
            steeringControlToggles[PlayerPrefs.GetInt("SavedSteeringType")].isOn = true;

            //Debug.Log(PlayerPrefs.GetInt("SavedSteeringType"));
            //int steeringTypeNumber = PlayerPrefs.GetInt("SavedSteeringType");
            //OnSteeringTypeToggleClick(steeringTypeNumber);

            steeringControlToggles[(int)SteeringType.Steering].onValueChanged.AddListener(OnStreeringToggleClick);
            steeringControlToggles[(int)SteeringType.TouchPad].onValueChanged.AddListener(OnTouchPadToggleClick);
            steeringControlToggles[(int)SteeringType.Tilt].onValueChanged.AddListener(OnTiltToggleClick);

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
            PlayerPrefs.SetInt("SavedSteeringType", currentSteeringNumber);
        }
    }
}
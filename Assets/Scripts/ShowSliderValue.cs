using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AppsoleutCodersLLP.SettingUI
{
    public class ShowSliderValue : MonoBehaviour
    {
        private TextMeshProUGUI percentageText;
        private void Start()
        {
            percentageText = GetComponent<TextMeshProUGUI>();
        }

        
        public void UpdateSliderText(float val)
        {
            percentageText.text = Mathf.RoundToInt(val * 100) + "%";
        }
    }
}
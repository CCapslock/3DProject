using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class FlashLightUi : MonoBehaviour
    {
        private Slider _slider;
        // image

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public float SliderCurrentValue
		{
            set => _slider.value = value;
        }
		public float SliderMaxValue
		{
			set => _slider.maxValue = value;
		}
    }
}

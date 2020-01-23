using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
	public class EnemyHpUi : MonoBehaviour
	{
		private Slider _slider;
		private Canvas _canvas;
		private void Awake()
		{
			_slider = GetComponentInChildren<Slider>();
			_canvas = GetComponentInChildren<Canvas>();
		}
		public void SwitchUi(EnemyUiActiveType value)
		{
			switch (value)
			{
				case EnemyUiActiveType.On:
					_canvas.enabled = true;
					break;
				case EnemyUiActiveType.Off:
					_canvas.enabled = false;
					break;
			}
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

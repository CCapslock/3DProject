using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
	public class WeaponUi : MonoBehaviour
	{
		private Text _text;
		private void Awake()
		{
			_text = GetComponent<Text>();
		}
		public string Text
		{
			set => _text.text = "Current Weapon :" + value;
		}
	}

}

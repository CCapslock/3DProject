using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
	public sealed class WeaponUi : MonoBehaviour
	{
		private Text _currentWeapontext;
		private void Awake()
		{
			_currentWeapontext = GetComponent<Text>();
		}
		public string Text
		{
			set => _currentWeapontext.text = "Current Weapon :" + value;
		}

		public void SetActive(bool value)
		{
			_currentWeapontext.gameObject.SetActive(value);
		}
	}

}

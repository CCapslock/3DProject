using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
	public sealed class WeaponAmunitionUi : MonoBehaviour
	{
		[SerializeField] private Text _text;

		private void Awake()
		{
			_text = GetComponent<Text>();
		}

		public void ShowData(int countAmmunition, int countClip)
		{
			_text.text = $"{countAmmunition}/{countClip}";
		}

		public void SetActive(bool value)
		{
			_text.gameObject.SetActive(value);
		}
	}
}
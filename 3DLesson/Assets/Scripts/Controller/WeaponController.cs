using UnityEngine;

namespace Geekbrains
{
	sealed public class WeaponController : IInitialization, IExecute
	{
		private GameObject[] _weapons;
		private Renderer _weapon;
		private WeaponUi _weaponUi;

		private int _currentNumOfWeapon = 0;
		private int _maxAmountOfWeapons;
		private bool _isWeaponActive;


		// находит все оружие и делает видимым только первое
		public void Initialization()
		{
			_weaponUi = Object.FindObjectOfType<WeaponUi>();
			_weapons = GameObject.FindGameObjectsWithTag(TagManager.WEAPON);
			WriteCurrentWeapon();
			_maxAmountOfWeapons = _weapons.Length;
			OffMeshRenderer();
		}
		public void ChangeWeapon()
		{
			if (_currentNumOfWeapon != _maxAmountOfWeapons - 1)
			{
				_currentNumOfWeapon++;
				OffMeshRenderer();

			}
			else if (_currentNumOfWeapon == _maxAmountOfWeapons - 1)
			{
				_currentNumOfWeapon = 0;
				OffMeshRenderer();

			}
			WriteCurrentWeapon();
		}
		//делает невидемыми все оружие и потом делает видимым только одно
		public void OffMeshRenderer()
		{
			for (int i = 0; i < _maxAmountOfWeapons; i++)
			{
				_weapon = _weapons[i].GetComponent<Renderer>();
				_weapon.enabled = false;
			}
			_weapon = _weapons[_currentNumOfWeapon].GetComponent<Renderer>();
			_weapon.enabled = true;
		}
		public void Execute()
		{
		}

		private void WriteCurrentWeapon()
		{
			_weaponUi.Text = _weapons[_currentNumOfWeapon].name;
		}
	}
}

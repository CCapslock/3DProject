using UnityEngine;

namespace Geekbrains
{
	sealed public class WeaponController : BaseController
	{
		private WeaponAmunitionUi _weaponAmunitionUi;
		private WeaponUi _weaponUi;

		private Weapon _weapon;

        /*private GameObject[] _weapons; //первый способ реализации смены оружия
		private MeshRenderer _weaponmy;
		private int _currentNumOfWeapon = 0;
		private int _maxAmountOfWeapons;
		private bool _isWeaponActive;*/

		public override void On(params BaseObjectScene[] weapon)
		{
			if (IsActive) return;
			if (weapon.Length > 0) _weapon = weapon[0] as Weapon;
			if (_weapon == null) return;
			base.On(_weapon);
			_weaponUi = GameObject.FindObjectOfType<WeaponUi>();
			_weapon.IsVisible = true;
			_weaponAmunitionUi.SetActive(true);
			_weaponAmunitionUi.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
		}

		public override void Off()
		{
			if (!IsActive) return;
			base.Off();
			_weapon.IsVisible = false;
			_weapon = null;
			_weaponAmunitionUi.SetActive(false);
		}

		public void Fire()
		{
			_weapon.Fire();
			_weaponAmunitionUi.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
		}

		//TODO впихнуть куда нибудь вывод названия оружия
		public void SetWeaponName(string weaponName)
		{
			_weaponUi.Text = weaponName;
		}


		//Первый способ смены оружия
		// находит все оружие и делает видимым только первое
		/*public void Initialization()
		{
			_weaponUi = Object.FindObjectOfType<WeaponAmunitionUi> ();
			_weapons = GameObject.FindGameObjectsWithTag(TagManager.WEAPON);
			_maxAmountOfWeapons = _weapons.Length;
			OffMeshRenderer();
			_currentNumOfWeapon++;
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
		}
		//делает невидемыми все оружие и потом делает видимым только одно
		public void OffMeshRenderer()
		{

			for (int i = 0; i < _maxAmountOfWeapons; i++)
			{
				_weaponmy = _weapons[i].GetComponent<MeshRenderer>();
				_weaponmy.enabled = false;
			}
			_weaponmy = _weapons[_currentNumOfWeapon].GetComponent<MeshRenderer>();
			_weapon.enabled = true;
		}*/
	}
}

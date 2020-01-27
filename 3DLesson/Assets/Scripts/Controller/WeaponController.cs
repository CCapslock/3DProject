using UnityEngine;

namespace Geekbrains
{
	sealed public class WeaponController : BaseController
	{
		private WeaponAmunitionUi _weaponAmunitionUi;
		private WeaponUi _weaponUi;

		private Weapon _weapon;
		public override void On(params BaseObjectScene[] weapon)
		{
			if (IsActive) return;
			if (weapon.Length > 0) _weapon = weapon[0] as Weapon;
			if (_weapon == null) return;
			base.On(_weapon);
			_weaponUi = GameObject.FindObjectOfType<WeaponUi>();
			_weaponAmunitionUi = GameObject.FindObjectOfType<WeaponAmunitionUi>();
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
			//_weaponAmunitionUi.SetActive(false);
		}

		public void Fire()
		{
			_weapon.Fire();
			_weaponAmunitionUi.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
		}

		public void ReloadWeapon()
		{
			_weapon.ReloadClip();
			_weaponAmunitionUi.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
		}

		//TODO впихнуть куда нибудь вывод названия оружия
		public void SetWeaponName(string weaponName)
		{
			_weaponUi.Text = weaponName;
		}
	}
}

using UnityEngine;

namespace Geekbrains
{
	public sealed class InputController : BaseController, IExecute
	{
		private KeyCode _activeFlashLight = KeyCode.F;
		private KeyCode _cancel = KeyCode.Escape;
		private KeyCode _reloadClip = KeyCode.R;
		private float _mouseScroll;
		private int _mouseButton = (int)MouseButton.LeftButton;
		private int _currentWeapon = -1;
		private bool _weaponIsSelected = true;

		public InputController()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}

		public void Execute()
		{
			if (!IsActive) return;

			if (Input.GetKeyDown(_activeFlashLight))
			{

			}

			if (Input.GetKeyDown(_reloadClip))
			{
				ServiceLocator.Resolve<WeaponController>().ReloadWeapon();
			}

			if (Input.GetMouseButton(_mouseButton))
			{
				if (ServiceLocator.Resolve<WeaponController>().IsActive)
				{
					ServiceLocator.Resolve<WeaponController>().Fire();
				}
			}

			if (Input.GetKeyDown(_cancel))
			{
				ServiceLocator.Resolve<WeaponController>().Off();
				ServiceLocator.Resolve<FlashLightController>().Off();
				_currentWeapon = -1;
			}

			_mouseScroll = Input.GetAxis("Mouse ScrollWheel");

			SetCurrentWeapon();

			if (!_weaponIsSelected)
			{
				if (_currentWeapon != -1)
				{
					SelectWeapon(_currentWeapon);
					_weaponIsSelected = true;
				}
				else
				{
					ServiceLocator.Resolve<WeaponController>().Off();
				}
			}
		}

		private void SetCurrentWeapon()
		{
			if (_mouseScroll != 0)
			{
				int amountOfWeapon = ServiceLocator.Resolve<Inventory>().Weapons.Length;
				if (_mouseScroll > 0)
				{
					if (_currentWeapon < amountOfWeapon - 1)
					{
						_currentWeapon++;
						_weaponIsSelected = false;
					}
				}
				if (_mouseScroll < 0)
				{
					if (_currentWeapon > -1)
					{
						_currentWeapon--;
						_weaponIsSelected = false;
					}
				}
			}
		}

		/// <summary>
		/// Выбор оружия
		/// </summary>
		/// <param name="i">Номер оружия</param>
		private void SelectWeapon(int i)
		{
			var tempWeapon = ServiceLocator.Resolve<Inventory>().Weapons[i]; //todo инкапсулировать
			ServiceLocator.Resolve<WeaponController>().Off();
			if (tempWeapon != null)
			{
				ServiceLocator.Resolve<WeaponController>().On(tempWeapon);
			}
		}
	}
}

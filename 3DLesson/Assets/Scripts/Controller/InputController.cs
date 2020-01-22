using UnityEngine;

//

namespace Geekbrains
{
	public sealed class InputController : BaseController, IExecute
	{
		private KeyCode _activeFlashLight = KeyCode.F;
		private KeyCode _cancel = KeyCode.Escape;
		private KeyCode _reloadClip = KeyCode.R;
		private int _mouseButton = (int)MouseButton.LeftButton;
		private int _currentWeapon = -1;

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
			//todo реализовать выбор оружия по колесику мыши

			if (Input.GetKeyDown(_reloadClip))
			{
				ServiceLocator.Resolve<WeaponController>().ReloadWeapon();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				SelectWeapon(0);
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

			/*if (Input.GetKeyDown(_reloadClip))
            {
                ServiceLocator.Resolve<WeaponController>().ReloadClip();
            }*/
		}


		/// <summary>
		/// Выбор оружия
		/// </summary>
		/// <param name="i">Номер оружия</param>
		private void SelectWeapon(int i)
		{
			if (_currentWeapon != i)
			{
				_currentWeapon = i;
				var tempWeapon = ServiceLocator.Resolve<Inventory>().Weapons[i]; //todo инкапсулировать
				ServiceLocator.Resolve<WeaponController>().Off();
				if (tempWeapon != null)
				{
					ServiceLocator.Resolve<WeaponController>().On(tempWeapon);
				}
			}
		}
	}
}

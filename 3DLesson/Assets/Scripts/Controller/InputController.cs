using UnityEngine;

namespace Geekbrains
{
    public sealed class InputController : BaseController, IExecute
    {
        private KeyCode _activeFlashLight = KeyCode.F;
		private KeyCode _changeWeapon = KeyCode.E;

		public void Execute()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                ServiceLocator.Resolve<FlashLightController>().Switch();
            }
			else if (Input.GetKeyDown(_changeWeapon))
			{
				ServiceLocator.Resolve<WeaponController>().ChangeWeapon();
			}
		}
    }
}

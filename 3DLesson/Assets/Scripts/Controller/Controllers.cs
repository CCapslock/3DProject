﻿using UnityEngine;


namespace Geekbrains
{
    public sealed class Controllers : IInitialization
    {
        private readonly IExecute[] _executeControllers;

        public int Length => _executeControllers.Length;

        public Controllers()
        {
			IMotor motor = new UnitMotor(ServiceLocatorMonoBehaviour.GetService<CharacterController>());
			ServiceLocator.SetService(new PlayerController(motor));
            ServiceLocator.SetService(new FlashLightController());
            ServiceLocator.SetService(new InputController());
			ServiceLocator.SetService(new WeaponController());
			ServiceLocator.SetService(new Inventory());
			_executeControllers = new IExecute[3];

            _executeControllers[0] = ServiceLocator.Resolve<PlayerController>();

            _executeControllers[1] = ServiceLocator.Resolve<FlashLightController>();

            _executeControllers[2] = ServiceLocator.Resolve<InputController>();
		}
        
        public IExecute this[int index] => _executeControllers[index];

        public void Initialization()
        {
            foreach (var controller in _executeControllers)
            {
                if (controller is IInitialization initialization)
                {
                    initialization.Initialization();
                }
            }


			ServiceLocator.Resolve<Inventory>().Initialization();
			ServiceLocator.Resolve<InputController>().On();
			ServiceLocator.Resolve<PlayerController>().On();
		}
    }
}

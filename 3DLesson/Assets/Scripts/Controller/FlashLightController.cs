using UnityEngine;

namespace Geekbrains
{
	public sealed class FlashLightController : BaseController, IExecute, IInitialization
	{
		private FlashLightModel _flashLightModel;
		private FlashLightUi _flashLightUi;

		public void Initialization()
		{

			_flashLightModel = Object.FindObjectOfType<FlashLightModel>();
			_flashLightUi = Object.FindObjectOfType<FlashLightUi>();
			_flashLightUi.SliderMaxValue = _flashLightModel._batteryChargeMax;
			_flashLightUi.SliderCurrentValue = _flashLightModel._batteryChargeMax;
		}

		public override void On()
		{
			if (IsActive) return;
			if (_flashLightModel.BatteryChargeCurrent <= 0) return;
			base.On();
			_flashLightModel.Switch(FlashLightActiveType.On);
		}

		public override void Off()
		{
			if (!IsActive) return;
			base.Off();
			_flashLightModel.Switch(FlashLightActiveType.Off);
		}

		public void Execute()
		{
			_flashLightUi.SliderCurrentValue = _flashLightModel.BatteryChargeCurrent;
			if (!IsActive)
			{
				if (_flashLightModel.BatteryChargeCurrent < 10)
				{
					_flashLightModel.BatteryChargeCurrent += Time.deltaTime;

				}
				return;
			}
			_flashLightModel.Rotation();

			if (!_flashLightModel.EditBatteryCharge())
			{
				Off();
			}
		}
	}
}

using UnityEngine;

namespace Geekbrains
{
	public sealed class UiInterface
	{
		private WeaponUiText _weaponUiText;

		public WeaponUiText WeaponUiText
		{
			get
			{
				if (!_weaponUiText)
					_weaponUiText = Object.FindObjectOfType<WeaponUiText>();
				return _weaponUiText;
			}
		}

		private SelectionObjMessageUi _selectionObjMessageUi;

		public SelectionObjMessageUi SelectionObjMessageUi
		{
			get
			{
				if (!_selectionObjMessageUi)
					_selectionObjMessageUi = Object.FindObjectOfType<SelectionObjMessageUi>();
				return _selectionObjMessageUi;
			}
		}
	}
}
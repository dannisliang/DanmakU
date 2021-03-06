// Copyright (c) 2015 James Liu
//	
// See the LISCENSE file for copying permission.

using UnityEngine;

using Vexe.Runtime.Types;

namespace DanmakU.Modifiers {

	public class AddControllersModifier : DanmakuModifier {

		[Serialize, Show]
		private IDanmakuController[] controllers;

		private DanmakuController controllerAggregate;

		public AddControllersModifier (DanmakuController controller) {
			controllerAggregate = controller;
		}

		public void AddController(IDanmakuController controller) {
			controllerAggregate += controller.Update;
		}

		public void RemoveController(IDanmakuController controller) {
			controllerAggregate -= controller.Update;
		}

		public void AddController(DanmakuController controller) {
			controllerAggregate += controller;
		}

		public void RemoveController(DanmakuController controller) {
			controllerAggregate -= controller;
		}

		public void ClearControllers() {
			controllerAggregate = null;
			controllers = new IDanmakuController[0];
		}

		#region implemented abstract members of DanmakuModifier

		public override void Fire (Vector2 position, DynamicFloat rotation) {

			DanmakuController temp = controllerAggregate;
			for(int i = 0; i < controllers.Length; i++) {
				temp += controllers[i].Update;
			}
			Controller += temp;
			FireSingle (position, rotation);

		}

		#endregion



		
	}

}

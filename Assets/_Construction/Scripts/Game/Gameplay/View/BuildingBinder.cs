﻿using UnityEngine;

namespace Gameplay.View
{
    public class BuildingBinder : MonoBehaviour
    {
        public void Bind(BuildingViewModel viewModel)
        {
            transform.position = viewModel.Position.CurrentValue;
        }
    }
}

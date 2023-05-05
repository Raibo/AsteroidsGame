using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Ui
{
    public class UiInputWrapper : EntityHolder<IUiInputProvider>, IUiInputProvider
    {
        public bool IsNewGameRequested => Input.GetKeyDown(KeyCode.N);

        public override IUiInputProvider Entity => this;
    }
}

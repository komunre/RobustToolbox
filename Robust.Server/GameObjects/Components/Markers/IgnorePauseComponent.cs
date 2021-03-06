using Robust.Server.Interfaces.Timing;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;

namespace Robust.Server.GameObjects.Components.Markers
{
    public class IgnorePauseComponent : Component
    {
        public override string Name => "IgnorePause";

        public override void OnAdd()
        {
            base.OnAdd();
            Owner.Paused = false;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            if (IoCManager.Resolve<IPauseManager>().IsMapPaused(Owner.Transform.MapID))
            {
                Owner.Paused = true;
            }
        }
    }
}

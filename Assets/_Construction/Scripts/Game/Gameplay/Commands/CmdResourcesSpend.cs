using _Construction.Game.State.cmd;
using _Construction.Game.State.GameResources;

namespace _Construction.Game.Gameplay.Commands
{
    public class CmdResourcesSpend: ICommand
    {
        public readonly ResourceType ResourceType;
        public readonly int Amount;

        public CmdResourcesSpend(ResourceType resourceType, int amount)
        {
            ResourceType = resourceType;
            Amount = amount;
        }
    }
}
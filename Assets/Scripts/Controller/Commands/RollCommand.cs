using UnityEngine;

namespace Controller
{
    public class RollCommand : ICCommand
    {
        private Command name = Command.Roll;

        public void Execute()
        {
            Debug.LogFormat("Executed {0} Command", name.ToString());
        }

        public Command GetName()
        {
            return name;
        }
    }
}
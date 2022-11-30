using UnityEngine;

namespace Controller
{
    public class JumpCommand : ICCommand
    {
        private Command name = Command.Jump;

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
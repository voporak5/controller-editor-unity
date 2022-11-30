using UnityEngine;

namespace Controller
{
    public class ShootCommand : ICCommand
    {
        private Command name = Command.Shoot;

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
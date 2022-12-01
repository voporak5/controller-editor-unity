namespace Controller
{
    public static class CommandFactory
    {
        public static ICCommand Create(Command command)
        {
            switch(command)
            {
                case Command.Crouch:
                    return new CrouchCommand();
                case Command.Jump:
                    return new JumpCommand();
                case Command.Roll:
                    return new RollCommand();
                case Command.Shoot:
                    return new ShootCommand();
                case Command.None:
                default:
                    return new DummyCommand();
            }
        }
    }
}
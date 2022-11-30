namespace Controller
{
    public interface ICCommand
    {
        Command GetName();
        void Execute();
    }
}
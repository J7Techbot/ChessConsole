namespace HW2.Interfaces
{
    public interface IInputRequestTrigger
    {
        public Func<string> ExpectedInputEvent { get; set; }
    }
}

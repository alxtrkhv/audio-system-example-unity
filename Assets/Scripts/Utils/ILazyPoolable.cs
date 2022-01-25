namespace Alxtrkhv.AudioSystem
{
    public interface ILazyPoolable : IPoolable
    {
        public bool IsReadyForRelease { get; }
    }
}

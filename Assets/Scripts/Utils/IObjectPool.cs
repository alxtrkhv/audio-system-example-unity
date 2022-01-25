namespace Alxtrkhv.AudioSystem
{
    public interface IObjectPool<TPooledObject>
    {
        public TPooledObject Get();
        public bool Release(TPooledObject obj);
    }
}

namespace Alxtrkhv.AudioSystem
{
    public interface IObjectPool<TPooledObject>
    {
        public TPooledObject Get();
        public void Release(TPooledObject obj);
    }
}

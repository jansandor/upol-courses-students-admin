namespace cv8_mvc.Models
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
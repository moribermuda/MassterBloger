namespace MB.Domain.ArticleCategoryAgg.Exeption
{
    public class DuplicatedException : Exception
    {
        public DuplicatedException() { }
        public DuplicatedException(string message) : base(message) { }
    }
}

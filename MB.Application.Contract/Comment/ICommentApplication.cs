namespace MB.Application.Contract.Comment
{
    public interface ICommentApplication
    {
        List<CommentViewModel> GetList();
        void Add(AddComment command);
        void Confirm(long id);
        void Cancel(long id);
    }
}

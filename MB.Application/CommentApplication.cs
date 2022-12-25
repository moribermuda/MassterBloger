using MB.Application.Contract.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public void Add(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            commentRepository.Creat(comment);
        }

        public void Cancel(long id)
        {
           var comment = commentRepository.Get(id);
            comment.Cancel();
           // commentRepository.Save();
        }

        public void Confirm(long id)
        {
            var comment = commentRepository.Get(id);
            comment.Confirm();
         //   commentRepository.Save();
        }

        public List<CommentViewModel> GetList()
        {
            return commentRepository.GetList();
        }
    }
}

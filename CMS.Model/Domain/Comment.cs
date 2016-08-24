namespace CMS.Model.Domain
{
    public class Comment
    {
        public Comment() { }
        public Comment(int commentid,string content, string owner, Page page, int pageid)
        {
            CommentId = commentid;
            ContentComment = content;
            OwnerComment = owner;
            Page = page;
            PageId = pageid;

        }
        public int CommentId { get; set; }
        public string ContentComment { get; set; }
        public string OwnerComment { get; set; }

        public int? PageId { get; set; }
        public virtual Page Page { get; set; }

    }
}

namespace ForumSystem.Web.ViewModels.Votes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class VoteInputModel
    {
        public int PostId { get; set; }

        public bool IsUpVote { get; set; }
    }
}

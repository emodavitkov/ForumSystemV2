using System.Linq;
using System.Threading.Tasks;

using ForumSystem.Data.Common.Repositories;
using ForumSystem.Data.Models;

namespace ForumSystem.Services.Data;

public class VoteService : IVotesService
{
    private readonly IRepository<Vote> votesRepository;

    public VoteService(IRepository<Vote> votesRepository)
    {
        this.votesRepository = votesRepository;
    }

    public int GetVotes(int postId)
    {
       var votes = this.votesRepository.All()
            .Where(x => x.PostId == postId).Sum(x => (int)x.Type);
       return votes;
    }

    public async Task VoteAsync(int postId, string userId, bool isUpVote)
    {
        var vote = this.votesRepository.All()
            .FirstOrDefault(x => x.PostId == postId && x.UserId == userId);
        if (vote != null)
        {
            vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
        }
        else
        {
            vote = new Vote
            {
                PostId = postId,
                UserId = userId,
                Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
            };
            await this.votesRepository.AddAsync(vote);
        }

        await this.votesRepository.SaveChangesAsync();
    }
}
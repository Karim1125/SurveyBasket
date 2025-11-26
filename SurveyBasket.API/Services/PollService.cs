using SurveyBasket.Entities;

namespace SurveyBasket.Services;

public class PollService(ApplicationDbContext context) : IPollService
{
    private readonly ApplicationDbContext _context = context;
    public async Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken = default) => 
        await _context.Polls.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Poll?> GetAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.Polls.FindAsync(id, cancellationToken);

    public async Task<Poll?> AddAsync(Poll poll, CancellationToken cancellationToken = default)
    {
        await _context.Polls.AddAsync(poll, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return poll;
    }

    public async Task<bool> UpdateAsync(int id, Poll poll, CancellationToken cancellationToken = default)
    {
        var existingpoll = await GetAsync(id, cancellationToken);

        if (existingpoll is null)   
        {
            return false;
        }

        if (!string.IsNullOrEmpty(poll.Title))
            existingpoll.Title = poll.Title;

        if (!string.IsNullOrEmpty(poll.Summary))
            existingpoll.Summary = poll.Summary;

            existingpoll.StartsAt = poll.StartsAt;

            existingpoll.EndsAt = poll.EndsAt;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var poll = await GetAsync(id, cancellationToken);
        if (poll is null)
        {
            return false;
        }
        _context.Remove(poll);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task<bool> TogglePublishStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        var poll = await GetAsync(id, cancellationToken);

        if (poll is null)
        {
            return false;
        }
        poll.IsPublished = !poll.IsPublished;


        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

}

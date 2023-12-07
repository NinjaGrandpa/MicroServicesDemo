using MongoDB.Bson;

namespace Questions.DataAccess;

public class QuestionRepository : IQuestionRepository
{
    public async Task<Question> GetByIdAsync(ObjectId id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Question entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Question entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(ObjectId id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Question>> GetForCategoryAsync(string category, int count, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

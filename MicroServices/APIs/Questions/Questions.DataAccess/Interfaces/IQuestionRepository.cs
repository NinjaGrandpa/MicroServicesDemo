using Domain.Common.Interfaces.DataAccess;
using MongoDB.Bson;
using Questions.DataAccess.Models;

namespace Questions.DataAccess.Interfaces;

public interface IQuestionRepository : IGenericRepository<Question, ObjectId>
{
    Task<IEnumerable<Question>> GetForCategoryAsync(
        string category, 
        int count, 
        CancellationToken cancellationToken
        );
}

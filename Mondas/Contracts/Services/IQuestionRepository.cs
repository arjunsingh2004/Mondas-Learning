using System.Collections.Generic;
using Mondas.Models;

namespace Mondas.Contracts.Services
{
    public interface IQuestionRepository
    {
        IReadOnlyList<Question> GetAllQuestions();
    }
}
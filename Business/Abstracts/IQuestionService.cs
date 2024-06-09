using Business.Dtos.Questions;

namespace Business.Abstracts;

public interface IQuestionService
{
    Task<CreatedQuestionResponse> Add(CreatedQuestionRequest createdQuestionRequest);
    Task Delete(int questionId);
}
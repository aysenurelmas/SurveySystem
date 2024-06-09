using Application.Features.Surveys.Rules;
using Business.Abstracts;
using Business.Dtos;
using Business.Dtos.Questions;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class QuestionManager : IQuestionService
{
    private readonly IQuestionDal _questionDal;

    public QuestionManager(IQuestionDal questionDal)
    {
        _questionDal = questionDal;
    }

    public Task<CreatedQuestionResponse> Add(CreatedQuestionRequest createdQuestionRequest)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int questionId)
    {
        Question? question = await _questionDal.GetAsync(q => q.Id == questionId);
        await _questionDal.DeleteAsync(question);
    }
}
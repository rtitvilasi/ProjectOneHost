using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.Data
{
    public interface IQuestion
    {
        Question GetById(int id);
        Answer GetAnswerById(int id);
        IEnumerable<Question> GetAll();
        IEnumerable<Answer> GetAllAnswers();
        IEnumerable<Question> GetFilteredQuestions(Category category);
        IEnumerable<Question> GetFilteredQuestions(string searchQuery);
        IEnumerable<Question> GetQuestionsByCategory(int id);
        IEnumerable<Question> GetLatestQuestions(int n);
        IEnumerable<Question> GetPopularQuestions(int n);
        IEnumerable<Question> GetMostResponseQuestions(int n);
        IEnumerable<Question> GetPriorityQuestions(int n);

        Task AddQuestion(Question question);
        Task Delete(int Questionid);
        Task DeleteAnswer(int Answerid);
        Task EditQuestionContent(int id, string newContent);
        Task AddAnswer(Answer answer);
        Task AddLike(LikeQuestion likeQuestion);
        Task AddAnswerLike(LikeAnswer likeAnswer);
        Task AddView(int id);
    }
}

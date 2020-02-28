using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.Data
{
    public interface IAnswer
    {
        
        Answer GetById(string id);
        IEnumerable<Answer> GetAll();
        Task Delete(int id);

    }
}

using SimpleSite.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSite.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFieldsAsync();

        TextField GetTextFieldById(Guid id);

        TextField GetTextFieldByCodeWord(string codeWord);

        Task SaveTextField(TextField textField);

        Task DeleteTextField(Guid id);
    }
}
using SimpleSite.Domain.Entities;
using SimpleSite.Domain.Repositories.Abstract;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSite.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;

        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            await context.SaveChangesAsync();
        }

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(t => t.CodeWord == codeWord);
        }

        public TextField GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<TextField> GetTextFieldsAsync()
        {
            return context.TextFields;
        }

        public async Task SaveTextField(TextField textField)
        {
            if (textField.Id == default)
            {
                context.Entry(textField).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                context.Entry(textField).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            await context.SaveChangesAsync();
        }
    }
}
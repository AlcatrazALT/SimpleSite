using SimpleSite.Domain.Repositories.Abstract;

namespace SimpleSite.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }

        public DataManager(ITextFieldsRepository textFields, IServiceItemsRepository serviceItems)
        {
            TextFields = textFields;
            ServiceItems = serviceItems;
        }
    }
}
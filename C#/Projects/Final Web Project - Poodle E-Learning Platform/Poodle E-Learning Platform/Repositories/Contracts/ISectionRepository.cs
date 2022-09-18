using Poodle_E_Learning_Platform.Models;

namespace Poodle_E_Learning_Platform.Repositories.Contracts
{
    public interface ISectionRepository
    {
        Section GetById(int id);
        Section GetByTitle(string title);
        void SaveChanges();
        Section CreateSection(Section section, int courseId);
        Section UpdateSection(int id, Section sectionChanges);
        Section Delete(int id);
    }
}

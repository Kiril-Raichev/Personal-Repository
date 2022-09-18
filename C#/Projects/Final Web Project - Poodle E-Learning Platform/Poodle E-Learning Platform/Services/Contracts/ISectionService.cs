using Poodle_E_Learning_Platform.Models;

namespace Poodle_E_Learning_Platform.Services.Contracts
{
    public interface ISectionService
    {
        Section GetById(int id);
        Section CreateSection(Section section, int courseId);
       
        Section UpdateSection(int id, Section sectionChanges);
        Section Delete(int id);

    }
}

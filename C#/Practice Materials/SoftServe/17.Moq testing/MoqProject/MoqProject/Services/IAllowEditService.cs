namespace MoqProject.Services
{
    public interface IAllowEditService
    {
        bool CanUserEdit(userRole role);
    }
}

using Poodle_E_Learning_Platform.Models;
using System.Collections.Generic;

namespace Poodle_E_Learning_Platform.Repositories
{
    public interface IUserCourseRepository
    {
        void AddUserToCourse(int userId, int courseId);
        void RemoveCourseFromUser(int courseId, int userId);

        bool IsUserAlreadyInCourse(int userId, int courseId);

        UserCourse GetById(int id);
        UserCourse GetByBothIds(int courseId,int? userId);
        List<UserCourse> GetByTeacher(int courseId);
    }
}

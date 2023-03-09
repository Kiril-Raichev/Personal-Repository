using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poodle_E_Learning_Platform.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository repository;
        private readonly IUsersRepository usersRepository;
        private readonly IUserCourseRepository userCourseRepo;
        public CourseService(ICourseRepository repository, IUsersRepository userRepository, IUserCourseRepository userCourseRepo)
        {
            this.repository = repository;
            this.usersRepository = userRepository;
            this.userCourseRepo = userCourseRepo;
        }
        public List<Course> GetAll()
        {
            var publicCourses = this.repository.GetAll();
            return publicCourses;
        }
        public List<Course> GetAll(string email)
        {
            var courses = this.repository.GetAll();
            var publicCourses = this.repository.GetAll().Where(x => x.Visibility == CourseVisibility.Public).ToList();


            var user = this.usersRepository.GetByEmail(email);


            if (user == null || user.Role == UserRole.Student)
            {
                return publicCourses;
            }
            if (user.Role == UserRole.Teacher)
            {
                return courses;
            }
            return publicCourses;
        }

        public Course GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public Course GetById(int id, string email)
        {
            var course = this.repository.GetById(id);
            User user = this.usersRepository.GetByEmail(email);

            if (user.Role == UserRole.Student && course.Visibility == CourseVisibility.Public)
            {
                if (!this.userCourseRepo.IsUserAlreadyInCourse(user.Id, course.Id))
                {
                    this.userCourseRepo.AddUserToCourse(user.Id, course.Id);
                    this.usersRepository.SaveChanges();
                }
            }
            return course;
        }

        public Course GetByTitle(string title, string email)
        {
            var course = this.repository.GetByTitle(title);
            User user = this.usersRepository.GetByEmail(email);


            if (user.Role == UserRole.Student && course.Visibility == CourseVisibility.Public)
            {
                if (!this.userCourseRepo.IsUserAlreadyInCourse(user.Id, course.Id))
                {
                    this.userCourseRepo.AddUserToCourse(user.Id, course.Id);
                    this.usersRepository.SaveChanges();
                }
            }

            return course;
        }

        public List<Course> GetCoursesFiltered(CourseQueryParameters parameters)
        {
            return this.repository.GetCoursesFiltered(parameters);
        }

        public Course CreateCourse(Course course, string email)
        {
            bool courseExists = true;
            var loggedUser = this.usersRepository.GetByEmail(email);

            if (loggedUser.Role != UserRole.Teacher)
            {
                throw new UnauthorizedAccessException("you are not allowed to create courses");
            }
            try
            {
                this.repository.GetByTitle(course.Title);
            }
            catch (EntityNotFoundException)
            {
                courseExists = false;
            }

            if (courseExists)
            {
                throw new DuplicateEntityException($"A course with this title  already exists.");
            }
            var currentCourse = this.repository.CreateCourse(course);
            return currentCourse;
        }
        public Course CreateCourse(Course course)
        {
            bool courseExists = true;
            try
            {
                this.repository.GetByTitle(course.Title);
            }
            catch (EntityNotFoundException)
            {
                courseExists = false;
            }

            if (courseExists)
            {
                throw new DuplicateEntityException($"A course with this title already exists.");
            }
            var currentCourse = this.repository.CreateCourse(course);
            return currentCourse;
        }

        public Course UpdateCourse(int id, string email, Course courseChanges)
        {
            var loggedUser = this.usersRepository.GetByEmail(email);
            if (loggedUser.Role != UserRole.Teacher)
            {
                throw new UnauthorizedOperationException($"You are not allowed to do this!");
            }
            var updatedCourse = this.repository.UpdateCourse(id, courseChanges);

            return updatedCourse;
        }
        public Course UpdateCourse(int id, Course courseChanges)
        {
            bool duplicateExists = true;
            try
            {
                Course existingCourse = this.repository.GetById(id);
                if (existingCourse != null)
                {
                    duplicateExists = false;
                }
            }
            catch (DuplicateEntityException)
            {
                duplicateExists = false;
            }
            if (duplicateExists)
            {
                throw new DuplicateEntityException("Course with this title already exists!");
            }
            var updatedCourse = this.repository.UpdateCourse(id, courseChanges);
            return updatedCourse;
        }
        public Course Delete(int id)
        {
            var courseToDelete = this.repository.GetById(id);
            return this.repository.Delete(courseToDelete.Id);
        }
        public Course Delete(int id, string email)
        {
            var loggedUser = this.usersRepository.GetByEmail(email);

            if (loggedUser.Role != UserRole.Teacher)
            {
                throw new UnauthorizedAccessException("You are not allowed to delete courses");
            }
            var courseToDelete = this.repository.GetById(id);
            return this.repository.Delete(courseToDelete.Id);
        }
    }
}

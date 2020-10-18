using System;
using System.Collections.Generic;
using GolfTrackerAPI.Models;
using MongoDB.Driver;

namespace GolfTrackerAPI.Services
{
    public interface ICourseService
    {
        //GET all
        List<Course> GetList();

        //GET one <id>
        Course GetItem(string id);

        //CREATE 
        Course Create(Course courseToCreate);

        //UPDATE
        void Update(Course courseToUpdate);

        //DELETE
        void Delete(string id);
    }

    public class CourseService : ICourseService
    {
        private readonly IMongoCollection<Course> _course;
        public CourseService()
        {
            var client = new MongoClient("mongodb+srv://GolfApp:GolfApp@cluster0.buim1.mongodb.net/GolfTracker?retryWrites=true&w=majority");
            var database = client.GetDatabase("GolfTracker");
            _course = database.GetCollection<Course>("Course");
        }
        public Course Create(Course courseToCreate)
        {
            _course.InsertOne(courseToCreate);
            return courseToCreate;
        }

        public void Delete(string id)
        {
            _course.DeleteOne(c => c.CourseId == id);
        }

        public Course GetItem(string id)
        {
            return _course.Find(c => c.CourseId == id).SingleOrDefault();
        }

        public List<Course> GetList()
        {
            return _course.Find(_ => true).ToList();
        }

        public void Update(Course courseToUpdate)
        {
            _course.ReplaceOne(c => c.CourseId == courseToUpdate.CourseId, courseToUpdate);
        }
    }
}

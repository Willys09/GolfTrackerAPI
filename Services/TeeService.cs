using System;
using System.Collections.Generic;
using GolfTrackerAPI.Models;
using MongoDB.Driver;

namespace GolfTrackerAPI.Services
{
    public interface ITeeService
    {
        //GET all
        List<Tee> GetList();

        //GET one <id>
        Tee GetItem(string id);

        //CREATE 
        Tee Create(Tee teeToCreate);

        //UPDATE
        void Update(Tee teeToUpdate);

        //DELETE
        void Delete(string id);
    }
    public class TeeService : ITeeService
    {
        private readonly IMongoCollection<Tee> _tees;

        public TeeService()
        {
            var client = new MongoClient("mongodb+srv://GolfApp:GolfApp@cluster0.buim1.mongodb.net/GolfTracker?retryWrites=true&w=majority");
            var database = client.GetDatabase("GolfTracker");
            _tees = database.GetCollection<Tee>("Tee");
        }

        public Tee Create(Tee teeToCreate)
        {
            _tees.InsertOne(teeToCreate);
            return teeToCreate;
        }

        public void Delete(string id)
        {
            _tees.DeleteOne(t => t.TeeId == id);
        }

        public Tee GetItem(string id)
        {
            return _tees.Find(t => t.TeeId == id).SingleOrDefault();
        }

        public List<Tee> GetList()
        {
            return _tees.Find(t => true).ToList();
        }

        public void Update(Tee teeToUpdate)
        {
            _tees.ReplaceOne(t => t.TeeId == teeToUpdate.TeeId, teeToUpdate);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using loginAPI.Models;

namespace loginAPI.Data
{
    public class MockCandidate: ICandidate
    {
        private readonly CandidateDBContext context; 

        public MockCandidate(CandidateDBContext _context)
        {
            context = _context; 
        }

        public bool AddCandidate(Candidate c)
        {
            context.Candidates.Add(c);
            SaveChanges();
            return true; 
        }

        public bool DeleteCandidate(int id)
        {
            var result = context.Candidates.FirstOrDefault(c => c.ID == id);
            if (result != null)
            {
                context.Candidates.Remove(result);
                SaveChanges();
                return true; 
            }
            return false; 
        }

        public bool EditCandidate(Candidate c)
        {
            var result = context.Candidates.FirstOrDefault(ca => ca.ID == c.ID);
            if (result != null)
            {
                result.City = c.City;
                result.CVID = c.CVID;
                result.Email = c.Email;
                result.Name = c.Name;
                result.PhoneNumber = c.PhoneNumber;
                result.Position = c.Position;
                SaveChanges();
                return true; 
            }
            return false; 
        }

        public IEnumerable<Candidate> GetAllCandidates()
        {
           return context.Candidates.ToList(); 
        }

        public Candidate GetCandidateByID(int id)
        {
            var result = context.Candidates.FirstOrDefault(c => c.ID == id);
            return result; 
        }
        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}

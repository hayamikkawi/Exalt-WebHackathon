using System;
using System.Collections.Generic;
using loginAPI.Models;

namespace loginAPI.Data
{
    public interface ICandidate
    {
        public bool AddCandidate(Candidate c);
        public IEnumerable<Candidate> GetAllCandidates();
        public bool DeleteCandidate (int id);
        public bool EditCandidate(Candidate c);
        public Candidate GetCandidateByID(int id);
    }
}

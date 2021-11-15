using System;
using System.Collections.Generic;
using System.Linq;
using loginAPI.Models;

namespace loginAPI.Data
{
    public class MockInterviews: IInterview
    {
        InterviewDBContext context; 
        public MockInterviews(InterviewDBContext _context)
        {
            context = _context; 
        }
        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
        public bool AddInterview(Interview i)
        {
            context.Interviews.Add(i);
            SaveChanges(); 
            return true; 
        }

        public bool DeleteInterview(int id)
        {
            var result = context.Interviews.FirstOrDefault(I => I.ID == id);
            if (result != null)
            {
                context.Interviews.Remove(result);
                SaveChanges();
                return true;
            }
            return false;
           
        }

        public bool EditInterview(Interview i)
        {
            var result = context.Interviews.FirstOrDefault(ca => ca.ID == i.ID);
            if (result != null)
            {
                result.CandidateName = i.CandidateName;
                result.Branch = i.Branch;
                result.HallID = i.HallID;
                result.InterViewerName = i.InterViewerName;
                result.Position = i.Position;
                result.Time = i.Time;
                SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Interview> GetAllInterviews()
        {
            return context.Interviews.ToList();
        }

        public Interview GetInterviewByID(int id)
        {
            var result = context.Interviews.FirstOrDefault(c => c.ID == id);
            return result;
        }
        
    }
}

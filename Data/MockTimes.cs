using System;
using System.Collections.Generic;
using System.Linq;
using loginAPI.Models;

namespace loginAPI.Data
{
    public class MockTimes :ITime
    {
        TimeDBContext context;
        public MockTimes(TimeDBContext _context)
        {
            context = _context; 
        }
        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

        public bool AddEmptyTime(Times times)
        {
            context.Ttimes.Add(times);
            return true; 
        }

        public bool DeleteTime(Times time)
        {
            var result = context.Ttimes.FirstOrDefault(I => I.ID == time.ID);
            if (result != null)
            {
                context.Ttimes.Remove(result);
                SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Times> GetAllFreeEmployees(DateTime dateTime)
        {
            var res = from s in context.Ttimes
                      select s;
            res = res.Where(t => t.StartTime == dateTime && t.Type == "e");
            return res.ToList(); 
        }

        public IEnumerable<Times> GetAllReservedHall(DateTime dateTime)
        {
            var res = from s in context.Ttimes
                      select s;
            res = context.Ttimes.Where(t => t.StartTime == dateTime && t.Type == "h");
            return res.ToList();
        }
    }
}

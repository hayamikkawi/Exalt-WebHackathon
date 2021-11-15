using System;
using System.Collections.Generic;
using loginAPI.Models;

namespace loginAPI.Data
{
    public interface IInterview
    {
        public bool AddInterview(Interview i);
        public IEnumerable<Interview> GetAllInterviews();
        public bool DeleteInterview(int id);
        public bool EditInterview(Interview i);
        public Interview GetInterviewByID(int id);
    }
}

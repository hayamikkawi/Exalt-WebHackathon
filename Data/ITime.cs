using System;
using System.Collections.Generic;
using loginAPI.Models;

namespace loginAPI.Data
{
    public interface ITime
    {
        public bool AddEmptyTime(Times times);
        public IEnumerable<Times> GetAllReservedHall(DateTime dateTime);
        public bool DeleteTime(Times time);
        public IEnumerable<Times> GetAllFreeEmployees(DateTime dateTime);
        
    }
}

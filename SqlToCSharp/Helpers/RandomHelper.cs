using System;

namespace SqlToPOCO.Helpers
{
    public class RandomDate : Random
    {
        private DateTime _startDate;
        private DateTime _endDate;
        public RandomDate(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }
        public DateTime Random
        {
            get
            {
                System.Threading.Thread.Sleep(2);
                int range = (_endDate - _startDate).Days;
                return _startDate.AddDays(base.Next(range));
            }
        }
    }

    public class RandomIndex : Random
    {
        private int _itemsCount;
        public RandomIndex(int itemsCount)
        {
            _itemsCount = itemsCount;
        }
        public int Random
        {
            get
            {
                System.Threading.Thread.Sleep(2);
                return base.Next(0, _itemsCount - 1);
            }
        }
    }
    public class RandomNumber : Random
    {
        private int _min;
        private int _max;
        public RandomNumber(int min, int max)
        {
            _min = min;
            _max = max;
        }
        public int Random
        {
            get
            {
                System.Threading.Thread.Sleep(2);
                return base.Next(_min, _max);
            }
        }
    }
}

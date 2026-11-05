using System;

namespace TimeTracking.Business
{
    public class FortnightInfo
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int FortnightNumber { get; set; }
        public int DaysInFortnight { get; set; }

        public string Description
        {
            get
            {
                return string.Format("Fortnight {0}: {1} - {2}",
                    FortnightNumber,
                    StartDate.ToString("dd/MM/yyyy"),
                    EndDate.ToString("dd/MM/yyyy"));
            }
        }
    }
}

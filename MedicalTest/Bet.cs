using System;

namespace MedicalTest
{
    public class Bet
    {
        public Bet()
        {
        }

        public int Id { get; set; }
        public double Stake { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
    }
}
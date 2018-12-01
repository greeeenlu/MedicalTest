using System;

namespace MedicalTest
{
    internal class Bet
    {
        public Bet()
        {
        }

        public int Id { get; set; }
        public double Stake { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
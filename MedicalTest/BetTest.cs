using NUnit.Framework;
using System;

namespace MedicalTest
{
    [TestFixture]
    public class BetTest
    {
        [Test]
        public void TransferBet()
        {
            Bet bet = new Bet() { Id = 1, Stake = 344.4, CreateDate = new DateTime(2018, 12, 1) };

            BetDto betDto = Mapper.TransferBet<Bet, BetDto>(bet, b => new BetDto()
            {
                BetId = b.Id,
                Date = b.CreateDate.ToString("yyyy-MM-dd"),
                Amount = (int)b.Stake
            });

            Assert.AreEqual(1, betDto.BetId);
            Assert.AreEqual("2018-12-01", betDto.Date);
            Assert.AreEqual(344, betDto.Amount);
        }
    }

    public class Mapper
    {
        public static TResult TransferBet<TSource, TResult>(TSource bet, Func<TSource, TResult> map)
        {
            return map(bet);
        }
    }

    internal class BetDto
    {
        public int Amount { get; set; }

        public string Date { get; set; }

        public int BetId { get; set; }
    }
}
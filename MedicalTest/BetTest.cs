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

        [Test]
        public void TransferBet_Interface()
        {
            Bet bet = new Bet() { Id = 1, Stake = 344.4, CreateDate = new DateTime(2018, 12, 1) };

            BetDto betDto = Mapper.TransferBet<Bet, BetDto>(bet, new LuluMapper());

            Assert.AreEqual(1, betDto.BetId);
            Assert.AreEqual("2018-12-01", betDto.Date);
            Assert.AreEqual(344, betDto.Amount);
        }

        [Test]
        public void TransferBet_ByPropertyName()
        {
            Bet bet = new Bet() { Id = 1, Stake = 344.4, CreateDate = new DateTime(2018, 12, 1), Status = "Running" };

            BetDto betDto = Mapper.TransferBet(bet);

            Assert.AreEqual("Running", betDto.Status);
        }
    }

    public class Mapper
    {
        public static TResult TransferBet<TSource, TResult>(TSource bet, Func<TSource, TResult> map)
        {
            return map(bet);
        }

        public static TResult TransferBet<TSource, TResult>(TSource bet, IMapper<TSource, TResult> map)
        {
            return map.Maping(bet);
        }

        internal static BetDto TransferBet(Bet bet)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMapper<TSource, TResult>
    {
        TResult Maping(TSource bet);
    }

    public class LuluMapper : IMapper<Bet, BetDto>
    {
        public BetDto Maping(Bet b)
        {
            return new BetDto()
            {
                BetId = b.Id,
                Date = b.CreateDate.ToString("yyyy-MM-dd"),
                Amount = (int)b.Stake
            };
        }
    }

    public class BetDto
    {
        public int Amount { get; set; }

        public string Date { get; set; }

        public int BetId { get; set; }

        public string Status { get; set; }
    }
}
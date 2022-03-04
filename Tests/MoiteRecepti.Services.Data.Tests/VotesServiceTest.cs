using MoiteRecepti.Data.Common.Repositories;
using MoiteRecepti.Data.Models;

using Moq;

using Xunit;

namespace MoiteRecepti.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class VotesServiceTest
    {
        [Fact]
        public async Task WhenUserVote2TimesOnly1VoteShouldBeCount()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => list.Add(vote));

            var service = new VotesService(mockRepo.Object);

            await service.SetVoteAsync(1, "1", 1);
            await service.SetVoteAsync(1, "1", 5);
            await service.SetVoteAsync(1, "1", 5);

            //Assert.Equal(1, list.Count());
            Assert.Single(list);
            Assert.Equal(5, list.First().Value);
        }
    }
}

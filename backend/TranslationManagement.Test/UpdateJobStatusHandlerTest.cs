using Moq;
using Moq.EntityFrameworkCore;
using TranslationManagement.Business.Dto;
using TranslationManagement.Business.Exceptions;
using TranslationManagement.Business.Handlers;
using TranslationManagement.Data;
using TranslationManagement.Data.Entities;

namespace TranslationManagement.Test
{
    public class UpdateJobStatusHandlerTest
    {
        private readonly UpdateJobStatusHandler _handler;

        private readonly static Job[] FakeData = new[]
        {
            new Job { Id = 1, CustomerName = "Customer 1", Status = JobStatusDto.New.ToString() },
        };

        public UpdateJobStatusHandlerTest()
        {
            var appDbContextMock = new Mock<AppDbContext>();
            appDbContextMock.Setup(x => x.TranslationJobs).ReturnsDbSet(FakeData);
            _handler = new UpdateJobStatusHandler(appDbContextMock.Object);
        }

        [Fact]
        public async Task Status_UpdateStatus_When_Handle()
        {
            var update = new UpdateJobStatusDto() { JobId = 1, Status = JobStatusDto.Inprogress };

            await _handler.Handle(new Business.UpdateJobStatus(update), CancellationToken.None);

            Assert.Equal(FakeData.First().Status, JobStatusDto.Inprogress.ToString());
        }
         
        [Fact]
        public async Task Status_ThrowNotFoundException_When_Handle()
        {
            var update = new UpdateJobStatusDto() { JobId = 2, Status = JobStatusDto.Inprogress };

            async Task act() => await _handler.Handle(new Business.UpdateJobStatus(update), CancellationToken.None);

            await Assert.ThrowsAsync<NotFoundException>(act);
        }
    }
}
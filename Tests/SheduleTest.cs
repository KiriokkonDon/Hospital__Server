using Hospital.Models;
using Hospital.Repositories;
using Hospital.Servise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Tests
{
    public class SheduleTest
    {
        private readonly SheduleService _sheduleService;
        private readonly Mock<IScheduleRep> _sheduleRepMock;
        private readonly Mock<IDoctorRep> _doctorRepMock;
        public SheduleTest()
        {
            _sheduleRepMock = new Mock<IScheduleRep>();
            _doctorRepMock = new Mock<IDoctorRep>();
            _sheduleService = new SheduleService(_sheduleRepMock.Object, _doctorRepMock.Object);
        }

        [Fact]
        public void CreateShedule_ShouldTrue()
        {
            _sheduleRepMock.Setup(repo => repo.Create(It.IsAny<Shedule>())).Returns(() => true);
            var date = new Shedule(1, DateTime.Today, DateTime.Today);
            var res = _sheduleService.CreateShedule(date);
            Assert.True(res.Success);
        }
        [Fact]
        public void Update_ShouldFail()
        {
            Shedule shedule = new()
            {
                Start_Time = new DateTime(2000, 5, 1),
                End_Time = new DateTime(2001, 5, 1)
            };
            var res = _sheduleService.UpdateShedule(shedule);

            Assert.True(res.IsFailure);
            Assert.Equal("Unable to update shedule", res.Error);
        }
        [Fact]

        public void GetSheduleNotFound_ShouldFail()
        {
            Doctors doctor = new();
            DateTime date = new();
            _sheduleRepMock.Setup(repository => repository.GetSheduleTableByDoctorAndDate(It.IsAny<Doctors>(), It.IsAny<DateTime>()))
                .Returns(() => null);
            _doctorRepMock.Setup(repository => repository.IsDoctorExist(It.IsAny<int>()))
                .Returns(() => true);
            var res = _sheduleService.GetSheduleTableByDoctorAndDate(doctor, date);

            Assert.True(res.IsFailure);
            Assert.Equal("Unable to find shedule", res.Error);
        }

    }
}
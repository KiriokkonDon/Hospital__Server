
using Hospital.Models;
using Hospital.Repositories;
using Hospital.Servise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class DoctorTest
    {
        private readonly DoctorService _doctorService;
        private readonly Mock<IDoctorRep> _doctorRepMock;

        public DoctorTest()
        {
            _doctorRepMock = new Mock<IDoctorRep>();
            _doctorService = new DoctorService(_doctorRepMock.Object);
        }
        [Fact]
        public void GetAll()
        {
            var res = _doctorService.GetAll();

            Assert.True(!res.IsFailure);
        }

        [Fact]
        public void CreateDoctor_SholdTrue()
        {
            _doctorRepMock.Setup(repository => repository.Create(It.IsAny<Doctors>()))
                .Returns(() => true);
            var doctor = new Doctors(0, "sdsds", new Specialization(1, "sdsd"));
            var res = _doctorService.CreateDoctor(doctor);

            Assert.True(res.Success);
        }

        [Fact]

        public void DoctorIsNotFound_ShouldFail()
        {
            _doctorRepMock.Setup(repository => repository.GetDoctorById(It.IsAny<int>()))
    .Returns(() => null);

            var res = _doctorService.GetDoctorById(1);

            Assert.True(res.IsFailure);
            Assert.Equal("Doctor not found", res.Error);
        }

        [Fact]
        public void GetAllDoctors_SholdTrue()
        {
            List<Doctors> doctors = new()
            {
                new Doctors(1, "sdsd", new Specialization(0, "sdsd")),
                 new Doctors(0, "dsds", new Specialization(0, "sdsd"))
            };
            IEnumerable<Doctors> d = doctors;
            _doctorRepMock.Setup(repository => repository.GetAll()).Returns(() => d);

            var result = _doctorService.GetAll();

            Assert.True(result.Success);
        }


        [Fact]

        public void ErrorDeleting_ShouldFail()
        {
            _doctorRepMock.Setup(repository => repository.GetDoctorById(It.IsAny<int>())).Returns(() => new Doctors(0, "dfdfdf", new Specialization(0, "a")));
            _doctorRepMock.Setup(repository => repository.Delete(It.IsAny<Doctors>())).Returns(() => false);

            var res = _doctorService.DeleteDoctor(new Doctors());

            Assert.True(res.IsFailure);
            Assert.Equal("Error while deleting.Try again later", res.Error);
        }

        [Fact]
        public void GetDoctorByNotCorrectSpec_ShouldFail()
        {
            _doctorRepMock.Setup(repository => repository.GetDoctorBySpecialization(It.IsAny<Specialization>())).Returns(() => null);

            var result = _doctorService.GetDoctorBySpecialization(new Specialization(0, "cqwecrqwe"));

            Assert.True(result.IsFailure);
            Assert.Equal("Doctor not found", result.Error);
        }



    }
}
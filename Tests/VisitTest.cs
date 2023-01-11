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
    public class VisitTest
    {
        private readonly VisitService _visitService;
        private readonly Mock<IVisitRep> _visitRepMock;
        private readonly Mock<IDoctorRep> _doctorRepMock;
        private readonly Mock<IUserRep> _userRepMock;
        private readonly Mock<ISpecializationRep> _specializationRepMock;

        public VisitTest()
        {
            _visitRepMock = new Mock<IVisitRep>();
            _userRepMock = new Mock<IUserRep>();
            _doctorRepMock = new Mock<IDoctorRep>();
            _specializationRepMock = new Mock<ISpecializationRep>();
            _visitService = new VisitService(_visitRepMock.Object, _doctorRepMock.Object, _userRepMock.Object, _specializationRepMock.Object);
        }

        [Fact]
        public void DoctorIsNotExist_ShouldFail()
        {
            _doctorRepMock.Setup(repository => repository.IsDoctorExist(It.IsAny<Doctors>()))
                .Returns(() => false);

            var res = _visitService.CreateVisit(new User(), new Doctors());

            Assert.True(res.IsFailure);
            Assert.Equal("Doctor is not exist", res.Error);
        }


        [Fact]
        public void UserIsNotExist_ShouldFail()
        {
            _userRepMock.Setup(repository => repository.IsUserExist(It.IsAny<User>()))
                .Returns(() => false);

            _doctorRepMock.Setup(repository => repository.IsDoctorExist(It.IsAny<Doctors>()))
                .Returns(() => true);

            var res = _visitService.CreateVisit(new User(), new Doctors());

            Assert.True(res.IsFailure);
            Assert.Equal("Patient is not exist", res.Error);
        }

        [Fact]
        public void UserNotPatient_ShouldFail()
        {
            _userRepMock.Setup(repository => repository.IsUserExist(It.IsAny<User>()))
                .Returns(() => true);

            _doctorRepMock.Setup(repository => repository.IsDoctorExist(It.IsAny<Doctors>()))
                .Returns(() => true);

            var res = _visitService.CreateVisit(new User() { Role = Role.Admin }, new Doctors());

            Assert.True(res.IsFailure);
            Assert.Equal("User is not a patient", res.Error);
        }

    }
}
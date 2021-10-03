using ILG_CRUD_Sample.BusinessLogic.Abstraction.Repositories;
using ILG_CRUD_Sample.BusinessLogic.Abstraction.Services;
using ILG_CRUD_Sample.BusinessLogic.Models;
using ILG_CRUD_Sample.BusinessLogic.ViewModels;
using ILG_CRUD_Sample.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ILG_CRUD_Sample.Web.Test
{

    public class EmployeesCRUD_Tests
    {
        #region Global Variables
        Mock<IEmployeeRepository> oEmployeeRepositoryMock;
        Mock<IEmployeeService> oEmployeeServiceMock;

        //List<EmployeeViewModel> lEmployeeViewModels;

        EmployeesController oEmployeesController;

        #endregion

        #region Constructor

        public EmployeesCRUD_Tests()
        {


            //vFillEmployeesList();
        }

        //private void vFillEmployeesList()
        //{
        //    lEmployeeViewModels = new List<EmployeeViewModel>();

        //    EmployeeViewModel oEmployeeViewModel = oEmployeeViewModelCreate(1, "Sayed", "Sayed@live.com", 40, DateTime.Now.AddYears(-40));
        //    lEmployeeViewModels.Add(oEmployeeViewModel);

        //    oEmployeeViewModel = oEmployeeViewModelCreate(2, "M!do", "Mido@live.com", 10, DateTime.Now.AddYears(10));
        //    lEmployeeViewModels.Add(oEmployeeViewModel);
        //}

        private EmployeeViewModel oEmployeeViewModelCreate(int nID, string sName, string sEmail, int nAge, DateTime dtiBirthDate)
        {
            EmployeeViewModel oEmployeeViewModel = new EmployeeViewModel();

            oEmployeeViewModel.ID = nID;
            oEmployeeViewModel.Name = sName;
            oEmployeeViewModel.Email = sEmail;
            oEmployeeViewModel.Age = nAge;
            oEmployeeViewModel.BirthDate = dtiBirthDate;

            return oEmployeeViewModel;
        }

        #endregion


        #region test cases

        [Fact]
        //[InlineData("Sayed@live.com")]
        //[InlineData("user3@email.com")]
        public async Task InsertEmployee_WithNewEmail_ReturnsOkResponse()
        {
            // arrange
            EmployeeViewModel oEmployeeViewModel = oEmployeeViewModelCreate(-1, "Sayed", "Sayed@live.com", 40, DateTime.Now.AddYears(-40));

            oEmployeeServiceMock = new Mock<IEmployeeService>();
            oEmployeeServiceMock.Setup(repo => repo.Insert(oEmployeeViewModel))
                .Returns(Task.FromResult(true));

            oEmployeesController = new EmployeesController(oEmployeeServiceMock.Object);

            ActionResult oActualActionResult = await oEmployeesController.Create(oEmployeeViewModel);

            Assert.IsAssignableFrom<ViewResult>(oActualActionResult);
        }

        public async Task InsertEmployee_WithPreviouslyAddedEmail_ReturnsOkResponse()
        {

        }

        #endregion







    }


}


/*
 
 
        List<OwnerMaster> users;
        Mock<IOwnerMasterRepository> mockRepo;
        public registrationTest()
        {
            mockRepo = new Mock<IOwnerMasterRepository>();
            users = new List<OwnerMaster>
            {
                new OwnerMaster(){ Id = "one" , FirstName = "first name", MiddleName="middle name", LastName="last name", EmailAddress="user1@email.com", IsBlocked= false, IsEnabled = true,
                    IsReviewedByAdmin = true, MobileNumber="01014409847", BirthDate= DateTime.Now},
                new OwnerMaster(){ Id = "Two", FirstName = "first name", MiddleName="middle name", LastName="last name", EmailAddress="user2@email.com", IsBlocked= false, IsEnabled = true,
                    IsReviewedByAdmin = true, MobileNumber="01114409847", BirthDate= DateTime.Now},
            };
        }

        [Theory]
        [InlineData("user1@email.com")]
        [InlineData("user3@email.com")]

        public async Task IsUserExistsByEmailTest(string email)
        {

            OwnerMasterService ownerMasterService = new OwnerMasterService(mockRepo.Object);
            mockRepo.Setup(repo => repo.GetAll(u => u.EmailAddress == email, null, false))
                 .Returns(users);


            bool excpectedOutput = users.Exists(u => u.EmailAddress == email);
            bool actualOutput = await ownerMasterService.bIsUserExixstsByEmail(email);

            Assert.Equal(excpectedOutput, actualOutput);

        }




        [Theory]
        [InlineData("01014409847")]
        [InlineData("01214409847")]

        public async Task IsUserExistsByPhoneTest(string phone)
        {
            OwnerMasterService ownerMasterService = new OwnerMasterService(mockRepo.Object);


            mockRepo.Setup(repo => repo.GetAll(u => u.MobileNumber == phone, null, false))
                .Returns(users);

            bool excpectedOutput = users.Exists(u => u.MobileNumber == phone); ;
            bool actualOutput = await ownerMasterService.IsUserExixstsByPhone(phone);

            Assert.Equal(excpectedOutput, actualOutput);


        }
 */
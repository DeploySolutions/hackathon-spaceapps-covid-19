using System.Threading.Tasks;
using DeploySolutions.Covid19Admin.Models.TokenAuth;
using DeploySolutions.Covid19Admin.Web.Controllers;
using Shouldly;
using Xunit;

namespace DeploySolutions.Covid19Admin.Web.Tests.Controllers
{
    public class HomeController_Tests: Covid19AdminWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
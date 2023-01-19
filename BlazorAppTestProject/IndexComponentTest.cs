using BlazorAppTestOgSikkerhed.Areas.Identity;
using BlazorAppTestOgSikkerhed.Code;
using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppTestProject;

// Husk at test skal være public
public class IndexComponentTest
{
    [Fact]
    public void TestIndexComponent()
    {
        // Arrange
        using var context = new TestContext(); // Laver en "sandkasse" af projektet og smider det ud bagefter
        context.Services.AddSingleton(new MyRoleHandler()); //Tilføj custom services til tildeling af admin
        context.Services.AddSingleton(new MyResourceHandler());
        context.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>(); //Tilføj identity service til validering af authenticated users
        

        var authorizationContext = context.AddTestAuthorization();
        authorizationContext.SetAuthorized("test@testMail.com");   
        authorizationContext.SetRoles("Admin");           

        // Act
        var index = context.RenderComponent<BlazorAppTestOgSikkerhed.Pages.Index>();


        // Assert
        //Assert.True(index.Instance.IsAuthenticated);
        Assert.True(index.Instance.IsAdmin);

    }
}

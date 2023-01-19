using BlazorAppTestOgSikkerhed.Areas.Identity;
using BlazorAppTestOgSikkerhed.Code;
using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppTestProject;
public class HTMLTest {


    [Fact]
    public void CheckNavBarLoginName() {
        // Arrange
        using var context = new TestContext(); // Laver en "sandkasse" af projektet og smider det ud bagefter
        context.Services.AddSingleton(new MyRoleHandler()); // Tilføj custom services til håndtering af autorisation og roller
        context.Services.AddScoped<AuthenticationStateProvider, 
            RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>(); //Tilføj identity service til validering af authenticated users

        var authorizationContext = context.AddTestAuthorization(); //  Opret ny context med Test autorisation
        authorizationContext.SetAuthorized("test@testMail.com");    // Opret ny autoriseret bruger

        // Act
        var index = context.RenderComponent<BlazorAppTestOgSikkerhed.Shared.LoginDisplay>();

        // Assert ()

        index.MarkupMatches(@"    <a href=""Identity/Account/Manage"">Hello, test@testMail.com!</a>
                                <form method=""post"" action=""Identity/Account/Logout"">
                                    <button type=""submit"" class=""nav-link btn btn-link"">Log out</button>
                                </form>");

    }


    [Fact]
    public void CheckHTML() {
        // Arrange
        using var context = new TestContext(); // Laver en "sandkasse" af projektet og smider det ud bagefter
        context.Services.AddSingleton(new MyRoleHandler()); // Tilføj custom services til håndtering af autorisation og roller
        context.Services.AddSingleton(new MyResourceHandler());
        context.Services.AddScoped<AuthenticationStateProvider, 
            RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>(); //Tilføj identity service til validering af authenticated users

        var authorizationContext = context.AddTestAuthorization(); //  Opret ny context
        authorizationContext.SetAuthorized("test@testMail.com");    // Opret ny autoriseret bruger

        // Act
        var index = context.RenderComponent<BlazorAppTestOgSikkerhed.Pages.Index>();

        // Assert (Tjek at HTML vises)
        index.MarkupMatches(@"        <h1>Hello, world!</h1>
                                        <h3>Du er logget ind.</h3>
                                        <p>
                                          <label>Name the text file
                                            <input value=""Text"" >
                                          </label>
                                        </p>
                                        <button class=""btn btn-primary"" >Create</button>
                                        <p></p>");

    }
    
}

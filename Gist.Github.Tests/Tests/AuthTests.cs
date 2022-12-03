﻿using Gist.Github.Model;

namespace Gist.Github.Tests;

public class AuthTests : TestBase
{
    [Test]
    public void Auth()
    {
        var user = new AccountData
        {
            Username = "githubtests-itis",
            Password = "g1thubTests"
        };
        
        Application.Navigation.OpenHomePage();
        Application.Auth.Login(user);
    }
}
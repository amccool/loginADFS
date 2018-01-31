using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using Owin;

namespace loginADFS
{
    public partial class Startup
    {
            // callback used to validate the certificate in an SSL conversation
            private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
            {
                bool result = false;
                if (cert.Subject.ToUpper().Contains("YourServerName"))
                {
                    result = true;
                }

                return result;
            }        
        
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            //Trust all certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                ((sender, certificate, chain, sslPolicyErrors) => true);

            //// trust sender
            //System.Net.ServicePointManager.ServerCertificateValidationCallback
            //    = ((sender, cert, chain, errors) => cert.Subject.Contains("YourServerName"));

            //// validate cert by calling a function
            //System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);


















            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            //app.SetDefaultSignInAsAuthenticationType(WsFederationAuthenticationDefaults.AuthenticationType);


            var cookieAuthOptions = new CookieAuthenticationOptions();
            app.UseCookieAuthentication(cookieAuthOptions);

            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = WsFederationAuthenticationDefaults.AuthenticationType
            //});


            var wsFedPassiveAuthOptions = new WsFederationAuthenticationOptions
            {
                MetadataAddress =
                    ConfigurationManager.AppSettings["ida:AdfsMetadataEndpoint"],
                Wtrealm = ConfigurationManager.AppSettings["ida:Audience"],

            };
            //// Azure Ws-Fed Passive federated authentication support 
            app.UseWsFederationAuthentication(wsFedPassiveAuthOptions);

            //    app.UseActiveDirectoryFederationServicesBearerAuthentication(
            //        new ActiveDirectoryFederationServicesBearerAuthenticationOptions
            //        {
            //            MetadataEndpoint = ConfigurationManager.AppSettings["ida:AdfsMetadataEndpoint"],
            //            TokenValidationParameters = new TokenValidationParameters()
            //            {
            //                ValidAudience = ConfigurationManager.AppSettings["ida:Audience"]
            //            }
            //        });

        }



        public partial class StartupXXXX
        {
            public void ConfigureAuth(IAppBuilder app)
            {
                //app.UseCookieAuthentication(new CookieAuthenticationOptions
                //{
                //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //    LoginPath = new PathString("/Account/Login")
                //});
                //app.UseExternalSignInCookie(DefaultAuthenticationTypes
                //    .ExternalCookie); // Facebook social identity provider passive flow support 
                //app.UseFacebookAuthentication(appId: "xxx",
                //    appSecret: "xxx"); // Azure OpenId Connect passive authentication and authorization support 
                //app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
                //{
                //    Client_Id = "xxx",
                //    Authority = "https://login.windows.net/xxx.onmicrosoft.com",
                //    ,
                //    Post_Logout_Redirect_Uri = "http://localhost:xxxxx/",
                //    Description = new Microsoft.Owin.Security.AuthenticationDescription
                //    {
                //        AuthenticationType = "OpenIdConnect",
                //        Caption = "Azue OpenId Connect"
                //    }
                //}); 
                //// Azure Ws-Fed Passive federated authentication support 
                //app.UseWsFederationAuthentication(new WsFederationAuthenticationOptions
                //{
                //    MetadataAddress =
                //        "https://login.windows.net/xxx.onmicrosoft.com/FederationMetadata/2007-06/FederationMetadata.xml",
                //    Wtrealm = "http://myapp/wsfed",
                //}); // Azure OAuth2 active flow support 
                //app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                //    new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                //    {
                //        Audience = "http://myapp/webapi",
                //        Tenant = "xxx.onmicrosoft.com",
                //        AuthenticationType = "OAuth2Bearer",
                //    }); // ADFS OAuth2 active flow support 
                //app.UseActiveDirectoryFederationServicesBearerAuthentication(
                //    new ActiveDirectoryFederationServicesBearerAuthenticationOptions
                //    {
                //        Audience = "http://myapp/webapi",
                //        MetadataEndpoint = "https://xxx/federationmetadata/2007-06/federationmetadata.xml"
                //    });

                //CookieAuthentication and ExternalSignInCookie – OWIN components to support cookie - based authentication

                //    FacebookAuthentication – OWIN component to support Facebook social identity provider passive flow

                //OpenIdConnectAuthentication – OWIN component to support Azure OpenId Connect passive authentication and authorization

                //    WsFederationAuthentication – OWIN component to support AAD Ws-Fed Passive federated authentication

                //    WindowsAzureActiveDirectoryBearerAuthentication – OWIN component to support AAD OAuth2 authorization code grant active flow

                //    ActiveDirectoryFederationServicesBearerAuthentication – OWIN component to support ADFS OAuth2 authorization code grant active flow
            }
        }
    }
}


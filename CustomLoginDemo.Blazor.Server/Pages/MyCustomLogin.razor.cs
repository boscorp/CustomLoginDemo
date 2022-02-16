using System.Threading.Tasks;
using DevExpress.ExpressApp.Blazor.Services;
using DevExpress.ExpressApp.Security;
using Microsoft.AspNetCore.Components;

namespace CustomLoginDemo.Blazor.Server.Pages
{
	public class MyCustomLoginPageBase : ComponentBase
	{

		[Inject] IXafApplicationProvider XafApplicationProvider { get; set; }
		[Inject] NavigationManager NavigationManager { get; set; }
		[Inject] IIdentityAuthenticationService IdentityAuthenticationService { get; set; }
		protected string UserName { get; set; }
		protected string Password { get; set; }
		protected void ProcessLogin()
		{
			var app = XafApplicationProvider.GetApplication();
			var logonParams = ((AuthenticationStandardLogonParameters)app.Security.LogonParameters);
			logonParams.UserName = UserName;
			logonParams.Password = Password;
			app.Logon();
		}
		public bool IsAuthenticated => IdentityAuthenticationService?.IsAuthenticated ?? true;
		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			if (IsAuthenticated)
			{
				NavigationManager.NavigateTo("");
			}
		}
	}
}

Asp.net core
Chapter 2 Notes:

asp-for -> to action

2. @model PartyInvites.Models.GuestResponse


@model PartyInvites.Models.GuestResponse


<label asp-for="Name">Your name:</label> -> this referes to GuestResponse.Name property
<input asp-for="Name" />
||

<label for="Name">Your name:</label>
<input type="text" id="Name" name="Name" value="">  => beide ist gleich


fur dropbox

<select asp-for="WillAttend">
<option value="">Choose an option</option>
<option value="true">Yes, I'll be there</option>
<option value="false">No, I can't come</option>
</select>



--- form element  yazilis sekli
{
<form asp-action="RsvpForm" method="post">
<div>
<label asp-for="Name">Your name:</label>
<input asp-for="Name" />
</div>
<div>
<label asp-for="Email">Your email:</label>
<input asp-for="Email" />
</div>
<div>
<label asp-for="Phone">Your phone:</label>
<input asp-for="Phone" />
</div>
<div>
<label>Will you attend?</label>
<select asp-for="WillAttend">
<option value="">Choose an option</option>
<option value="true">Yes, I'll be there</option>
<option value="false">No, I can't come</option>
</select>
</div>
<button type="submit">Submit RSVP</button>
</form>
}

--- LISTI VIEW PASS ETMEK UCUN

@model IEnumerable<PartyInvites.Models.GuestResponse>



--MODEL CLASSLARDA REQUIRED FIELDLER UCUN :

  [Required(ErrorMessage = "Please enter your name")]
  
  
  -------------------------------------------------------------
  REQUIRED OLDUGU UCUN MODEL.STATE YOXLANILMALI
  
  public ViewResult RsvpForm(GuestResponse guestResponse) {
if (ModelState.IsValid) {
Repository.AddResponse(guestResponse);
return View("Thanks", guestResponse);
} else {
return View();
}

---------------------------------------------
BUNLA  ERRORMESSAGE TEPEDE CIXARILIR
<div asp-validation-summary="All"></div>   -- 

mit hielfe dieses tag  check ModelState.IsValid



-----HIGHLIGHTING INVALID FIELDS  


mesaji yaninda cixarmaq ucun
 <input type="text" class="input-validation-error" data-val="true"
                   data-val-required="Please enter your phone number" id="Phone"
                   name="Phone" value="">
				   
				   
				   
#region STATICCORE DATALARI  WWWROOTDA OLUR

/css
/js

#endregion


--------------------------------------
dot net command line COMMANDS


dotnet new   //Creating a project


dotnet build && dotnet run  //Building and running
dotnet add package

dotnet tool  // Installing tool

libman //Managing client-side packages


dotnet new : Templates =>

web  //creates a project that is set up with the minimum code
mvc //ASP.NET Core project configured to use the MVC Framework.

webapp //ASP.NET Core project configured to use Razor Pages
blazorserver //ASP.NET Core project configured to use Blazor Server
angular
react
reactredux

globaljson  //add globaljson
sln    // add sln

dotnet new globaljson --sdk-version 3.1.101 --output MySolution/MyProject
dotnet new web --no-https --output MySolution/MyProject --framework netcoreapp3.1
dotnet new sln -o MySolution
dotnet sln MySolution add MySolution/MyProject


dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.1   // to add package


dotnet list package   // to list package

dotnet tool uninstall --global dotnet-ef       // to uninstlaa tools
dotnet tool install --global dotnet-ef --version 3.1.1    // add tools to communicate with db;


dotnet ef --help  

Client-side packages contain content that is delivered to the client, such as images, CSS stylesheets, JavaScript files, and static
HTML.

	dotnet tool uninstall --global Microsoft.Web.LibraryManager.Cli
dotnet tool install --global Microsoft.Web.LibraryManager.Cli --version 2.0.96





	------------------------------------------



	Enabling the MVC Framework


	public void ConfigureServices(IServiceCollection services)
{
	services.AddControllersWithViews();  ///add this 
}
app.UseEndpoints(endpoints => {
	//endpoints.MapGet("/", async context => {
	// await context.Response.WriteAsync("Hello World!");
	//});
	endpoints.MapDefaultControllerRoute();
});

-------------------- To check wether class o properties is null if null dont cause error


	string name = p?.Name;
decimal? price = p?.Price;




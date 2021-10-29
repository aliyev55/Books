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




Using the Null Conditional Operator
-------------------- To check wether class o properties is null if null dont cause error


	string name = p?.Name;
decimal? price = p?.Price;







#region Chaining 
Chaining in  class or Model class to deal wiith null/
	it means that each class has another class which it relates


    public class Product
{
    public string Name { get; set; }
    public decimal? Price { get; set; }

    public Product Related { get; set; }  /// <summary>
                                          /// fur chaining
                                          /// </summary>
                                          /// <returns></returns>
    public static Product[] GetProducts()
    {
        Product kayak = new Product
        {
            Name = "Kayak",
            Price = 275M
        };
        Product lifejacket = new Product
        {
            Name = "Lifejacket",
            Price = 48.95M
        };

        kayak.Related = lifejacket;   //chaining
        return new Product[] { kayak, lifejacket, null };
    }


    using chaining in Controller

    string relatedName = p?.Related?.Name;  // each of them can be null so p?.Related?
results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}",
name, price, relatedName));




Combining the Conditional and Coalescing Operators
-------------------------------------------

string name = p?.Name ?? "<No Name>";
decimal? price = p?.Price ?? 0;
string relatedName = p?.Related?.Name ?? "<None>";
#endregion

#region C# features

Enable NULLABLE
to enable nullable open edit Project File -> right click project and select EDIT PROJECT FILE and change ::


    <PropertyGroup>
<TargetFramework>netcoreapp3.1</TargetFramework>
<Nullable>enable</Nullable>
</PropertyGroup>
    ---------------------------------------------------------------



    C# supports automatically implemented properties
    public string Name { get; set; }
public decimal? Price { get; set; }
public Product Related { get; set; }

public string Name { get; set; }
...
is equivalent to the following code:
...
public string Name
{
    get { return name; }
    set { name = value; }
}

This feature allows me to define properties without having to implement the get and set bodies


    string interpolation :

    string.Format("Name: {0}, Price: {1}, Related: {2}",name, price, relatedName)


---------------------------------------------------------------------------------------------

    Using an Index Initializer

    Dictionary<string, Product> products = new Dictionary<string, Product> {
{ "Kayak", new Product { Name = "Kayak", Price = 275M } },
{ "Lifejacket", new Product{ Name = "Lifejacket", Price = 48.95M } }
};
return View("Index", products.Keys);

new version of C#  

    Dictionary<string, Product> products = new Dictionary<string, Product>
    {
        ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
        ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M }
    }



    new version of Switch
{


    switch (data[i])
    {
        case decimal decimalValue:    //if decimal do 
            total += decimalValue;
            break;
        case int intValue when intValue > 50: ///if intiger
            total += intValue;
            break;



    }


    case decimal decimalValue:  !!!This case statement matches any decimal value and assigns it to a new variable called decimalValue

-----------------------------------------------------------------------------------
Creating Filtering Extension Methods
          public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> productEnum, decimal minimumPrice)
    {
        foreach (Product prod in productEnum)
        {
            if ((prod?.Price ?? 0) >= minimumPrice)
            {
                yield return prod;   ///YIELD LIST SEKLINDE DONUR
            }
        }
    }

#endregion




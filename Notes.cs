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


  
    for filtering good example
        // filter extension elave edilir
            public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selector)
        {
            foreach (Product prod in productEnum)
            {
                if (selector(prod))
                {
                    yield return prod;
                }
            }
        }


    // funksiyalar yazilir
    sTAND alone function to pass to filter

        bool FilterByPrice(Product p)
    {
        return (p?.Price ?? 0) >= 20;
    }
    Func<Product, bool> nameFilter = delegate (Product prod) {
        return prod?.Name?[0] == 'S';
    };

    // 
    // sonra filtrelemeye oturulur
    decimal priceFilterTotal = productArray
.Filter(FilterByPrice)
.TotalPrices();
    decimal nameFilterTotal = productArray
    .Filter(nameFilter)
    .TotalPrices();




    bu sekildede yazila biler:

        decimal priceFilterTotal = productArray
.Filter(p => (p?.Price ?? 0) >= 20)
.TotalPrices();
    decimal nameFilterTotal = productArray
    .Filter(p => p?.Name?[0] == 'S')
    .TotalPrices();



   action with lambda

        public ViewResult Index() =>
View(Product.GetProducts().Select(p => p?.Name));
}

Lambda expressions for methods omit the return keyword and use => (goes to) to associate the method signature (including
its arguments) with its implementation



----------------------
    properties de asagidaki kodu istifade edib, maraqli netice alinir. properties with lambda expression 
    public bool NameBeginsWithS => Name?[0] == 'S';
--------------------

    ----------Type Inference and Anonymous Types---------------------------------




    --------- Feateure nameOf


    return View(products.Select(p =>
$"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}")); => result is Name:Vusal  Price: 10trl

#endregion


-------

#region Testing  UNIT TESTING--------------------------------------------------------------------
----------------------

3 Test Frameworks:


mstest --->>>>>This template creates a project configured for the MS Test framework, which is produced by Microsoft.
nunit ------->>>>>> This template creates a project configured for the NUnit framework.
xunit  ------>>>>>>>This template creates a project configured for the XUnit framework




  ////  proyek yaradilandan sonra icinde folderde bu komandlar calisdirilmali 
{
    dotnet new xunit - o SimpleApp.Tests--framework netcoreapp3.1
dotnet sln add SimpleApp.Tests
dotnet add SimpleApp.Tests reference SimpleApp
    }

   ------ Removing the Default Test Class

{
    Remove-Item SimpleApp.Tests/UnitTest1.cs   // it runs in VS package console

    }

    -----Add class Testing + add reference to Project

    unitTest 3 steps 

    arrange
    act
    assert

    --------------------------Sample--------

      [Fact]
public void CanChangeProductName()
{
    // Arrange
    var p = new Product { Name = "Test", Price = 100M };
    // Act
    p.Name = "New Name";
    //Assert
    Assert.Equal("New Name", p.Name);
}


Equal(expected, result)             This method asserts that the result is equal to the expected outcome. 
NotEqual(expected, result)          This method asserts that the result is not equal to the expected outcome.
True(result)                        This method asserts that the result is true.
False(result)                       This method asserts that the result is false.
IsType(expected, result)            This method asserts that the result is of a specific type.
IsNotType(expected, result)         This method asserts that the result is not a specific type.
IsNull(result)                      This method asserts that the result is null.
IsNotNull(result)                   This method asserts that the result is not null.
InRange(result, low, high)          This method asserts that the result falls between low and high.
NotInRange(result, low, high)       This method asserts that the result falls outside low and high.
Throws(exception, expression)       This method asserts that the specified expression throws a specific exception type.





    dotnet test for to run app   // command line run;


    Assert.Equal method that
accepts an argument that implements the IEqualityComparer<T> interface so that the objects can be compared


    ---------------------------------

    ferqli yazilis qaydasi :

       class FakeDataSource : IDataSource
{
    public FakeDataSource(Product[] data) => Products = data;
    public IEnumerable<Product> Products { get; set; }


    ----------------------------------


    To test create moq objects


        A better approach is to use a mocking package, which makes it easy to create fake—or mock—objects for tests.There are
many mocking packages available, but the one I use(and have for years) is called Moq

        dotnet add SimpleApp.Tests package Moq --version 4.13.1  install;


        SET mock data :

         var mock = new Mock<IDataSource>();
    // Arrange
    Product[] testData = new Product[] {
new Product { Name = "P1", Price = 75.10M },
new Product { Name = "P2", Price = 120M },
new Product { Name = "P3", Price = 110M }
};
    

    mock.SetupGet(m => m.Products).Returns(testData);



    The Mock object I created will fake the IDataSource interface. To create an implementation of the Product property, I use the
SetUpGet method, like this:
...
mock.SetupGet(m => m.Products).Returns(testData);


    The SetupGet method is used to implement the getter for a property.The argument to this method is a lambda expression
that specifies the property to be implemented, which is Products in this example.The Returns method is called on the result of the
SetupGet method to specify the result that will be returned when the property value is read.
...
}
#endregion














#region SportsCar
dotnet new globaljson --sdk - version 3.1.101--output SportsSln/SportsStore
dotnet new web --no - https--output SportsSln/SportsStore --framework netcoreapp3.1
dotnet new sln - o SportsSln
 dotnet sln SportsSln add SportsSln/SportsStore

 dotnet new xunit - o SportsSln / SportsStore.Tests--framework netcoreapp3.1
dotnet sln SportsSln add SportsSln/SportsStore.Tests
dotnet add SportsSln/SportsStore.Tests reference SportsSln/SportsStore

    dotnet add SportsSln/SportsStore.Tests package Moq --version 4.13.1

    -----------------

    ConfigureServices  ->used throughout the application and
that are accessed through a feature called dependency injection

    AddControllersWithViews ->sets up the shared objects required by applications using the MVC Framework


    ASP.NET Core receives HTTP requests and passes them along a request pipeline, which is populated with middleware
components registered in the Configure method

The Middleware Methods Used in Listing (Configure Metod)

UseDeveloperExceptionPage() ->This extension method displays details of exceptions that occur in the application,
UseStatusCodePages() ->This extension method adds a simple message to HTTP responses
UseStaticFiles() ->method enables support for serving static content from the wwwroot folder

    @using SportsStore.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

The @addTagHelper statement enables the built-in tag helpers, which I use later to create HTML elements



adding EF to sln

important 2 packages

dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.1
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.1



to install Global EF tools; First uninstall default tools and reload;
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 3.1.1



    connection String sample :

    "ConnectionStrings": {
    "SportsStoreConnection": "Server=(localdb)\\MSSQLLocalDB;Database=SportsStore;MultipleActiveResultSets=true; Integrated Security = true"

TIP:

    Each database server requires its own connection string format. A helpful site for formulating connection strings is
    www.connectionstrings.com.



        db context !


public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options)
    : base(options) { }
    public DbSet<Product> Products { get; set; }
}

IQueryable--->The IQueryable<T> interface is useful because it allows a collection of objects 
    to be queried efficiently
    Product objects from the database and then discard the ones that 
    I don’t want, which becomes an expensive operation as the
amount of data used by an application increases. 
    It is for this reason that the IQueryable<T> interface is typically used instead
of IEnumerable<T> in database repository interfaces and classes


Ienumerablede datani cekir sonra filtre edir Iquerable da selecti db gonderir



sONRA Dependency injection vasitesi ile Interface classa baglanir


//addmigration//
powerShellde dotnet ef migrations add Initial // migration elave etmek ucun

calismasa EF toolu yeniden Powershellden yuklemek lazimdir

//bu da package console  commands:
Add-Migration AddBlogCreatedTimestamp
Update-Database




initiate db ---->

Seed:  Sample---->

       public static void EnsurePopulated(IApplicationBuilder app)
{
    StoreDbContext context = app.ApplicationServices
    .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
    if (!context.Products.Any())
    {
        context.Products.AddRange(
        new Product
        {
            Name = "Kayak",
            Description = "A boat for one person",
            Category = "Watersports",
            Price = 275
        },
        new Product
        {
            Name = "Lifejacket",
            Description = "Protective and fashionable",
            Category = "Watersports",
            Price = 48.95m
        }, new Product
        {
            Name = "Soccer Ball",
            Description = "FIFA-approved size and weight",
            Category = "Soccer",
            Price = 19.50m
        },
new Product
{
Name = "Corner Flags",
Description = "Give your playing field a professional touch",
Category = "Soccer",
Price = 34.95m
},
new Product
{
Name = "Stadium",
Description = "Flat-packed 35,000-seat stadium",
Category = "Soccer",
Price = 79500
},
new Product
{
Name = "Thinking Cap",
Description = "Improve brain efficiency by 75%",
Category = "Chess",
Price = 16
},
new Product
{
Name = "Unsteady Chair",
Description = "Secretly give your opponent a disadvantage",
Category = "Chess",
Price = 29.95m
},
new Product
{
Name = "Human Chess Board",
Description = "A fun game for the family",
Category = "Chess",
Price = 75
},
new Product
{
Name = "Bling-Bling King",
Description = "Gold-plated, diamond-studded King",
Category = "Chess",
Price = 1200
}
);
        context.SaveChanges();
    }
}
    }


Explanation

    The static EnsurePopulated method receives an IApplicationBuilder argument, which is the interface used in the Configure
method of the Startup class to register middleware components to handle HTTP requests. IApplicationBuilder also provides
access to the application’s services, including the Entity Framework Core database context service.
The EnsurePopulated method obtains a StoreDbContext object through the IApplicationBuilder interface and calls the
Database.Migrate method if there are any pending migrations, which means that the database will be created and prepared so that
it can store Product objects. Next, the number of Product objects in the database is checked. If there are no objects in the database,
then the database is populated using a collection of Product objects using the AddRange method and then written to the database
using the SaveChanges method.


    then add 
    SeedData.EnsurePopulated(app); to Startup -> configuration() method;





What is Dependency Injection

using SportsStore.Models;
namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index() => View(repository.Products);
    }
}

When ASP.NET Core needs to create a new instance of the HomeController class to handle an HTTP request, it will inspect the
constructor and see that it requires an object that implements the IStoreRepository interface. To determine what implementation
class should be used, ASP.NET Core consults the configuration in the Startup class, which tells it that EFStoreRepository should be
used and that a new instance should be created for every request. ASP.NET Core creates a new EFStoreRepository object and uses it
to invoke the HomeController constructor to create the controller object that will process the HTTP request.
This is known as dependency injection, and its approach allows the HomeController object to access the application’s repository
through the IStoreRepository interface without knowing which implementation class has been configured.I could reconfigure
the service to use a different implementation class—one that doesn’t use Entity Framework Core, for example—and dependency
injection means that the controller will continue to work without changes.




    Mock Test of SportStore : 

   Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
mock.Setup(m => m.Products).Returns((new Product[] {
new Product {ProductID = 1, Name = "P1"},
new Product {ProductID = 2, Name = "P2"}
}).AsQueryable<Product>());
HomeController controller = new HomeController(mock.Object);
// Act
IEnumerable<Product> result =
(controller.Index() as ViewResult).ViewData.Model
as IEnumerable<Product>;
// Assert
Product[] prodArray = result.ToArray();
Assert.True(prodArray.Length == 2);
Assert.Equal("P1", prodArray[0].Name);
Assert.Equal("P2", prodArray[1].Name);





Must!!!!!!!!!!!!!!!

Pagination:

Adding Pagination
    public int PageSize = 4;

public ViewResult Index(int productPage = 1)
=> View(repository.Products
.OrderBy(p => p.ProductID)
.Skip((productPage - 1) * PageSize)
.Take(PageSize)); filter!!!
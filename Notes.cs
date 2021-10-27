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



My Comments
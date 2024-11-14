using WebApplication2.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//for working with XML data (for ex. in the request/response body)
builder.Services.AddControllers().AddXmlSerializerFormatters();

/* Add this if you want to use your custom model binding providers:*/
builder.Services.AddControllers(options =>
{
    //options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

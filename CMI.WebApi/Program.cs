var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
builder.Services.AddAuthorization();
builder.AddAuthenticationServices<AuthController>(CmiDataContext.AppName);
builder.Services.Configure();
builder.Services.AddAutoMapper(mpr => { }, typeof(Program).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CMI", Version = "V 01" });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.EnableSecurityOptions((securityOptions) =>
{
    securityOptions.AddHttpVerbs("GET", true);
    securityOptions.AddHttpVerbs("POST", true);
    securityOptions.EnableAllSecurityOptions();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Content")),
        RequestPath = "/Content"
    });
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIs V 01");
        c.InjectStylesheet("/Content/Swagger.css");
    });
}
app.UseRouting();
app.UseAuthenticationServices();
app.Run();
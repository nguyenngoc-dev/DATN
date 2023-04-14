using DocumentFormat.OpenXml.Bibliography;
using Perfume.Common;
using Perfume.DAL;
using Perfume.BL;


var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
// Dependency injection
builder.Services.AddScoped(typeof(IBaseDAL<>), typeof(BaseDAL<>));
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped<IDataContext, DataContext>();
builder.Services.AddScoped<IProductBL, ProductBL>();
builder.Services.AddScoped<IProductDAL, ProductDAL>();
builder.Services.AddScoped<ICategoryBL, CategoryBL>();
builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
builder.Services.AddScoped<IProductImageDAL, ProductImageDAL>();
builder.Services.AddScoped<IProductImageBL, ProductImageBL>();
builder.Services.AddScoped<ISaleOrderDAL, SaleOrderDAL>();
builder.Services.AddScoped<ISaleOrderBL, SaleOrderBL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
// Gán connection string cho MySQLConnectionString
DataContext.MySQLConnectionString = builder.Configuration.GetConnectionString("MySqlConnectionString");
// Validate sử dụng model state
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
var app = builder.Build();
app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
//app cors
app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseAuthorization();
//app.UseCors(prodCorsPolicy);
app.UseCors(MyAllowSpecificOrigins);


app.MapControllers();

app.Run();
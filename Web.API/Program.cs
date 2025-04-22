using Reopsitre;
using Reopsitre.IReopsitre;
using Reopsitre.Reopsitre;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IReopsitre<>), typeof(Repositre<>));
builder.Services.AddScoped<IUserReopsitre, UserReopsitre>();
builder.Services.AddScoped<IJobDescriptionReopsitre, JobDescriptionReopsitre>();
builder.Services.AddScoped<IErrorLogReopsitre, ErrorLogReopsitre>();
builder.Services.AddScoped<IMedicineReopsitre, MedicineReopsitre>();
builder.Services.AddScoped<IMedicineDepartmentReopsitre, MedicineDepartmentRepositre>();
builder.Services.AddScoped<IStoreReopsitre, StoreReopsitre>();
builder.Services.AddScoped<ISupplierReopsitre, SupplierReopsitre>();






var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
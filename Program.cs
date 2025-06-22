using Microsoft.EntityFrameworkCore;
using WolfGame.Context;
using WolfGame.IRepo;
using WolfGame.IService;
using WolfGame.Repo;
using WolfGame.Service;

var builder = WebApplication.CreateBuilder(args);

// 讀取連線字串
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 加入 DbContext
builder.Services.AddDbContext<WolfGameDbContext>(options =>
    options.UseSqlServer(connectionString));

// 加入 SignalR + CORS
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("http://localhost:5173") // Vue 的開發網址
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // 必須要這個，SignalR 才能建立 WebSocket
    });
});


builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 開發模式用 Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(); // 放在 app.UseRouting() 之前（如果有的話）

app.UseHttpsRedirection();

// ✅ 這裡註冊 SignalR Hub
app.MapHub<ChatHub>("/chatHub");

app.UseAuthorization();

app.MapControllers();

app.Run();
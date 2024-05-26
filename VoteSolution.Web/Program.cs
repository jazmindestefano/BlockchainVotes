using Microsoft.Extensions.DependencyInjection;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using VoteSolution.Services;
using VoteSolution.Services.Interfaces;
using VoteSolution.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBlockchainService, BlockchainService>();
builder.Services.AddScoped<IVoteService, VoteService>();

// Registrar Web3 como singleton
builder.Services.AddSingleton<Web3>(provider =>
{
    var url = "https://sepolia.infura.io/v3/44b1e7e5c8894ab281c33f5fe6a22bff";
    var privateKey = "3780da9b21f8a5406ba4ec40cd5d21126efe6caa4c6a769c9449e3c51282af26";
    var account = new Account(privateKey);
    var web3 = new Web3(account, url);
    return web3;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

using Microsoft.EntityFrameworkCore;
using JA_API_BurgerPromo;
using JA_API_BurgerPromo.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace JA_API_BurgerPromo.Controllers;

public static class JA_BurgerEndpoints
{
    public static void MapJA_BurgerEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/JA_Burger").WithTags(nameof(JA_Burger));

        group.MapGet("/", async (DataContext db) =>
        {
            return await db.JA_Burger.ToListAsync();
        })
        .WithName("GetAllJA_Burgers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<JA_Burger>, NotFound>> (int id, DataContext db) =>
        {
            return await db.JA_Burger.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is JA_Burger model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetJA_BurgerById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, JA_Burger jA_Burger, DataContext db) =>
        {
            var affected = await db.JA_Burger
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, jA_Burger.Id)
                    .SetProperty(m => m.Name, jA_Burger.Name)
                    .SetProperty(m => m.WithCheese, jA_Burger.WithCheese)
                    .SetProperty(m => m.Precio, jA_Burger.Precio)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateJA_Burger")
        .WithOpenApi();

        group.MapPost("/", async (JA_Burger jA_Burger, DataContext db) =>
        {
            db.JA_Burger.Add(jA_Burger);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/JA_Burger/{jA_Burger.Id}",jA_Burger);
        })
        .WithName("CreateJA_Burger")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, DataContext db) =>
        {
            var affected = await db.JA_Burger
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteJA_Burger")
        .WithOpenApi();
    }
}

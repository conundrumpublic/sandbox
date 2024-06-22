using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Data.Repositories;

namespace Sandbox.Controllers;

[AllowAnonymous]
public class UserController(UserRepository repo) : Controller
{
    [HttpGet]
    public async Task<JsonResult> GetAll() =>
        Json(await repo.Get(e => new { e.First, e.Last }));
}
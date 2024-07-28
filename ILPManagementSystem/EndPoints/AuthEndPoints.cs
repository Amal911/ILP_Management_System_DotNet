using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Linq;
using ILPManagementSystem.Data;

namespace ILPManagementSystem.EndPoints
{
    public static class AuthEndPoints
    {
        public static void ConfigureAuthEndPoints(this WebApplication app)
        {
            app.MapGet("/getUserRole/{token}", async (string token) =>
            {
                Dictionary<string, dynamic> results = new Dictionary<string, dynamic>();
                if (!string.IsNullOrEmpty(token))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                    if (jsonToken != null)
                    {
                        var claims = jsonToken.Claims;

                        // UPN From Jwt token (Unique Principle Name) = Mail id
                        var upn = claims.FirstOrDefault(c => c.Type == "upn")?.Value;
                        /*var appName = claims.FirstOrDefault(c => c.Type == "app_displayname")?.Value;*/

                        if (upn != null)
                        {
                            // Fetch email id from employee database.
                            using (var scope = app.Services.CreateScope())
                            {
                                var dbContext = scope.ServiceProvider.GetRequiredService<ApiContext>();  // ManageUserContext is your context name.
                                var user = dbContext.Users.FirstOrDefault(e => e.EmailId == upn);

                                if (user != null)
                                {
                                    // Change code with respect to your database tables and data.
                                    // Return the employee details such as email, name, role, department
                                    var roles = dbContext.Roles.FirstOrDefault(r => r.Id == user.RoleId);

                                    /*Console.WriteLine($"Application Name :: {appName}");
                                    results.Add("appName", appName);*/
                                    Console.WriteLine($"User Name :: {user.FirstName}");
                                    results.Add("UserId", user.Id);
                                    results.Add("UserName", $"{user.FirstName} {user.LastName}");
                                    Console.WriteLine($"User Email:: {user.EmailId}");
                                    results.Add("UserEmail", user.EmailId);
                                    Console.WriteLine($"User Role ID :: {user.RoleId}");
                                    Console.WriteLine($"User Role :: {roles?.RoleName}");
                                    results.Add("roleName", roles?.RoleName);
                                    // All these data appName, employee.EmpName, employee.Email, employee.RoleId, departments.DepName, roles.RoleName should return as API response.
                                }
                                else
                                {
                                    Console.WriteLine($"{upn} is not found in Employees database.");
                                    return Results.NotFound($"{upn} is not found in Employees database.");
                                }
                            }
                        }
                        else
                        {
                            return Results.BadRequest("UPN or app_displayname not found in token.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Token cannot be converted to JwtSecurityToken");
                        return Results.BadRequest("Invalid token.");
                    }
                }
                else
                {
                    return Results.NotFound("Token not found");
                }

                return Results.Ok(results); // Return the data stored in results dictionary
            });
        }
    }
}

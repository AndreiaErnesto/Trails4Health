using Microsoft.AspNetCore.Identity;
using ProjetoTrails4Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Data
{
    public class UsersSeedData
    {
        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string profName = "prof";
            const string profPass = "Secret123$";
            const string turistaName = "john";
            const string turistaPass = profPass;


            if (!await roleManager.RoleExistsAsync("Professor"))
            {
                await roleManager.CreateAsync(new IdentityRole("Professor"));
            }

            if (!await roleManager.RoleExistsAsync("Turista"))
            {
                await roleManager.CreateAsync(new IdentityRole("Turista"));
            }

            // Create other roles ...

            ApplicationUser prof = await userManager.FindByNameAsync(profName);
            if (prof == null)
            {
                prof = new ApplicationUser { UserName = profName };
                await userManager.CreateAsync(prof, profPass);
            }

            if (!await userManager.IsInRoleAsync(prof, "Professor"))
            {
                await userManager.AddToRoleAsync(prof, "Professor");
            }

            ApplicationUser turista = await userManager.FindByNameAsync(turistaName);
            if (turista == null)
            {
                turista = new ApplicationUser { UserName = turistaName };
                await userManager.CreateAsync(turista, turistaPass);
            }

            if (!await userManager.IsInRoleAsync(turista, "Turista"))
            {
                await userManager.AddToRoleAsync(turista, "Turista");
            }
        }
    }
}


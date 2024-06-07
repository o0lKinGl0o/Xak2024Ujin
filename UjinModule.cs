using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplication3
{
    public class UjinModule
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly ApplicationDbContext _context;

        public UjinModule(ApplicationDbContext context)
        {
            _context = context; // Контекст базы данных.
        }

        public async Task<IActionResult> UjinRequestAuth(string Email, string Password, string username) {
            var request = new AuthUjinRequest
            {
                login = Email,
                password = Password
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api-uae-test.ujin.tech/api/v1/auth/crm/authenticate", content);


            if (response.IsSuccessStatusCode) {
                var responseContent = await response.Content.ReadAsStringAsync();
                var decodedContent = System.Text.RegularExpressions.Regex.Unescape(responseContent);

                var authResponse = JsonConvert.DeserializeObject<AuthUjinResponse>(decodedContent);
                if (authResponse.error == 0) {
                    var token = authResponse.data.user.token;
                    var user = await _context.users.FirstOrDefaultAsync(u => u.Username == username);
                    if (user != null) {
                        user.ujinToken = token;
                        _context.Update(user);
                        _context.SaveChanges();
                        return new OkObjectResult(new { decodedContent });
                    } else
                    {
                        return new UnauthorizedResult();
                    }
                } else {
                    return new UnauthorizedResult();
                }
            } else {
                return new UnauthorizedResult();
            }
        }
    }
}

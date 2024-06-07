using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebApplication3
{
    public class AuthUjinResponse
    {
        public string command { get; set; }
        public string message { get; set; }
        public int error { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public User user { get; set; }
        public Account[] accounts { get; set; }
    }

    public class User
    {
        public int user_id { get; set; }
        public string token { get; set; }
        public string user_fullname { get; set; }
        public string user_name { get; set; }
        public string user_surname { get; set; }
        public string user_patronymic { get; set; }
        public string user_mail { get; set; }
        public long user_phone { get; set; }
        public string user_avatar { get; set; }
    }

    public class Account
    {
        public int id { get; set; }
        public string title { get; set; }
        public object logo { get; set; }
        public string token { get; set; }
        public Role role { get; set; }
        public Widgets widgets { get; set; }
        public Permissions permissions { get; set; }
    }

    public class Role
    {
        public int id { get; set; }
        public string title { get; set; }
        public bool is_update_locked { get; set; }
        public Rules rules { get; set; }
    }

    public class Rules
    {
        public Dictionary<string, Section> sections { get; set; }
    }

    public class Section
    {
        public bool access { get; set; }
        public bool enabled { get; set; }
    }

    public class Widgets
    {
        public bool schedule { get; set; }
        public bool indicators { get; set; }
        public bool accidents_critical { get; set; }
        public bool accidents_tickets { get; set; }
        public bool devices { get; set; }
        public bool doors { get; set; }
        public bool signals { get; set; }
        public bool lateness { get; set; }
        public bool users { get; set; }
        public bool tickets { get; set; }
    }

    public class Permissions
    {
        public bool people_section_all_restriction { get; set; }
        public bool apartment_acceptance_section_all_restriction { get; set; }
        public bool alarms_section_all_restriction { get; set; }
        public bool journal_user_actions_section_all_restriction { get; set; }
        public bool events_log_section_all_restriction { get; set; }
        public bool doors_section_all_restriction { get; set; }
        public bool containers_section_all_restriction { get; set; }
        public bool company_section_all_restriction { get; set; }
        public bool parking_lots_section_all_restriction { get; set; }
        public bool stuff_section_all_restriction { get; set; }
        public bool access_groups_section_all_restriction { get; set; }
        public bool statistics_section_all_restriction { get; set; }
        public bool counters_section_all_restriction { get; set; }
        public bool voting_section_all_restriction { get; set; }
        public bool works_section_all_restriction { get; set; }
        public bool users_section_all_restriction { get; set; }
        public bool tickets_section_all_restriction { get; set; }
        public bool market_offers_section_all_restriction { get; set; }
        public bool messages_section_all_restriction { get; set; }
        public bool reports_section_all_restriction { get; set; }
        public bool quarantine_section_all_restriction { get; set; }
        public bool objects_section_all_restriction { get; set; }
        public bool calls_section_all_restriction { get; set; }
        public bool cctv_section_all_restriction { get; set; }
        public bool guests_section_all_restriction { get; set; }
        public bool dashboard_section_all_restriction { get; set; }
        public bool parking_section_all_restriction { get; set; }
        public bool barriers_section_all_restriction { get; set; }
        public bool announcements_section_all_restriction { get; set; }
        public bool metrics_section_all_restriction { get; set; }
        public bool event_service_section_all_restriction { get; set; }
        public bool access_keys_section_all_restriction { get; set; }
        public bool vehicles_section_all_restriction { get; set; }
        public bool profile_section_all_restriction { get; set; }
        public bool statistics_communication_section_all_restriction { get; set; }
        public bool connections_section_all_restriction { get; set; }
        public bool tickets_types_section_all_restriction { get; set; }
        public bool roles_section_all_restriction { get; set; }
        public bool tickets_display_section_all_restriction { get; set; }
        public bool passes_section_all_restriction { get; set; }
        public bool tenants_section_all_restriction { get; set; }
        public bool enterprise_contractor_section_all_restriction { get; set; }
        public bool equipment_section_all_restriction { get; set; }
        public bool rent_objects_section_all_restriction { get; set; }
        public bool apartments_section_all_restriction { get; set; }
        public bool devices_hints_section_all_restriction { get; set; }
        public bool appointment_section_all_restriction { get; set; }
        public bool polls_section_all_restriction { get; set; }
        public bool enterprises_section_all_restriction { get; set; }
        public bool security_section_all_restriction { get; set; }
        public bool market_companies_section_all_restriction { get; set; }
        public bool news_section_all_restriction { get; set; }
        public bool intercoms_section_all_restriction { get; set; }
    }

    //public static async Task<IActionResult> UjinRequestAuth(string Email, string Password)
    //{
    //    var request = new AuthUjinRequest
    //    {
    //        login = Email,
    //        password = Password
    //    };

    //    var json = JsonConvert.SerializeObject(request);
    //    var content = new StringContent(json, Encoding.UTF8, "application/json");

    //    var response = await client.PostAsync("https://api-uae-test.ujin.tech/api/v1/auth/crm/authenticate", content);

    //    if (response.IsSuccessStatusCode)
    //    {
    //        var responseContent = await response.Content.ReadAsStringAsync();
    //        var decodedContent = System.Text.RegularExpressions.Regex.Unescape(responseContent);
    //        Console.WriteLine("Response: " + decodedContent);

    //        var authResponse = JsonConvert.DeserializeObject<AuthUjinResponse>(decodedContent);

    //        if (authResponse.error == 0)
    //        {
    //            var token = authResponse.data.user.token;
    //            return new OkObjectResult(new { Token = token });
    //        }
    //        else
    //        {
    //            return new BadRequestObjectResult(new { Error = authResponse.message });
    //        }
    //    }
    //    else
    //    {
    //        return new UnauthorizedResult();
    //    }
    //}

}

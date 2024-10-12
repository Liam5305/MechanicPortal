using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace MechanicPortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string? EmployeeData { get; set; }
        public string? VehicleData { get; set; }

        public async Task<IActionResult> OnPost()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Admin/AdminLogin");
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                EmployeeData = JsonConvert.SerializeObject(GetEmployeeData());
                VehicleData = JsonConvert.SerializeObject(GetVehicleData());
                _logger.LogInformation($"Employee Data: {EmployeeData}");
                _logger.LogInformation($"Vehicle Data: {VehicleData}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching chart data");
                EmployeeData = "[]";
                VehicleData = "[]";
            }
        }

        private List<ChartData> GetEmployeeData()
        {
            var data = new List<ChartData>();
            try
            {
                using (var connection = new SqliteConnection("Data Source=MechanicPortalContext-871c2ca5-ba3a-4149-89ed-487221d9b0c3.db"))
                {
                    connection.Open();
                    _logger.LogInformation("Database connection opened");

                    // Count total employees
                    var countCommand = connection.CreateCommand();
                    countCommand.CommandText = "SELECT COUNT(*) FROM Employee";
                    var totalEmployees = (long)countCommand.ExecuteScalar();
                    _logger.LogInformation($"Total employees in database: {totalEmployees}");

                    var command = connection.CreateCommand();
                    command.CommandText = @"
                            SELECT 
                            CASE 
                                WHEN Country IS NULL OR Country = '' THEN 'Unknown'
                                ELSE Country 
                            END AS Country, 
                            COUNT(*) as Count
                            FROM Employee
                            WHERE Active = 1
                            GROUP BY Country
                            ORDER BY Count DESC
                            LIMIT 20";

                    _logger.LogInformation("Executing employee data query");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var country = reader.GetString(0);
                            var count = reader.GetInt32(1);
                            _logger.LogInformation($"Country: {country}, Count: {count}");
                            data.Add(new ChartData
                            {
                                Label = country,
                                Value = count
                            });
                        }
                    }

                    _logger.LogInformation($"Total data points: {data.Count}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching employee data");
            }

            return data;
        }

        private List<ChartData> GetVehicleData()
        {
            var data = new List<ChartData>();
            try
            {
                using (var connection = new SqliteConnection("Data Source=MechanicPortalContext-871c2ca5-ba3a-4149-89ed-487221d9b0c3.db"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                    SELECT 
                        CASE 
                            WHEN Make IS NULL OR Make = '' THEN 'Unknown'
                            ELSE Make 
                        END AS Make, 
                        COUNT(*) as Count
                    FROM Vehicle
                    WHERE IsMOTd = 0
                    GROUP BY Make
                    ORDER BY Count DESC
                    LIMIT 20";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new ChartData
                            {
                                Label = reader.GetString(0),
                                Value = reader.GetInt32(1)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching vehicle data");
            }
            return data;
        }

        public class ChartData
        {
            public required string Label { get; set; }
            public int Value { get; set; }
        }
    }
}
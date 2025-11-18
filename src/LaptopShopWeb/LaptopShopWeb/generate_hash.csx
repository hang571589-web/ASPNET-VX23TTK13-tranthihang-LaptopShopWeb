#r "nuget: BCrypt.Net-Next, 4.0.3"
using BCrypt.Net;

var adminHash = BCrypt.HashPassword("Admin@123", 11);
var customerHash = BCrypt.HashPassword("Customer@123", 11);

Console.WriteLine($"Admin hash: {adminHash}");
Console.WriteLine($"Customer hash: {customerHash}");

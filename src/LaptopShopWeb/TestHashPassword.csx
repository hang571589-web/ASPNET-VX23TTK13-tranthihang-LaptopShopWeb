using BCrypt.Net;

Console.WriteLine("Generating BCrypt hashes...\n");

// Hash for Admin@123
var adminHash = BCrypt.HashPassword("Admin@123", 11);
Console.WriteLine($"Admin@123 hash: {adminHash}");
Console.WriteLine($"Verify Admin@123: {BCrypt.Verify("Admin@123", adminHash)}\n");

// Hash for Customer@123
var customerHash = BCrypt.HashPassword("Customer@123", 11);
Console.WriteLine($"Customer@123 hash: {customerHash}");
Console.WriteLine($"Verify Customer@123: {BCrypt.Verify("Customer@123", customerHash)}\n");

// Test old hashes
var oldAdminHash = "$2a$11$8vJ5qZ4xKZ.zQX8YqVXxOedGFm5p0Qk9jLhF7YXvGzF5NqRXVZGXi";
var oldCustomerHash = "$2a$11$vN3dK5FqmJ6xLpQYdN.8KeHZwQX7yF1gKpZ8LmVxY9kNqW2PzRtOy";

Console.WriteLine("Testing old hashes:");
Console.WriteLine($"Old admin hash with 'Admin@123': {BCrypt.Verify("Admin@123", oldAdminHash)}");
Console.WriteLine($"Old customer hash with 'Customer@123': {BCrypt.Verify("Customer@123", oldCustomerHash)}");

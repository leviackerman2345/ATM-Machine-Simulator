# ATM Sim v1.0

A Windows Forms ATM machine simulator built with `.NET 10`.

## Features

- Card number entry screen
- PIN/password screen
- Main dashboard after login
- Balance inquiry
- Cash withdrawal
- Cash deposit
- PIN change
- Logout
- Popup error messages for invalid card numbers and incorrect PINs

## How it works

The app uses a simple flow:

1. **Card Entry**
   - The user enters a 16-digit ATM card number.
   - The app checks whether the card is registered.

2. **Password / PIN**
   - If the card is valid, the user is sent to the PIN screen.
   - The app verifies the entered PIN.

3. **Dashboard**
   - After successful authentication, the user can use ATM actions like balance, withdraw, deposit, change PIN, and logout.

## Demo Accounts

You can test the simulator with these sample accounts:

| Card Number | PIN  | Name | Balance |
|------------|------|------|---------|
| 1234567890123456 | 1234 | John Doe | $5000.00 |
| 9876543210987654 | 5678 | Jane Smith | $3500.00 |
| 5555666677778888 | 9999 | Bob Johnson | $7200.00 |

## Project Structure

- `Program.cs` - application startup
- `Account.cs` - account model
- `ATMCore.cs` - ATM business logic
- `CardEntryForm.cs` / `CardEntryForm.Designer.cs` - first screen for card entry
- `PasswordForm.cs` / `PasswordForm.Designer.cs` - PIN entry screen
- `DashboardForm.cs` / `DashboardForm.Designer.cs` - main ATM dashboard
- `Form1.cs` / `Form1.Designer.cs` - legacy form files kept in the project

## Requirements

- Visual Studio Community 2026 or compatible version
- `.NET 10` SDK
- Windows OS for WinForms

## Running the Project

1. Open the solution in Visual Studio.
2. Restore packages if needed.
3. Build the project.
4. Run the app.

## Notes

- This is a simulator and does not connect to a real banking system.
- The demo data is stored in memory and resets when the app closes.

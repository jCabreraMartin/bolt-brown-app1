# Test Users - Time Tracking Application

## Login Credentials

The application includes the following pre-loaded users for testing. All share the same password.

| # | Username    | Password | Full Name                     | Email                      |
|---|------------|----------|-------------------------------|----------------------------|
| 1 | jgarcia    | Pass123! | Juan Garcia Lopez             | jgarcia@company.com        |
| 2 | mrodriguez | Pass123! | Maria Rodriguez Fernandez     | mrodriguez@company.com     |
| 3 | clopez     | Pass123! | Carlos Lopez Martin           | clopez@company.com         |
| 4 | anavarro   | Pass123! | Ana Navarro Ruiz              | anavarro@company.com       |
| 5 | psanchez   | Pass123! | Pedro Sanchez Gomez           | psanchez@company.com       |

## Pre-loaded Data

### Available Charge Accounts

| Code     | Description                      |
|----------|----------------------------------|
| PROJ-001 | Project Alpha - Development      |
| PROJ-002 | Project Beta - Maintenance       |
| PROJ-003 | Project Gamma - Consulting       |
| INT-001  | Internal Training                |
| INT-002  | Internal Meetings                |
| INT-003  | Administrative Management        |
| VAC-001  | Vacation                         |
| SIC-001  | Sick Leave                       |

### Sample Time Entries

The following users have time entries pre-loaded for the current fortnight:

- **Juan Garcia** (`jgarcia`): 6 hours/day on PROJ-001 and 2 hours/day on INT-002 (first 5 weekdays).
- **Maria Rodriguez** (`mrodriguez`): 4 hours/day on PROJ-002, 3.5 hours/day on PROJ-003, and 0.5 hours/day on INT-001 (first 5 weekdays).

Users `clopez`, `anavarro`, and `psanchez` have no pre-loaded entries and can be used to test fresh time registration.

## Notes

- Authentication is a local simulation (does not use actual Entra ID in the pilot).
- The SQLite database is created automatically on first application launch.
- Dummy data is only seeded if the database is empty.

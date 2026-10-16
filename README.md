# RaceDayAPI

## Project Description

RaceDayAPI is an ASP.NET Core Web API for managing race day information.

## Technologies Used

* C#
* ASP.NET Core Web API
* SQL Server
* Entity Framework Core
* xUnit
* GitHub Actions

## Build and Test
  
GitHub Actions automatically builds the project and runs unit tests when changes are pushed to the repository.

## Running Unit Tests

The project includes an xUnit test project named `RaceDayAPI.Tests`.

## Setup Instructions

1. Install Visual Studio and the .NET SDK required by the project.
2. Install or configure Microsoft SQL Server.
3. Clone or download this GitHub repository.
4. Open the RaceDayAPI solution in Visual Studio.
5. Open `appsettings.json` and check that the database connection string matches your SQL Server configuration.
6. Restore the NuGet packages.
7. Build the solution.
8. Run the RaceDayAPI project.
9. Open the Swagger page in your browser to view and test the API endpoints.

## Running Unit Tests

1. Open the solution in Visual Studio.
2. Select Test and open Test Explorer.
3. Click Run All.
4. Check the results to confirm that the tests pass.

The project includes an xUnit test project named `RaceDayAPI.Tests`.

## User Roles

### Participant

A Participant represents a person who takes part in race events. This role is associated with participant information and event enrolments.

### Organiser

An Organiser represents a person responsible for organising race events. This role is associated with organiser information and event management.

The API validates the user role during registration. The accepted roles are Participant and Organiser.

## API Endpoints

The API includes user registration and login endpoints, as well as functionality for managing race-day data.

The available controllers and endpoints can be explored through Swagger while the application is running.

## Continuous Integration and Continuous Delivery (CI/CD)

GitHub Actions automatically builds the project and runs the available unit tests when changes are pushed to the repository.

The successful workflow screenshot is included below.

![GitHub Actions successful build](github-actions-green-build.png)

## Demonstration Video

YouTube demonstration: **Add your unlisted YouTube video link here after uploading your video.**




To run the tests in Visual Studio:

1. Open the solution.
2. Select **Test → Test Explorer**.
3. Click **Run All**.
4. Confirm that all tests pass.

The GitHub Actions workflow also builds the project and runs the available tests automatically.


## Successful Build

The screenshot of the successful GitHub Actions build will be added to this repository.
![GitHub Actions successful build](github-actions-green-build.png)


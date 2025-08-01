# Smartwyre Developer Test Instructions

In the 'RebateService.cs' file you will find a method for calculating a rebate. At a high level the steps for calculating a rebate are:

 1. Lookup the rebate that the request is being made against.
 2. Lookup the product that the request is being made against.
 2. Check that the rebate and request are valid to calculate the incentive type rebate.
 3. Store the rebate calculation.

What we'd like you to do is refactor the code with the following things in mind:

 - Adherence to SOLID principles
 - Testability
 - Readability
 - Currently there are 3 known incentive types. In the future the business will want to add many more incentive types. Your solution should make it easy for developers to add new incentive types in the future.

We’d also like you to 
 - Add some unit tests to the Smartwyre.DeveloperTest.Tests project to show how you would test the code that you’ve produced 
 - Run the RebateService from the Smartwyre.DeveloperTest.Runner console application accepting inputs

The only specific 'rules' are:

- The solution should build
- The tests should all pass

You are free to use any frameworks/NuGet packages that you see fit. You should plan to spend around 1 hour completing the exercise.

https://motiff.com/file/qguUcCyqGaaEuJtGfmjtx4j?nodeId=0%3A1&type=design "MergeLabsGuestApp"

Ngo9BigBOggjHTQxAR8/V1JEaF5cXmRCeUx0RHxbf1x1ZFRHal5XTnNcUiweQnxTdEBjXn5acXVXQGVfU0V1W0leYw==

https://docs.google.com/document/d/1u6IBMOjZMX3sd6CcWWc836jKrtsRFcIzK54UbfoKs7A/edit?usp=sharing&usp=embed_facebook


Our infrastructure is completely running on .NET 9 (soon to be 10). We use Blazor for our front-end, so we are fully using C# across the entire solution 😇

I'm reaching out because we would like to build out our iOS and Android native apps using MAUI. 

This is a multi-stage project, with what could be considered as an "easy" first stage. 

As the first stage, we want to present this information as a native app so that we can also provide in-app alerts: https://www.fullevent.io/customer-booking/019759ee-a857-7379-89e5-d2c892146b3d/agenda

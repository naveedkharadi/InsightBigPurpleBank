# Insight Big Purple Bank

The solution consists of the following 4 projects.

 1. InsightBigPurpleBank.Api
 2. InsightBigPurpleBank.ApiTests
 3. InsightBigPurpleBank.Domain
 4. InsightBigPurpleBank.Infrastructure

All the projects are built on .NET 6.0.

## 1. InsightBigPurpleBank.Api

This is an Asp.Net Core MVC project that contains the API endpoint controllers and HTTP middleware/pipeline setup.

There is only one controller having one endpoint "GetProducts".

## 2. InsightBigPurpleBank.ApiTests

This project contains unit tests for the solution. Currently, there tests only for GetProducts endpoint.

## 3. InsightBigPurpleBank.Domain

This project contains domain entities, enums and repository interfaces.

## 4. InsightBigPurpleBank.Infrastructure

This project contains imlpementation for repositories. Currently, the repository returns hardcoded data; however, it can easily be modified to integrate with relevant data sources.

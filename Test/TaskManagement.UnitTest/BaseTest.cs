using AutoBogus;
using Bogus;
using FluentAssertions;
using NUnit.Framework;

namespace TaskManagement.UnitTest;

public class BaseTest
{
    protected Faker Faker;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Faker = new Faker("pt_BR");
    }

    [SetUp]
    public void AllTestSetUp() {
        AutoFaker.Configure(builder =>
        {
            builder.WithRecursiveDepth(1);
        });
    }

    public bool Compare<T>(T expected, T result)
    {
        try
        {
            expected.Should().BeEquivalentTo(result);
            return true;
        }
        catch (Exception) { return false; }
    }}
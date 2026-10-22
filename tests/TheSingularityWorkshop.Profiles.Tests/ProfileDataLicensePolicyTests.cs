using TheSingularityWorkshop.Profiles;
using Xunit;

namespace TheSingularityWorkshop.Profiles.Tests;

public sealed class ProfileDataLicensePolicyTests
{
    [Fact]
    public void AttributeKeysReturnsSnapshotRatherThanMutableInternalState()
    {
        var policy = new ProfileDataLicensePolicy { Enabled = true };
        policy.Allow("language");

        var snapshot = Assert.IsType<HashSet<string>>(policy.AttributeKeys);
        snapshot.Clear();

        Assert.True(policy.CanLicense("language"));
        Assert.Contains("language", policy.AttributeKeys);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void LicensingOperationsRejectMissingAttributeKeys(string? attributeKey)
    {
        var policy = new ProfileDataLicensePolicy();

        Assert.Throws<ArgumentException>(() => policy.Allow(attributeKey!));
        Assert.Throws<ArgumentException>(() => policy.Disallow(attributeKey!));
        Assert.Throws<ArgumentException>(() => policy.CanLicense(attributeKey!));
    }

    [Fact]
    public void DisallowAndCanLicenseUseTheSameAttributeKeyContract()
    {
        var policy = new ProfileDataLicensePolicy { Enabled = true };
        policy.Allow("language");

        Assert.True(policy.CanLicense("language"));
        Assert.True(policy.Disallow("language"));
        Assert.False(policy.CanLicense("language"));
    }
}

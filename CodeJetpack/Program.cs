using CodeJetpack.Business;

Console.WriteLine("Starting CodeJetpack...");

// Use the manager to create and maintain the collection of jetpacks.
var manager = new JfJetpackManager();
manager.Create("SkyDancer");
manager.Create("CloudSurfer");
manager.Create("RocketRider");
manager.Create("AltitudeAce");
manager.Create("NimbusNavigator");

manager.SortByName();

Console.WriteLine("Jetpacks (unsorted):");
foreach (var jetpack in manager)
{
	Console.WriteLine($" - {jetpack.Name} ({jetpack.FuelAmount} fuel)");
}

Console.WriteLine("Done!");
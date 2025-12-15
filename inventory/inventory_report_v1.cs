// ==========================================
// Space Engineers Script
// Author: AsterakisGR
// Purpose: Reports total cargo inventory contents on the grid
// Blocks Required: Cargo Containers
// Grid: Both
// Version: 1.0
// Status: Tested
// Last Updated: 15-12-2025
// ==========================================

List<IMyCargoContainer> cargoContainers = new List<IMyCargoContainer>();

public Program()
{
    Runtime.UpdateFrequency = UpdateFrequency.Update100;

    // Find all cargo containers on this grid
    GridTerminalSystem.GetBlocksOfType(cargoContainers);
}

public void Main(string argument)
{
    double totalVolume = 0;
    int totalItemTypes = 0;

    foreach (var container in cargoContainers)
    {
        var inventory = container.GetInventory();

        totalVolume += (double)inventory.CurrentVolume;

        var items = new List<MyInventoryItem>();
        inventory.GetItems(items);
        totalItemTypes += items.Count;
    }

    Echo("Inventory Report");
    Echo("----------------");
    Echo("Containers: " + cargoContainers.Count);
    Echo("Item Types: " + totalItemTypes);
    Echo("Used Volume: " + totalVolume.ToString("0.00"));
}

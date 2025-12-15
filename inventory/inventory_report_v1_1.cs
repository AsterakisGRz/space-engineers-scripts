// ==========================================
// Space Engineers Script
// Author: AsterakisGR
// Purpose: Reports total cargo inventory contents on the grid
// Blocks Required: Cargo Containers
// Grid: Both
// Version: 1.1
// Status: Untested
// Last Updated: DD-MM-2025
// ==========================================

List<IMyCargoContainer> cargoContainers = new List<IMyCargoContainer>();

public Program()
{
    Runtime.UpdateFrequency = UpdateFrequency.Update100;
    RefreshCargoContainers();
}

void RefreshCargoContainers()
{
    cargoContainers.Clear();
    GridTerminalSystem.GetBlocksOfType(cargoContainers);
}

public void Main(string argument)
{
    if (argument == "refresh")
    {
        RefreshCargoContainers();
        Echo("Cargo containers refreshed.");
        return;
    }

    if (cargoContainers.Count == 0)
    {
        Echo("No cargo containers found.");
        Echo("Run with argument: refresh");
        return;
    }

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

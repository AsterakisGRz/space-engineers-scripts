// ==========================================
// Space Engineers Script
// Author: AsterakisGR
// Purpose: Reports total cargo inventory contents on the grid
// Blocks Required: Cargo Containers
// Grid: Both
// Version: 1.1
// Status: Tested
// Last Updated: 15-12-2025
// ==========================================


// This creates a LIST that will hold all cargo containers found on the grid.
// Think of it as an empty box that will later be filled with cargo containers.
List<IMyCargoContainer> cargoContainers = new List<IMyCargoContainer>();


public Program()
{
    // This tells Space Engineers how often to run Main().
    // Update100 = roughly every 1.6 seconds.
    // This is safe for inventory reading.
    Runtime.UpdateFrequency = UpdateFrequency.Update100;

    // We immediately scan the grid for cargo containers when the script starts.
    RefreshCargoContainers();
}


// This is a custom function (helper).
// Its ONLY job is to find cargo containers and store them in the list.
void RefreshCargoContainers()
{
    // Clear the list so we don’t accidentally keep old or removed blocks.
    cargoContainers.Clear();

    // Ask the game to find ALL cargo containers on the same grid
    // and put them into the cargoContainers list.
    GridTerminalSystem.GetBlocksOfType(cargoContainers);
}


public void Main(string argument)
{
    // The 'argument' is text you type when you manually run the script.
    // Example: typing "refresh" lets the script know you want to rescan blocks.

    if (argument == "refresh")
    {
        // Re-scan the grid for cargo containers
        RefreshCargoContainers();

        // Show confirmation message in the Programmable Block
        Echo("Cargo containers refreshed.");

        // Stop the script here so it does NOT continue further
        return;
    }

    // If the script found ZERO cargo containers, we stop safely.
    if (cargoContainers.Count == 0)
    {
        Echo("No cargo containers found.");
        Echo("Run with argument: refresh");
        return;
    }

    // This will store the total used volume of all cargo containers
    double totalVolume = 0;

    // This counts how many DIFFERENT item stacks exist
    // (not how many physical items)
    int totalItemTypes = 0;

    // Loop through every cargo container we found
    foreach (var container in cargoContainers)
    {
        // Get the inventory inside this cargo container
        var inventory = container.GetInventory();

        // Add the used volume of this inventory to the total
        totalVolume += (double)inventory.CurrentVolume;

        // Create a temporary list to store items inside this inventory
        var items = new List<MyInventoryItem>();

        // Fill the list with items from the inventory
        inventory.GetItems(items);

        // Count how many item stacks are in this container
        totalItemTypes += items.Count;
    }

    // Display results inside the Programmable Block
    Echo("Inventory Report");
    Echo("----------------");
    Echo("Containers: " + cargoContainers.Count);
    Echo("Item Types: " + totalItemTypes);
    Echo("Used Volume: " + totalVolume.ToString("0.00"));
}

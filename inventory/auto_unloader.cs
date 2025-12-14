// ==========================================
// Space Engineers Script
// Author: Aster
// Purpose: Automatically unloads cargo to a connector-attached base
// Blocks: Connector (tagged [BASE])
// Version: 1.0
// ==========================================

public Program()
{
    Runtime.UpdateFrequency = UpdateFrequency.Update100;
}

public void Main(string argument)
{
    var connectors = new List<IMyShipConnector>();
    GridTerminalSystem.GetBlocksOfType(connectors);

    IMyShipConnector baseConnector = null;

    foreach (var c in connectors)
    {
        if (c.CustomName.Contains("[BASE]") && c.Status == MyShipConnectorStatus.Connected)
        {
            baseConnector = c;
            break;
        }
    }

    if (baseConnector == null)
        return;

    var sourceInv = Me.GetInventory(0);
    var targetInv = baseConnector.GetInventory(0);

    var items = new List<MyInventoryItem>();
    sourceInv.GetItems(items);

    foreach (var item in items)
    {
        sourceInv.TransferItemTo(targetInv, item);
    }
}

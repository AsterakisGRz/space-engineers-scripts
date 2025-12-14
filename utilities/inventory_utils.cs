// ==========================================
// Space Engineers Utility
// Author: Aster
// File: inventory_utils.cs
// Purpose: Shared inventory helper functions
// Version: 1.0
// ==========================================

public static class InventoryUtils
{
    public static bool TryGetInventory(IMyTerminalBlock block, out IMyInventory inventory)
    {
        inventory = null;
        if (block == null) return false;
        if (block.InventoryCount == 0) return false;

        inventory = block.GetInventory(0);
        return inventory != null;
    }
}
